using System;

namespace MyUnit.CustomAttributes.Utils
{
    public class Test:System.Attribute
    {
        public string Expected { set; get; }

        public string Ignore{ set; get; }
    }

    public class Before:System.Attribute
    {

    }

    public class After:System.Attribute
    {
		
    }

    public class BeforeClass:System.Attribute
    {
		
    }

    public class AfterClass:System.Attribute
    {

    }

    public static class Assert
    {

        private static string PrintLog (string expected, string actual)
        {
            return @"Expected: " + expected + " Actual: " + actual;
        }

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


        public static void IsFail (string message)
        {           
            throw new AssertException (message);
        }
    }

    public class AssertException : Exception
    {
        public AssertException (string message)
            : base (message)
        {
        }

    }
}
