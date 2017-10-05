using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

using MyUnit.AssertException;
using MyUnit.Annotation;
using MyUnit.Logger;

namespace MyUnit.CustomAttributes
{
    public class LoadAssembly
    {
        private Assembly _assembly { set; get; }

        public void ExecuteTest (string path)
        {
            try {
                _assembly = Assembly.LoadFrom (path);
            } catch (Exception) {
                Console.WriteLine ("file not found");
                return;
            }

            _assembly.GetTypes ().ToList ().ForEach (c => RunTestsInClass (c));
        }

        private void createInstance (MethodInfo info, object type)
        {
            var dateTime = DateTime.Now;
            string expectedException = null;
            var testMethod = info.GetCustomAttribute<Test> ();

            var nameMethod = info.DeclaringType.ToString () + "." + info.Name;
            try {

                // if test with ignore annotation, when not run
                if (testMethod != null && testMethod.Ignore != null) { 
                    Logger.LoggerUtils.PrintIgnoreInfo (nameMethod, testMethod.Ignore);
                    return;
                }

                expectedException = testMethod != null ? testMethod.Expected : null;

                dateTime = DateTime.Now;

                info.Invoke (type, null);

                var time = (DateTime.Now - dateTime).TotalMilliseconds.ToString ();

                // if run before or afther method, when no print result 
                if (testMethod == null) { 
                    return;
                }
                Logger.LoggerUtils.PrintSuccess (nameMethod, time);

            } catch (TargetInvocationException ex) {
                
                // if run before or afther method and get exeption
                if (testMethod == null) { 
                    Console.WriteLine (@"WARNING run NOT TEST method: {0} AND GET EXCEPTION {1}", nameMethod,
                        ex.GetBaseException ().Message);
                    return;
                }

                var time = (DateTime.Now - dateTime).TotalMilliseconds.ToString ();

                if (expectedException != null &&
                    ex.GetBaseException ().GetType ().ToString ().Contains (expectedException)) {
                    Logger.LoggerUtils.PrintSuccess (nameMethod, time);
                    return;
                }
                Logger.LoggerUtils.PrintFail (nameMethod, time, ex.GetBaseException ().Message);
            
            } catch (Exception ex) {
                Console.WriteLine (@"WARNING run method: {0} AND GET EXCEPTION {1}", nameMethod,
                    ex.GetBaseException ().Message);
            }
        }

        private object createInstanceClass (Type _class)
        {
            object instanceClass = _class; // if consctuctor private
            if (!(_class.IsInterface || _class.IsAbstract)) {
                var firstConstructor = _class.GetConstructors ().FirstOrDefault ();
                var parameterInfo = firstConstructor.GetParameters ();
                var constructorParams = new List<object> ();
                foreach (ParameterInfo constructorParam in parameterInfo) {
                    object value = constructorParam.HasDefaultValue ?
                        constructorParam.DefaultValue :
                        constructorParam.ParameterType.IsValueType ?
                        Activator.CreateInstance (constructorParam.ParameterType) :
                        null;
                    constructorParams.Add (value);
                }
                instanceClass = firstConstructor.Invoke (constructorParams.ToArray ());
            }
            return instanceClass;
        }

        private void RunTestsInClass (Type _class)
        {
            var allMethod = _class.GetMethods ();

            var beforeClassMethods = allMethod.Where (method => method.GetCustomAttributes<BeforeClass> ().Any ()).ToList ();
            var afterClassMethods = allMethod.Where (method => method.GetCustomAttributes<AfterClass> ().Any ()).ToList ();
            var beforeMethods = allMethod.Where (method => method.GetCustomAttributes<Before> ().Any ()).ToList ();
            var afterMethods = allMethod.Where (method => method.GetCustomAttributes<After> ().Any ()).ToList ();
            var tests = allMethod.Where (method => method.GetCustomAttributes<Test> ().Any ()).ToList ();
            
            object instanceClass = createInstanceClass (_class);

            beforeClassMethods.ForEach (method => createInstance (method, instanceClass));

            tests.ForEach (method => { 
                var isIgnoreMethod = method.GetCustomAttribute<Test> ().Ignore != null; 
                if (!isIgnoreMethod) {
                    beforeMethods.ForEach (methodBefore => createInstance (methodBefore, instanceClass));
                }
                createInstance (method, instanceClass);
                if (!isIgnoreMethod) {
                    afterMethods.ForEach (methodAfter => createInstance (methodAfter, instanceClass));
                }
            });

            afterClassMethods.ForEach (method => createInstance (method, instanceClass));
        }
    }
}