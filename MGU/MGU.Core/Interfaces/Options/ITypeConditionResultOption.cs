namespace MGU.Core.Interfaces.Options
{
    using System;
    using Helpers;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines options performed after the specified conditions are evaluated.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    /// <seealso cref="IConditionResultOption{TSource}" />
    public interface ITypeConditionResultOption<TTarget>
    {
        /// <summary>
        /// Gets the result of the evaluation of the specified conditions.
        /// </summary>
        bool Result { get; }

        /// <summary>
        /// Casts the source object to <typeparamref name="TTarget"/>
        /// if the specified conditions are met.
        /// </summary>
        /// <returns>
        /// The source object cast to <typeparamref name="TTarget"/>
        /// if the specified conditions are met;
        /// otherwise, the <see langword="default"/> value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget Cast();

        /// <summary>
        /// Invokes the function
        /// if the specified conditions are met.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>
        /// The value returned from the function
        /// if the specified conditions are met;
        /// otherwise, the <see langword="default"/> value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget Get([NotNull]Func<TTarget> func);

        /// <summary>
        /// Invokes the actions
        /// if the specified conditions are met.
        /// </summary>
        /// <param name="action">The first action.</param>
        /// <param name="actions">The other actions.</param>
        /// <returns>
        /// The source object cast to <typeparamref name="TTarget"/>
        /// if the specified conditions are met;
        /// otherwise, the <see langword="default"/> value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget Invoke([NotNull]Action action, [CanBeNull]params Action[] actions);

        /// <summary>
        /// Casts the source object to <typeparamref name="TTarget"/> and
        /// sets the <paramref name="other"/> to the source object
        /// if the specified conditions are met.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// The source object cast to <typeparamref name="TTarget"/>
        /// if the specified conditions are met;
        /// otherwise, the <see langword="default"/> value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget Set(ref TTarget other);

        /// <summary>
        /// Returns the <paramref name="value"/>
        /// if the specified conditions are met.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The specified <paramref name="value"/>
        /// if the specified conditions are met;
        /// otherwise, the <see langword="default"/> value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget Then(TTarget value);

        /// <summary>
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the parameters and throws that exception
        /// if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameters">The exception parameters.</param>
        /// <returns>The <see langword="default"/> value of <typeparamref name="TTarget"/>.</returns>
        /// <exception cref="Exceptions.CouldNotCreateInstanceException">
        /// An instance of <typeparamref name="TException"/> could not be created.
        /// Inner exception: See <see cref="Activator.CreateInstance(Type, object[])"/>.
        /// </exception>
        TTarget Throw<TException>(params object[] parameters)
            where TException : Exception;

        /// <summary>
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the parameter types and throws that exception
        /// if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameterTypes">The parameter types.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see langword="default"/> value of <typeparamref name="TTarget"/>.</returns>
        /// <remarks>
        /// <paramref name="parameterTypes"/> can be <see langword="null"/> or empty if
        /// <paramref name="parameters"/> is <see langword="null"/> or empty.
        /// </remarks>
        /// <exception cref="Exceptions.CouldNotCreateInstanceException">
        /// <paramref name="parameterTypes"/> is not valid.
        /// Inner exception: See <see cref="Type.GetConstructor(Type[])"/>.
        /// </exception>
        /// <exception cref="Exceptions.CouldNotCreateInstanceException">
        /// No public constructor was found that matches the specified parameter types.
        /// Inner exception: <see cref="ArgumentException"/>.
        /// </exception>
        /// <exception cref="Exceptions.CouldNotCreateInstanceException">
        /// Could not invoke constructor.
        /// Inner exception: See <see cref="System.Reflection.ConstructorInfo.Invoke(object[])"/>.
        /// </exception>
        TTarget Throw<TException>(Type[] parameterTypes, object[] parameters)
            where TException : Exception;

        /// <summary>
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the parameters, or the default constructor
        /// if no other constructor was found, and throws that exception
        /// if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="defaultMessage">
        /// The message that will be appended to the message of the default exception.
        /// </param>
        /// <param name="parameters">The exception parameters.</param>
        /// <returns>The <see langword="default"/> value of <typeparamref name="TTarget"/>.</returns>
        TTarget ThrowOrDefault<TException>([CanBeNull]DefaultMessage defaultMessage, params object[] parameters)
            where TException : Exception, new();

        /// <summary>
        /// Creates an instance of <typeparamref name="TException"/> using the public
        /// constructor that best matches the parameter types, or the default constructor
        /// if no other constructor was found, and throws that exception
        /// if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="defaultMessage">
        /// The default message that will be appended to the message of the default exception.
        /// </param>
        /// <param name="parameterTypes">The parameter types.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see langword="default"/> value of <typeparamref name="TTarget"/>.</returns>
        /// <remarks>
        /// <paramref name="parameterTypes"/> can be <see langword="null"/> or empty if
        /// <paramref name="parameters"/> is <see langword="null"/> or empty.
        /// </remarks>
        TTarget ThrowOrDefault<TException>([CanBeNull]DefaultMessage defaultMessage, Type[] parameterTypes, object[] parameters)
            where TException : Exception, new();

        /// <summary>
        /// Throws the <paramref name="exception"/>
        /// if the specified conditions are met.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns>The <see langword="default"/> value of <typeparamref name="TTarget"/>.</returns>
        /// <exception cref="Exceptions.ExceptionIsNullException">
        /// The <paramref name="exception"/> is <see langword="null"/>.
        /// </exception>
        TTarget Throw<TException>([NotNull]TException exception)
            where TException : Exception;

        /// <summary>
        /// Gets additional options for throwing exceptions
        /// if the specified conditions are met.
        /// </summary>
        /// <returns><see cref="IThrowOption{TSource}"/></returns>
        IThrowOption<TTarget> Throw();
    }
}