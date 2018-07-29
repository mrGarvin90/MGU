namespace MGU.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The exception that is thrown when an exception is null.
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public sealed class ExceptionIsNullException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionIsNullException" /> class.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        internal ExceptionIsNullException([NotNull]Type exceptionType)
            : base($"Exception cannot be null.{Environment.NewLine}Type: {exceptionType.FullName}")
        {
        }

        private ExceptionIsNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}