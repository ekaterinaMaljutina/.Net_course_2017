using System;
using MyUnit.AssertException;

namespace MyUnit.MyAssert
{
    public static class MyAssert
    {

        private static string PrintLog (string expected, string actual) =>  @"Expected: " + expected + " Actual: " + actual;

        public static bool isTrue (bool value)
        {
            if (value == true) {
                return true;
            }
            IsFail (PrintLog ("true", "false"));
            return false;
        }

        public static bool isFalse (bool value)
        {
            if (value == false) {
                return true;
            }
            IsFail (PrintLog ("false", "true"));
            return false;
        }

        public static bool Equal (Object expected, Object actual)
        {
            if (expected == null && actual == null) {
                return true;
            }
            if ((expected == null && actual != null) || (actual == null && expected != null)) {
                return false;
            }
            if (expected.Equals (actual)) {
                return true;
            }
            IsFail (PrintLog (expected.ToString (), actual.ToString ()));
            return false;
        }


        public static bool NotEqual(Object expected, Object actual)
        {
            if (expected == null && actual == null) 
            {
                return false;
            }
            if ( (expected == null && actual != null) || (expected != null && actual == null)) {
                return true;
            }
            if (expected.Equals (actual)) {
                IsFail (PrintLog (expected.ToString (), actual.ToString ()));
                return false;
            }
            return true;
        }


        public static void IsFail (string message)
        {           
            throw new MyAssertException (message);
        }
    }
}

