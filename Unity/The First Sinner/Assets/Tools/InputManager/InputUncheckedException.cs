using System;
using System.Runtime.Serialization;
namespace InputManager
{
    [Serializable]
    internal class InputUncheckedException : Exception
    {
        public InputUncheckedException()
        {
        }

        public InputUncheckedException(string message) : base(message)
        {
        }

        public InputUncheckedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InputUncheckedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
