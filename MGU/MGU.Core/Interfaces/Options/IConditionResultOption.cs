namespace MGU.Core.Interfaces.Options
{
    using System;
    using Exceptions;
    using Helpers;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines options performed after the specified conditions are evaluated.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IConditionResultOption<TSource>
    {
        /// <summary>
        /// Gets the result of the evaluation of the specified conditions.
        /// </summary>
        bool Result { get; }

        /// <summary>
        /// Gets additional options for casting the source object to an other type if the specified conditions are met.
        /// </summary>
        /// <returns><see cref="ICastOption"/></returns>
        ICastOption Cast { get; }

        /// <summary>
        /// Invokes the actions if the specified conditions are met.
        /// </summary>
        /// <param name="action">The first action.</param>
        /// <param name="actions">The other actions.</param>
        /// <returns>The source object.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="actions"/> contains <c>null</c>.
        /// </exception>
        TSource Invoke([NotNull]Action action, [CanBeNull]params Action[] actions);

        /// <summary>
        /// Invokes the function and returns the result if the specified conditions are met.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>
        /// The value returned by the function if the specified conditions are met;
        /// otherwise the source object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="func"/> is <c>null</c>.
        /// </exception>
        TSource Get([NotNull]Func<TSource> func);

        /// <summary>
        /// Sets <paramref name="other"/> to the source object if the specified conditions are met.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>The source object.</returns>
        TSource Set(ref TSource other);

        /// <summary>
        /// Returns <paramref name="value"/> if the specified conditions are met.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <paramref name="value"/> if the specified conditions are met;
        /// otherwise the source object.
        /// </returns>
        TSource Then(TSource value);

        /// <summary>
        /// Throws an <typeparamref name="TException"/> if the specified conditions are met.
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the specified parameters.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exceptionParameters">The exception parameters.</param>
        /// <exception cref="CouldNotCreateInstanceException">
        /// No public constructor was found that matches the specified parameters.
        /// </exception>
        /// <returns>The source object.</returns>
        TSource Throw<TException>(params object[] exceptionParameters)
            where TException : Exception;

        /// <summary>
        /// Throws an <typeparamref name="TException"/> if the specified conditions are met.
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the specified parameters or the default constructor
        /// if no other constructor was found.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="defaultMessage">
        /// The default message that will be appended to the message of default exception.
        /// </param>
        /// <param name="exceptionParameters">The exception parameters.</param>
        /// <returns>The source object.</returns>
        TSource ThrowOrDefault<TException>(DefaultMessage defaultMessage, params object[] exceptionParameters)
            where TException : Exception, new();

        /// <summary>
        /// Throws the <paramref name="exception"/> if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <exception cref="ExceptionIsNullException">
        /// The specified exception is <c>null</c>.
        /// </exception>
        /// <returns>The source object.</returns>
        TSource Throw<TException>([NotNull]TException exception)
            where TException : Exception;

        /// <summary>
        /// Gets additional options for throwing exceptions if the specified conditions are met.
        /// </summary>
        /// <returns><see cref="IThrowOption{TSource}"/></returns>
        IThrowOption<TSource> Throw();
    }
}