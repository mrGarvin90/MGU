namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Core.Extensions.Is;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.Couplers;
    using Couplers;
    using Interfaces.ChainableConditions.Base.DoesNot;

    /// <inheritdoc cref="ConditionCoupler{TSource,TChainableCondition}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableDoesNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The <see cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    /// <typeparam name="TChainableNotCondition">The type of the chainable not condition.</typeparam>
    /// <typeparam name="TChainableDoesNotCondition">The type of the chainable does not condition.</typeparam>
    internal abstract class ChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoesNotCondition>
        : ConditionCoupler<TSource, TChainableCondition>,
          IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoesNotCondition>,
          IChainableDoesNotConditionBase<TSource, TChainableCondition>,
          IChainableNullableNotConditionBase<TSource, TChainableCondition>
        where TChainableCondition : IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoesNotCondition>
        where TChainableNotCondition : IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableDoesNotCondition : IChainableDoesNotConditionBase<TSource, TChainableCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ChainableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public TChainableNotCondition Not => SetInvertResultToTrue(NotCondition);

        /// <inheritdoc />
        public TChainableDoesNotCondition DoesNot => SetInvertResultToTrue(DoesNotCondition);

        /// <inheritdoc />
        public virtual IConditionCoupler<TSource, TChainableCondition> Null => Evaluate(s => s == null);

        /// <summary>
        /// Gets or sets a value indicating whether the result of the next condition should be inverted.
        /// </summary>
        protected bool InvertResult { get; set; }

        /// <summary>
        /// Gets the not condition where the result of the conditions will be inverted.
        /// </summary>
        protected abstract TChainableNotCondition NotCondition { get; }

        /// <summary>
        /// Gets the does not condition.
        /// </summary>
        protected abstract TChainableDoesNotCondition DoesNotCondition { get; }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Fulfills(Func<TSource, bool> condition)
        {
            return Evaluate(condition);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Fulfill(Func<TSource, bool> condition)
        {
            return Fulfills(condition);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> EqualTo(TSource other)
        {
            return Evaluate(s => s.Is(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Type<T>()
        {
            return Evaluate(s => s == null ? typeof(T) == typeof(TSource) : s is T);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> In(IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null)
        {
            return Evaluate(s => collection?.Contains(s, comparer) ?? false);
        }

        /// <summary>
        /// Evaluates the specified <paramref name="condition"/>.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        protected IConditionCoupler<TSource, TChainableCondition> Evaluate(Func<TSource, bool> condition, [CallerMemberName]string callerMemberName = "")
        {
            var invertResult = InvertResult;
            InvertResult = false;
            return Evaluate(condition, invertResult, callerMemberName);
        }

        private TCoupling SetInvertResultToTrue<TCoupling>(TCoupling coupling, [CallerMemberName] string callerMemberName = "")
            where TCoupling : IChainableConditionBase
        {
            InvertResult = true;
            return Couple(coupling, callerMemberName);
        }
    }
}