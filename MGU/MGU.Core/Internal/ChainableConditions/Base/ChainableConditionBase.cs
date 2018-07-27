namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Core.Extensions.Is;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.DoNot;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.Couplers;
    using Couplers;

    /// <inheritdoc cref="ConditionCoupler{TSource,TChainableCondition}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableDoNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The <see cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    /// <typeparam name="TChainableNotCondition">The type of the chainable not condition.</typeparam>
    /// <typeparam name="TChainableDoNotCondition">The type of the chainable do not condition.</typeparam>
    internal abstract class ChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoNotCondition>
        : ConditionCoupler<TSource, TChainableCondition>,
          IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoNotCondition>,
          IChainableDoNotConditionBase<TSource, TChainableCondition>,
          IChainableNullableNotConditionBase<TSource, TChainableCondition>
        where TChainableCondition : IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoNotCondition>
        where TChainableNotCondition : IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableDoNotCondition : IChainableDoNotConditionBase<TSource, TChainableCondition>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ChainableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the result of the next condition should be inverted.
        /// </summary>
        protected bool InvertResult { get; set; }

        /// <summary>
        /// Gets the not condition where the result of the conditions will be inverted.
        /// </summary>
        protected abstract TChainableNotCondition NotCondition { get; }

        /// <summary>
        /// Gets the do not condition.
        /// </summary>
        protected abstract TChainableDoNotCondition DoNotCondition { get; }

        /// <inheritdoc />
        public TChainableNotCondition Not => SetInvertResultToTrue(NotCondition);

        /// <inheritdoc />
        public TChainableDoNotCondition DoNot => SetInvertResultToTrue(DoNotCondition);

        /// <inheritdoc />
        public virtual IConditionCoupler<TSource, TChainableCondition> Null => SetResult(s => s == null);

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Fulfills(Func<TSource, bool> condition)
        {
            return SetResult(condition);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Fulfill(Func<TSource, bool> condition)
        {
            return Fulfills(condition);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> EqualTo(TSource other)
        {
            return SetResult(s => s.Is(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> Type<T>()
        {
            return SetResult(s => s == null ? typeof(T) == typeof(TSource) : s is T);
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableCondition> In(IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null)
        {
            return SetResult(s => collection?.Contains(s, comparer) ?? false);
        }

        /// <summary>
        /// Sets the Result property on <see cref="IConditionCoupler{TSource,TChainableCondition}"/>.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        protected IConditionCoupler<TSource, TChainableCondition> SetResult(Func<TSource, bool> condition, [CallerMemberName]string callerMemberName = "")
        {
            var invertResult = InvertResult;
            InvertResult = false;
            return base.Evaluate(condition, invertResult, callerMemberName);
        }

        private TCoupling SetInvertResultToTrue<TCoupling>(TCoupling coupling, [CallerMemberName] string callerMemberName = "")
            where TCoupling : IChainableConditionBase
        {
            InvertResult = true;
            return Couple(coupling, callerMemberName);
        }
    }
}