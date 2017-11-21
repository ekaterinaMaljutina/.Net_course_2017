using System.Runtime.Serialization;

namespace MiniRoguelike.Exception
{
    public class MapReadException : System.Exception
    {
        public MapReadException(string message) : base(message)
        {
        }

        public MapReadException()
        {
        }

        protected MapReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MapReadException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}