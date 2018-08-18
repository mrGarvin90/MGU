namespace MGU.Core.Internal.Couplers
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Core.Extensions.Cast;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.Couplers;
    using Core.Interfaces.Options;
    using Enums;
    using Exceptions;
    using Helpers;
    using Options;

    /// <inheritdoc />
    /// <summary>
    /// The <see cref="ConditionCoupler{TSource,TChainableCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    internal abstract class ConditionCoupler<TSource, TChainableCondition> : IConditionCoupler<TSource, TChainableCondition>
        where TChainableCondition : IChainableConditionBase
    {
        private readonly TSource _source;
        private LogicalOperator? _logicalOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionCoupler{TSource,TChainableCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ConditionCoupler(TSource source)
        {
            _logicalOperator = null;
            _source = source;
            Result = false;
        }

        /// <inheritdoc />
        public bool Result { get; protected set; }

        /// <inheritdoc />
        public virtual TChainableCondition And
        {
            get
            {
                _logicalOperator = LogicalOperator.And;
                return Condition;
            }
        }

        /// <inheritdoc />
        public virtual TChainableCondition Or
        {
            get
            {
                _logicalOperator = LogicalOperator.Or;
                return Condition;
            }
        }

        /// <summary>
        /// Gets the condition.
        /// </summary>
        protected abstract TChainableCondition Condition { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the result of the next condition should be inverted.
        /// </summary>
        protected bool InvertConditionResult { get; set; }

        /// <summary>
        /// Evaluates the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="ConditionEvaluationFailedException">
        /// <paramref name="condition"/> could not be evaluated.
        /// Inner exception: Cannot specify.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// A value of <see cref="LogicalOperator"/> is not implemented.
        /// </exception>
        internal IConditionCoupler<TSource, TChainableCondition> Evaluate(Func<TSource, bool> condition, [CallerMemberName]string callerMemberName = "")
        {
            try
            {
                switch (_logicalOperator)
                {
                    case null:
                        Result = InvertConditionResult ? !condition(_source) : condition(_source);
                        break;
                    case LogicalOperator.And:
                        Result = Result && (InvertConditionResult ? !condition(_source) : condition(_source));
                        break;
                    case LogicalOperator.Or:
                        Result = Result || (InvertConditionResult ? !condition(_source) : condition(_source));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_logicalOperator), _logicalOperator, "Value is not implemented.");
                }

                InvertConditionResult = false;
                return this;
            }
            catch (Exception exception)
            {
                throw new ConditionEvaluationFailedException(typeof(TChainableCondition), callerMemberName, typeof(TSource), _source, exception);
            }
        }

        #region IConditionResultOption

#pragma warning disable SA1201 // Elements must appear in the correct order
        /// <inheritdoc />
        ICastOption IConditionResultOption<TSource>.Cast => new CastOption(Result, _source);

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Invoke(Action action, params Action[] actions)
        {
            if (!Result)
                return _source;

            action();
            if (actions?.Length > 0)
            {
                foreach (var a in actions)
                    a();
            }

            return _source;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Get(Func<TSource> func)
            => Result ? func() : _source;

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Set(ref TSource other)
        {
            if (Result)
                other = _source;
            return _source;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Then(TSource value)
            => Result ? value : _source;

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Throw<TException>(params object[] exceptionParameters)
        {
            if (!Result)
                return _source;
            TException exception;
            try
            {
                exception = Activator.CreateInstance(typeof(TException), exceptionParameters).Cast().To<TException>();
            }
            catch (Exception innerException)
            {
                throw new CouldNotCreateInstanceException(typeof(TException), exceptionParameters, innerException);
            }

            throw exception;
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.ThrowOrDefault<TException>(DefaultMessage defaultMessage, params object[] exceptionParameters)
        {
            try
            {
                return ((IConditionResultOption<TSource>)this).Throw<TException>(exceptionParameters);
            }
            catch (CouldNotCreateInstanceException)
            {
                var exception = new TException();
                if (string.IsNullOrEmpty(defaultMessage.ToString()))
                    throw exception;

                var exceptionMessageField = typeof(TException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)
                                            ?? throw exception;
                var exceptionMessage = exceptionMessageField.GetValue(exception).Cast().ToOrDefault<string>();
                exceptionMessageField.SetValue(
                    exception,
                    string.IsNullOrEmpty(exceptionMessage) ? defaultMessage.ToString() : $"{exceptionMessage}{Environment.NewLine}{defaultMessage}");
                throw exception;
            }
        }

        /// <inheritdoc />
        TSource IConditionResultOption<TSource>.Throw<TException>(TException exception)
        {
            if (Result)
                throw exception ?? throw new ExceptionIsNullException(typeof(TException));
            return _source;
        }

        /// <inheritdoc />
        IThrowOption<TSource> IConditionResultOption<TSource>.Throw()
            => new ThrowOption<TSource>(Result, _source);

        #endregion
    }
}