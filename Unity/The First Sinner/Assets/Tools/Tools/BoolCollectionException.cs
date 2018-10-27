using System;
using System.Runtime.Serialization;

[Serializable]
internal class BoolCollectionException : Exception
{
    public BoolCollectionException()
    {
    }

    public BoolCollectionException(string message) : base(message)
    {
    }

    public BoolCollectionException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BoolCollectionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}