using System.Runtime.Serialization;

namespace MiniRoguelike.Exception
{
    public class PlayerPositionException : System.Exception
    {
        public PlayerPositionException()
        {
        }
        
        protected PlayerPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PlayerPositionException(string message) : base(message)
        {
        }

        public PlayerPositionException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}