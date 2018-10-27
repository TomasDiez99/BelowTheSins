using System;
using System.Runtime.Serialization;

namespace Tools
{
    [Serializable]
    internal class RunnableException : Exception
    {
        public RunnableException()
        {
        }

        public RunnableException(string message) : base(message)
        {
        }

        public RunnableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RunnableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}