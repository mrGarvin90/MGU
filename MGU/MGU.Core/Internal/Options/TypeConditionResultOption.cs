namespace MGU.Core.Internal.Options
{
    using System;
    using System.Linq;
    using Core.Helpers;
    using Interfaces.Options;

    /// <inheritdoc cref="ConditionResultOption{TTarget}" />
    /// <inheritdoc cref="ITypeConditionResultOption{TTarget}" />
    /// <summary>
    /// The <see cref="TypeConditionResultOption{TSource,TTarget}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    internal sealed class TypeConditionResultOption<TSource, TTarget>
        : ConditionResultOption<TTarget>,
          ITypeConditionResultOption<TTarget>
    {
        private readonly TSource _source;
        private readonly IConditionResultOption<TTarget> _base;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeConditionResultOption{TSource, TTarget}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="castSourceObject">
        /// If set to <c>true</c> the source object will be cast to <typeparamref name="TTarget"/>.
        /// </param>
        internal TypeConditionResultOption(TSource source, bool castSourceObject)
            : base(default, castSourceObject)
        {
            _source = source;
            _base = this;
        }

        /// <inheritdoc />
        public TTarget Cast() => Result ? (TTarget)(object)_source : default;

        /// <inheritdoc />
        public TTarget Get(Func<TTarget> func)
            => _base.Get(func);

        /// <inheritdoc />
        public TTarget Invoke(Action action, params Action[] actions)
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
            return (TTarget)(object)_source;
        }

        /// <inheritdoc />
        public TTarget Set(ref TTarget other)
        {
            if (!Result)
                return Source;
            return other = (TTarget)(object)_source;
        }

        /// <inheritdoc />
        public TTarget Then(TTarget value)
            => _base.Then(value);

        /// <inheritdoc />
        public TTarget Throw<TException>(params object[] parameters)
            where TException : Exception
            => _base.Throw<TException>(parameters);

        /// <inheritdoc />
        public TTarget Throw<TException>(Type[] parameterTypes, object[] parameters)
            where TException : Exception
            => _base.Throw<TException>(parameterTypes, parameters);

        /// <inheritdoc />
        public TTarget ThrowOrDefault<TException>(DefaultMessage defaultMessage, params object[] parameters)
            where TException : Exception, new()
            => _base.ThrowOrDefault<TException>(defaultMessage, parameters);

        /// <inheritdoc />
        public TTarget ThrowOrDefault<TException>(DefaultMessage defaultMessage, Type[] parameterTypes, object[] parameters)
            where TException : Exception, new()
            => _base.ThrowOrDefault<TException>(defaultMessage, parameterTypes, parameters);

        /// <inheritdoc />
        public TTarget Throw<TException>(TException exception)
            where TException : Exception
            => _base.Throw(exception);

        /// <inheritdoc />
        public IThrowOption<TTarget> Throw()
            => this;
    }
}