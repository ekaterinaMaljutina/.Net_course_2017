using System;

namespace Attributes.AssertException
{
    [Serializable] 
    public class MyAssertException : Exception
    {
        public MyAssertException()
        {
        }

        public MyAssertException(string message)
            : base(message)
        {
        }

        public MyAssertException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MyAssertException(System.Runtime.Serialization.SerializationInfo info, 
                                  System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}

