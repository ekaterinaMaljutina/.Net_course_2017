using System;

namespace MyOption
{
    public class NotValueException : Exception
    {
        public NotValueException(string Message)
            : base(Message)
        {
        }
    }

    public class NullValueException : Exception
    {
        public NullValueException(string Message)
            : base(Message)
        {
        }
    }

}

