namespace MGU.Core.Interfaces.Options
{
    using System;

    /// <summary>
    /// Defines options for throwing exceptions if the specified conditions are met.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IThrowOption<out TSource>
    {
        #region ArgumentException.

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource Argument(string message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource Argument(string message, Exception innerException);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The source object.</returns>
        TSource Argument(string message, string paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource Argument(string message, string paramName, Exception innerException);

        #endregion

        #region ArgumentNullException.

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The source object.</returns>
        TSource Null(string paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource Null(string paramName, string message);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource Null(string message, Exception innerException);

        #endregion

        #region ArgumentOutOfRangeException.

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The source object.</returns>
        TSource OutOfRange(string paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource OutOfRange(string paramName, string message);

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource OutOfRange(string paramName, object actualValue, string message);

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource OutOfRange(string message, Exception innerException);

        #endregion

        #region InvalidOperationException.

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource InvalidOperation(string message);

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource InvalidOperation(string message, Exception innerException);

        #endregion

        #region Exception.

        /// <summary>
        /// Throws an <see cref="System.Exception"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The source object.</returns>
        TSource Exception(string message);

        /// <summary>
        /// Throws an <see cref="System.Exception"/> if the specified conditions are met.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The source object.</returns>
        TSource Exception(string message, Exception innerException);

        #endregion
    }
}