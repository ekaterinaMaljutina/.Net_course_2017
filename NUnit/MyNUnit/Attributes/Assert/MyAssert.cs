using System;
using Attributes.AssertException;

namespace Attributes.MyAssert
{
    public static class MyAssert
    {
        private static string PrintLog (string expected, string actual) => $"Expected: {expected} Actual: {actual}";

        public static bool IsTrue(bool value)
        {
            if (value) 
            {
                return true;
            }
            Fail(PrintLog("true", "false"));
            return false;
        }

        public static bool IsFalse(bool value)
        {
            if (!value) 
            {
                return true;
            }
            Fail(PrintLog("false", "true"));
            return false;
        }

        public static bool Equal(object expected, object actual)
        {
            if (expected == null && actual == null) 
            {
                return true;
            }
            if (expected == null || actual == null) 
            {
                return false;
            }
                
            var result = object.Equals(expected, actual);
            if (result) 
            {
                return result;
            }
            Fail(PrintLog(expected.ToString(), actual.ToString()));
            return result;
        }


        public static bool NotEqual(Object expected, Object actual)
        {
            if (expected == null && actual == null) 
            {
                return false;
            }
            if (expected == null || actual == null) 
            {
                return true;
            }

            var result = object.Equals(expected, actual);
            if (result) 
            {
                Fail(PrintLog(expected.ToString(), actual.ToString()));
                return !result;
            }
            return !result;
        }


        private static void Fail(string message)
        {           
            throw new MyAssertException(message);
        }
    }
}

