using System;
using System.Runtime.Serialization;

namespace MyOption.MyException
{
    public class NotValueException : Exception
    {
        public NotValueException()
        {
        }

        protected NotValueException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }

        public NotValueException(string message) 
            : base(message)
        {
        }

        public NotValueException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }

    public class NullValueException : Exception
    {
        public NullValueException()
        {
        }

        protected NullValueException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }

        public NullValueException(string message) : base(message)
        {
        }

        public NullValueException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }

}

