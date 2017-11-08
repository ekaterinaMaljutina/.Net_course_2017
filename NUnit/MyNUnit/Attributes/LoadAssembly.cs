using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

using MyUnit.CustomAttributes.Utils;

namespace MyUnit.CustomAttributes
{
    public class LoadAssembly
    {
        private Assembly assembly;

        private List<Type> classes = new List<Type> ();
        private List<MethodInfo> beforeMethod = new List<MethodInfo> ();
        private List<MethodInfo> afterMethod = new List<MethodInfo> ();
        private List<MethodInfo> beforeClassMethod = new List<MethodInfo> ();
        private List<MethodInfo> afterClassMethod = new List<MethodInfo> ();
        private List<MethodInfo> testMethod = new List<MethodInfo> ();

        public void ExecuteTest (string path)
        {
            try {
                assembly = Assembly.LoadFrom (path);
            } catch (Exception) {
                Console.WriteLine ("file not found");
            }
            clearMethods ();
            GetClass (assembly);

        }

        private void addAfterMethod (MethodInfo method) => afterMethod.Add (method);

        private void addBeforeMethod (MethodInfo method) => beforeMethod.Add (method);

        private void addAfterClassMethod (MethodInfo method) => afterClassMethod.Add (method);

        private void addBeforeClassMethod (MethodInfo method) => beforeClassMethod.Add (method);

        private void addTestMethod (MethodInfo method) => testMethod.Add (method);

        private void GetClass (Assembly assembly)
        {
            foreach (var type in assembly.GetTypes ()) {
                classes.Add (type);
            }
            GetMethod ();
        }

        private void createInstance (MethodInfo info, object type)
        {
            var dateTime = DateTime.Now;
            string time;
            string expectedException = null;
            Test testInfo = null;

            var nameMethod = info.DeclaringType.ToString () + "." + info.Name;
            try {
                testInfo = info.GetCustomAttribute<Test> ();
                if (testInfo != null && testInfo.Ignore != null) {
                    PrintIgnoreInfo (nameMethod, testInfo.Ignore);
                    return;
                }
                expectedException = testInfo != null ? testInfo.Expected : null;

                dateTime = DateTime.Now;

                info.Invoke (type, null);

                time = (DateTime.Now - dateTime).TotalMilliseconds.ToString ();
                if (testInfo == null) { // run before, afther method
                    return;
                }
                PrintSuccess (nameMethod, time);
            } catch (Exception ex) {
                if (testInfo == null) { // run before, afther method when no print exeption
                    Console.WriteLine (@"WARNING run NOT TEST method: {0} AND GET EXCEPTION {1}", nameMethod,
                        ex.GetBaseException ().Message);
                    return;
                }
                time = (DateTime.Now - dateTime).TotalMilliseconds.ToString ();
                if (expectedException != null &&
                    ex.GetBaseException ().GetType ().ToString ().Contains (expectedException)) {
                    PrintSuccess (nameMethod, time);
                    return;
                }
                PrintFail (nameMethod, time, ex.GetBaseException ().Message);
            }
        }

        private void GetMethod ()
        {
            classes.ForEach (c => {
                object instanceClass = c; // if consctuctor private
                var constructors = c.GetConstructors ();
                foreach (ConstructorInfo constructorInfo in constructors) {
                    var parameterInfo = constructorInfo.GetParameters ();
                    var constructorParams = new List<object> ();
                    foreach (ParameterInfo constructorParam in parameterInfo) {
                        object value = constructorParam.HasDefaultValue ?
                                constructorParam.DefaultValue :
                                    constructorParam.ParameterType.IsValueType ?
                                    Activator.CreateInstance (constructorParam.ParameterType) :
                                    null;
                        constructorParams.Add (value);
                    }
                    instanceClass = constructorInfo.Invoke (constructorParams.ToArray ());
                    break;
                }

                setMethod (instanceClass.GetType ().GetTypeInfo ().GetMethods ());

                beforeClassMethod.ForEach (method => createInstance (method, instanceClass));

                testMethod.ForEach (method => { 
                    var isIgnoreMethod = method.GetCustomAttribute<Test> ().Ignore != null; 
                    if (!isIgnoreMethod) {
                        beforeMethod.ForEach (methodBefore => createInstance (methodBefore, instanceClass));
                    }
                    createInstance (method, instanceClass);
                    if (!isIgnoreMethod) {
                        afterMethod.ForEach (methodAfter => createInstance (methodAfter, instanceClass));
                    }
                });

                afterClassMethod.ForEach (method => createInstance (method, instanceClass));

                clearMethods ();

            });
        }

        private void setMethod (MethodInfo[] methodInfo)
        {
            foreach (MethodInfo method in methodInfo) {
                if (method.GetCustomAttribute<AfterClass> () != null) {
                    addAfterClassMethod (method);
                }
                if (method.GetCustomAttribute<BeforeClass> () != null) {
                    addBeforeClassMethod (method);
                }
                if (method.GetCustomAttribute<Before> () != null) {
                    addBeforeMethod (method);
                }
                if (method.GetCustomAttribute<After> () != null) {
                    addAfterMethod (method);
                }
                if (method.GetCustomAttribute<Test> () != null) {
                    addTestMethod (method);
                }
            }
        }

        private void clearMethods ()
        {
            beforeMethod.Clear ();
            afterMethod.Clear ();
            testMethod.Clear ();
            beforeClassMethod.Clear ();
            afterClassMethod.Clear ();
        }

        private static void PrintNameMethod (string nameMethod)
        {
            Console.Write (@"Test: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write (nameMethod + " ");
            Console.ResetColor ();
        }

        private static void ResetColorAndNewLine ()
        {
            Console.ResetColor ();
            Console.WriteLine ();
        }

        private static void PrintIgnoreInfo (string nameMethod, string info)
        {
            PrintNameMethod (nameMethod);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write (@" IGNORE ");
            Console.ResetColor ();
            Console.Write (@" INFO: {0} ", info);
            ResetColorAndNewLine ();
        }

        private static void PrintTime (string time)
        {
            string outFormat = " TIME: {0}ms ";
            Console.Write (@outFormat, time);
        }

        private static void PrintSuccess (string nameMethod, string time)
        {
            string outFormat = " SUCCESS ";
            PrintNameMethod (nameMethod);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write (outFormat);
            PrintTime (time);
            ResetColorAndNewLine ();
        }

        private void PrintFail (string nameMethod, string time, string messange)
        {
            PrintNameMethod (nameMethod);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write (@" FAIL ");
            PrintTime (time);
            Console.ResetColor ();
            Console.Write (@" Messange: " + messange);
            ResetColorAndNewLine ();
        }

    }

}