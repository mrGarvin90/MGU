namespace MGU.Core.Tests.TestObjects
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class TestException : Exception
    {
        public const string DefaultMessage = "Test message.";

        public TestException()
            : base(DefaultMessage)
        {
        }

        public TestException(string message)
            : base(message)
        {
        }

        public TestException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
        }

        public TestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private TestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}