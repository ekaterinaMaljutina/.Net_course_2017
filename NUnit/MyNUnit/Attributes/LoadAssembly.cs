using System;

using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

using Attributes.AssertException;
using Attributes.Annotation;
using Attributes.Logger;

namespace Attributes.CustomAttributes
{
    public class LoadAssembly
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();

        private Assembly Assembly { get; set; }              

        public void ExecuteTest(string path)
        {
            try 
            {
                Assembly = Assembly.LoadFrom(path);
            } catch(Exception) 
            {
                Console.WriteLine("file not found");
                return;
            }

            Assembly.GetTypes().ToList().ForEach(RunTestsInClass);
        }

        private void CreateInstance(MethodBase info, object type)
        {
            string expectedException = null;
            var testMethod = info.GetCustomAttribute<Test>();

            var nameMethod = info.DeclaringType + "." + info.Name;
            try 
            {
                // if test with ignore annotation, when not run
                if (testMethod != null && testMethod.Ignore) 
                {                    
                    LoggerUtils.PrintIgnoreInfo(nameMethod, testMethod.Ignore);
                    return;
                }

                expectedException = testMethod?.Expected;

                _stopWatch.Reset();
                _stopWatch.Start();

                info.Invoke(type, null);

                _stopWatch.Stop();

                // if run before or afther method, when no print result 
                if (testMethod == null) 
                { 
                    return;
                }
                LoggerUtils.PrintSuccess(nameMethod, GetTime());

            } catch(TargetInvocationException ex) 
            {
                // if run before or afther method and get exeption
                if (testMethod == null) 
                { 
                    LoggerUtils.PrintWarningNotTestMethod(nameMethod, ex.ToString());
                    return;
                }

                _stopWatch.Stop();

                if (expectedException != null &&
                    ex.GetBaseException().GetType().ToString().Contains(expectedException)) 
                {
                    LoggerUtils.PrintSuccess(nameMethod, GetTime());
                    return;
                }
                LoggerUtils.PrintFail(nameMethod, GetTime(), ex.ToString());
            
            } catch(Exception ex) 
            {
                LoggerUtils.PrintWarning(nameMethod, ex.ToString());
            }
        }

        private object createInstanceClass(Type _class)
        {
            object instanceClass = _class; // if consctuctor private
            if (!(_class.IsInterface || _class.IsAbstract))
            {
                var firstConstructor = _class.GetConstructors().FirstOrDefault();
                if (firstConstructor == null) {
                    throw new ApplicationException(string.Format(" can't create class {0} ", _class.Name));
                }
                var parameterInfo = firstConstructor.GetParameters();
                var constructorParams = new List<object>();
                foreach(var constructorParam in parameterInfo)
                {
                    var instance = constructorParam.ParameterType.IsValueType ? 
                        Activator.CreateInstance(constructorParam.ParameterType) :
                        null;
                    
                    var value = constructorParam.HasDefaultValue ? constructorParam.DefaultValue : instance;
                    constructorParams.Add(value);
                }
                instanceClass = firstConstructor.Invoke(constructorParams.ToArray());
            }
            return instanceClass;
        }

        private void RunTestsInClass(Type classType)
        {
            var allMethod = classType.GetMethods();

            var beforeClassMethods = allMethod.Where(method => method.GetCustomAttributes<BeforeClass>().Any()).ToList();
            var afterClassMethods = allMethod.Where(method => method.GetCustomAttributes<AfterClass>().Any()).ToList();
            var beforeMethods = allMethod.Where(method => method.GetCustomAttributes<Before>().Any()).ToList();
            var afterMethods = allMethod.Where(method => method.GetCustomAttributes<After>().Any()).ToList();
            var tests = allMethod.Where(method => method.GetCustomAttributes<Test>().Any()).ToList();
            
            object instanceClass = createInstanceClass(classType);

            beforeClassMethods.ForEach(method => CreateInstance(method, instanceClass));

            tests.ForEach(method => { 
                var isIgnoreMethod = method.GetCustomAttribute<Test>().Ignore; 
                if (!isIgnoreMethod) 
                {
                    beforeMethods.ForEach(methodBefore => CreateInstance(methodBefore, instanceClass));
                }
                CreateInstance(method, instanceClass);
                if (!isIgnoreMethod) 
                {
                    afterMethods.ForEach(methodAfter => CreateInstance(methodAfter, instanceClass));
                }
            });

            afterClassMethods.ForEach(method => CreateInstance(method, instanceClass));
        }

        private string GetTime() 
        {
            var duration = _stopWatch?.Elapsed ?? TimeSpan.Zero;
            return duration.ToString();
        }
    }
}