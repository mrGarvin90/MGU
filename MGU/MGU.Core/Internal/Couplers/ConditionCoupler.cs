namespace MGU.Core.Internal.Couplers
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
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
        private readonly StringBuilder _traceBuilder;
        private readonly TSource _source;
        private LogicalOperator? _logicalOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionCoupler{TSource,TChainableCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ConditionCoupler(TSource source)
        {
            _traceBuilder = new StringBuilder().AppendLine(typeof(TChainableCondition).Name.Remove(0, 1)).AppendLine("If");
            _logicalOperator = null;
            _source = source;
            Result = false;
        }

        /// <inheritdoc />
        public bool Result { get; protected set; }

        /// <inheritdoc />
        public TChainableCondition And => SetOrder(LogicalOperator.And);

        /// <inheritdoc />
        public virtual TChainableCondition Or => SetOrder(LogicalOperator.Or);

        /// <summary>
        /// Gets the condition.
        /// </summary>
        protected abstract TChainableCondition Condition { get; }

        /// <summary>
        /// Evaluates the specified <paramref name="condition"/> and sets the <see cref="Result"/>.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="invertConditionResult">Indicates whether the result of the condition should be inverted.</param>
        /// <param name="callerMemberName">The name of the caller member.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="ConditionEvaluationFailedException">
        /// The specified <paramref name="condition"/> could not be evaluated.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// A value of <see cref="LogicalOperator"/> is not implemented.
        /// </exception>
        internal IConditionCoupler<TSource, TChainableCondition> Evaluate(Func<TSource, bool> condition, bool invertConditionResult, [CallerMemberName]string callerMemberName = "")
        {
            _traceBuilder.Append(callerMemberName).Append(" --> ");
            try
            {
                switch (_logicalOperator)
                {
                    case null:
                        Result = EvaluateCondition();
                        break;
                    case LogicalOperator.And:
                        Result = Result && EvaluateCondition();
                        break;
                    case LogicalOperator.Or:
                        if (Result)
                            _traceBuilder.AppendLine("Not evaluated");
                        else
                            Result = EvaluateCondition();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_logicalOperator), _logicalOperator, "Value is not implemented.");
                }
            }
            catch (Exception exception)
            {
                _traceBuilder.Append("threw an exception");
                throw new ConditionEvaluationFailedException(typeof(TSource), _source, _traceBuilder.ToString(), exception);
            }

            return this;

            bool EvaluateCondition()
            {
                var result = invertConditionResult ? !condition(_source) : condition(_source);
                _traceBuilder.AppendLine(result.ToString());
                return result;
            }
        }

        /// <summary>
        /// Appends the caller member name to the trace builder and returns the <paramref name="coupling"/>.
        /// </summary>
        /// <typeparam name="TCoupling">The type of the coupling.</typeparam>
        /// <param name="coupling">The coupling.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns>The <paramref name="coupling"/>.</returns>
        protected TCoupling Couple<TCoupling>(TCoupling coupling, [CallerMemberName]string callerMemberName = "")
            where TCoupling : IChainableConditionBase
        {
            _traceBuilder.Append(callerMemberName).Append(" ");
            return coupling;
        }

        private TChainableCondition SetOrder(LogicalOperator order)
        {
            _logicalOperator = order;
            _traceBuilder.AppendLine(_logicalOperator.ToString());
            return Condition;
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