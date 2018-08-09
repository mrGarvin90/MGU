namespace MGU.Core.Internal.Options
{
    using System;
    using Core.Interfaces.Options;

    /// <inheritdoc />
    /// <summary>
    /// The <see cref="ThrowOption{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    internal class ThrowOption<TSource> : IThrowOption<TSource>
    {
        private readonly bool _throwException;

        private readonly TSource _source;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThrowOption{TSource}"/> class.
        /// </summary>
        /// <param name="throwException">If set to <c>true</c> an exception will be thrown.</param>
        /// <param name="source">The source object.</param>
        internal ThrowOption(bool throwException, TSource source)
        {
            _throwException = throwException;
            _source = source;
        }

        #region ArgumentException.

        /// <inheritdoc />
        public TSource Argument(string message)
        {
            return EvaluateThrowException(() => new ArgumentException(message));
        }

        /// <inheritdoc />
        public TSource Argument(string message, Exception innerException)
        {
            return EvaluateThrowException(() => new ArgumentException(message, innerException));
        }

        /// <inheritdoc />
        public TSource Argument(string message, string paramName)
        {
            return EvaluateThrowException(() => new ArgumentException(message, paramName));
        }

        /// <inheritdoc />
        public TSource Argument(string message, string paramName, Exception innerException)
        {
            return EvaluateThrowException(() => new ArgumentException(message, paramName, innerException));
        }

        #endregion

        #region ArgumentNullException.

        /// <inheritdoc />
        public TSource Null(string paramName)
        {
            return EvaluateThrowException(() => new ArgumentNullException(paramName));
        }

        /// <inheritdoc />
        public TSource Null(string paramName, string message)
        {
            return EvaluateThrowException(() => new ArgumentNullException(paramName, message));
        }

        /// <inheritdoc />
        public TSource Null(string message, Exception innerException)
        {
            return EvaluateThrowException(() => new ArgumentNullException(message, innerException));
        }

        #endregion

        #region ArgumentOutOfRangeException.

        /// <inheritdoc />
        public TSource OutOfRange(string paramName)
        {
            return EvaluateThrowException(() => new ArgumentOutOfRangeException(paramName));
        }

        /// <inheritdoc />
        public TSource OutOfRange(string paramName, string message)
        {
            return EvaluateThrowException(() => new ArgumentOutOfRangeException(paramName, message));
        }

        /// <inheritdoc />
        public TSource OutOfRange(string paramName, object actualValue, string message)
        {
            return EvaluateThrowException(() => new ArgumentOutOfRangeException(paramName, actualValue, message));
        }

        /// <inheritdoc />
        public TSource OutOfRange(string message, Exception innerException)
        {
            return EvaluateThrowException(() => new ArgumentOutOfRangeException(message, innerException));
        }

        #endregion

        #region InvalidOperationException.

        /// <inheritdoc />
        public TSource InvalidOperation(string message)
        {
            return EvaluateThrowException(() => new InvalidOperationException(message));
        }

        /// <inheritdoc />
        public TSource InvalidOperation(string message, Exception innerException)
        {
            return EvaluateThrowException(() => new InvalidOperationException(message, innerException));
        }

        #endregion

        #region Exception.

        /// <inheritdoc />
        public TSource Exception(string message)
        {
            return EvaluateThrowException(() => new Exception(message));
        }

        /// <inheritdoc />
        public TSource Exception(string message, Exception innerException)
        {
            return EvaluateThrowException(() => new Exception(message, innerException));
        }

        #endregion

        private TSource EvaluateThrowException(Func<Exception> exceptionErector)
        {
            if (_throwException)
                throw exceptionErector();
            return _source;
        }
    }
}