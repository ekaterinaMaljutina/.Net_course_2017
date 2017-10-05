using System;

namespace MyUnit.AssertException
{
    public class MyAssertException : Exception
    {
        public MyAssertException (string message)
            : base (message)
        {
        }

    }
}

