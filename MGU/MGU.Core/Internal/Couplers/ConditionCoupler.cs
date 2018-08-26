namespace MGU.Core.Internal.Couplers
{
    using System;
    using System.Linq;
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

    /// <inheritdoc cref="ConditionResultOption{TSource}" />
    /// <inheritdoc cref="IConditionCoupler{TSource,TChainableCondition}" />
    /// <summary>
    /// The <see cref="ConditionCoupler{TSource,TChainableCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    internal abstract class ConditionCoupler<TSource, TChainableCondition>
        : ConditionResultOption<TSource>,
          IConditionCoupler<TSource, TChainableCondition>,
          IConditionEvaluator
        where TChainableCondition : IChainableConditionBase<TSource>
    {
        private LogicalOperator? _logicalOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionCoupler{TSource,TChainableCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ConditionCoupler(TSource source)
            : base(source, false)
        {
            _logicalOperator = null;
        }

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
                        Result = InvertConditionResult ? !condition(Source) : condition(Source);
                        break;
                    case LogicalOperator.And:
                        Result = Result && (InvertConditionResult ? !condition(Source) : condition(Source));
                        break;
                    case LogicalOperator.Or:
                        Result = Result || (InvertConditionResult ? !condition(Source) : condition(Source));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_logicalOperator), _logicalOperator, "Value is not implemented.");
                }

                InvertConditionResult = false;
                return this;
            }
            catch (Exception exception)
            {
                throw new ConditionEvaluationFailedException(typeof(TChainableCondition), callerMemberName, typeof(TSource), Source, exception);
            }
        }

        #region IConditionEvaluator

#pragma warning disable SA1202 // Elements must be ordered by access

        /// <inheritdoc />
        bool IConditionEvaluator.Evaluate(bool condition)
        {
            switch (_logicalOperator)
            {
                case null:
                    return InvertConditionResult ? !condition : condition;
                case LogicalOperator.And:
                    return Result && (InvertConditionResult ? !condition : condition);
                case LogicalOperator.Or:
                    return Result || (InvertConditionResult ? !condition : condition);
                default:
                    throw new ArgumentOutOfRangeException(nameof(_logicalOperator), _logicalOperator, "Value is not implemented.");
            }
        }

        #endregion
    }
}