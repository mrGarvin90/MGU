namespace MGU.Core.Internal.Options
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Core.Extensions.Cast;
    using Core.Helpers;
    using Exceptions;
    using Helpers;
    using Interfaces.Options;

    /// <inheritdoc cref="IConditionResultOption{TSource}" />
    /// <inheritdoc cref="IThrowOption{TSource}" />
    /// <summary>
    /// The <see cref="ConditionResultOption{TSource}" /> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    internal class ConditionResultOption<TSource>
        : IConditionResultOption<TSource>,
          ISourceObject,
          IThrowOption<TSource>,
          ICastOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionResultOption{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="conditionResult">The condition result.</param>
        internal ConditionResultOption(TSource source, bool conditionResult)
        {
            Source = source;
            Result = conditionResult;
        }

        /// <inheritdoc />
        public bool Result { get; protected set; }

        /// <summary>
        /// Gets the source object.
        /// </summary>
        protected TSource Source { get; }

        #region Interface Implementations

#pragma warning disable SA1202 // Elements must be ordered by access
#pragma warning disable SA1201 // Elements must appear in the correct order

        #region IConditionResultOption<TSource>

        /// <inheritdoc />
        ICastOption IConditionResultOption<TSource>.Cast => this;

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Get(Func<TSource> func)
        {
            if (!Result)
                return Source;
            if (func is null)
                throw new ArgumentNullException(nameof(func));
            return func();
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Invoke(Action action, params Action[] actions)
        {
            if (!Result)
                return Source;
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (actions?.Contains(null) ?? false)
                throw new ArgumentException("Cannot contain null.", nameof(actions));
            action();
            for (var index = 0; index < actions?.Length; index++)
                actions[index]();
            return Source;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Set(ref TSource other)
        {
            if (Result)
                other = Source;
            return Source;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Then(TSource value)
            => Result ? value : Source;

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Throw<TException>(params object[] parameters)
        {
            if (!Result)
                return Source;
            TException exception;
            try
            {
                exception = Activator.CreateInstance(typeof(TException), parameters).Cast().To<TException>();
            }
            catch (Exception innerException)
            {
                throw new CouldNotCreateInstanceException(typeof(TException), parameters, innerException);
            }

            throw exception;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Throw<TException>(Type[] parameterTypes, object[] parameters)
        {
            if (!Result)
                return Source;
            TException exception;
            try
            {
                var constructorInfo = typeof(TException).GetConstructor(parameterTypes ?? new Type[0])
                                      ?? throw new ArgumentException($"Could not find a public constructor whose parameters match the types in {nameof(parameterTypes)}.");
                exception = (TException)constructorInfo.Invoke(parameters);
            }
            catch (Exception innerException)
            {
                throw new CouldNotCreateInstanceException(typeof(TException), parameterTypes, parameters, innerException);
            }

            throw exception;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.ThrowOrDefault<TException>(DefaultMessage defaultMessage, params object[] parameters)
        {
            try
            {
                return ((IConditionResultOption<TSource>)this).Throw<TException>(parameters);
            }
            catch (CouldNotCreateInstanceException)
            {
                throw CreateDefault<TException>(defaultMessage);
            }
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.ThrowOrDefault<TException>(DefaultMessage defaultMessage, Type[] parameterTypes, object[] parameters)
        {
            try
            {
                return ((IConditionResultOption<TSource>)this).Throw<TException>(parameterTypes, parameters);
            }
            catch (CouldNotCreateInstanceException)
            {
                throw CreateDefault<TException>(defaultMessage);
            }
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Throw<TException>(TException exception)
        {
            if (Result)
                throw exception ?? throw new ExceptionIsNullException(typeof(TException));
            return Source;
        }

        /// <inheritdoc />
        IThrowOption<TSource> IConditionResultOption<TSource>.Throw()
            => this;

        private TException CreateDefault<TException>(DefaultMessage defaultMessage)
            where TException : Exception, new()
        {
            var exception = new TException();
            if (defaultMessage is null)
                return exception;

            var exceptionMessageField = typeof(TException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic);
            exceptionMessageField?.SetValue(exception, defaultMessage.ToString());
            throw exception;
        }

        #endregion

        #region ISourceObject

        /// <inheritdoc />
        object ISourceObject.Value => Source;

        #endregion

        #region IThrowOption<TSource>

        #region ArgumentException.

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Argument(string message)
            => Result ? throw new ArgumentException(message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Argument(string message, Exception innerException)
            => Result ? throw new ArgumentException(message, innerException) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Argument(string message, string paramName)
            => Result ? throw new ArgumentException(message, paramName) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Argument(string message, string paramName, Exception innerException)
            => Result ? throw new ArgumentException(message, paramName, innerException) : Source;

        #endregion

        #region ArgumentNullException.

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Null(string paramName)
            => Result ? throw new ArgumentNullException(paramName) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Null(string paramName, string message)
            => Result ? throw new ArgumentNullException(paramName, message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Null(string message, Exception innerException)
            => Result ? throw new ArgumentNullException(message, innerException) : Source;

        #endregion

        #region ArgumentOutOfRangeException.

        /// <inheritdoc />
        TSource IThrowOption<TSource>.OutOfRange(string paramName)
            => Result ? throw new ArgumentOutOfRangeException(paramName) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.OutOfRange(string paramName, string message)
            => Result ? throw new ArgumentOutOfRangeException(paramName, message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.OutOfRange(string paramName, object actualValue, string message)
            => Result ? throw new ArgumentOutOfRangeException(paramName, actualValue, message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.OutOfRange(string message, Exception innerException)
            => Result ? throw new ArgumentOutOfRangeException(message, innerException) : Source;

        #endregion

        #region InvalidOperationException.

        /// <inheritdoc />
        TSource IThrowOption<TSource>.InvalidOperation(string message)
            => Result ? throw new InvalidOperationException(message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.InvalidOperation(string message, Exception innerException)
            => Result ? throw new InvalidOperationException(message, innerException) : Source;

        #endregion

        #region Exception.

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Exception(string message)
            => Result ? throw new Exception(message) : Source;

        /// <inheritdoc />
        TSource IThrowOption<TSource>.Exception(string message, Exception innerException)
            => Result ? throw new Exception(message, innerException) : Source;

        #endregion

        #endregion

        #region ICastOption

        /// <inheritdoc />
        TTarget ICastOption.To<TTarget>(bool unboxBeforeCast)
        {
            if (Result)
            {
                return unboxBeforeCast
                    ? (TTarget)(dynamic)Source
                    : (TTarget)((ISourceObject)this).Value;
            }

            return default;
        }

        /// <inheritdoc />
        TTarget ICastOption.ToOrDefault<TTarget>(bool unboxBeforeCast)
        {
            try
            {
                return ((ICastOption)this).To<TTarget>(unboxBeforeCast);
            }
            catch
            {
                return default;
            }
        }

        #endregion

        #endregion
    }
}