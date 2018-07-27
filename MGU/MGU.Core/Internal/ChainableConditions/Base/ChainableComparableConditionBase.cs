namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.DoNot;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.Couplers;
    using Extensions;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <inheritdoc cref="IChainableComparableDoNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <summary>
    /// The <see cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source object.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    /// <typeparam name="TChainableComparableNotCondition">The type of the chainable comparable not condition.</typeparam>
    /// <typeparam name="TChainableComparableDoNotCondition">The type of the chainable comparable do not condition.</typeparam>
    internal abstract class ChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>
        : ChainableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>,
          IChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>,
          IChainableComparableDoNotConditionBase<TSource, TChainableComparableCondition>
        where TSource : IComparable<TSource>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>
        where TChainableComparableNotCondition : IChainableComparableNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableDoNotCondition : IChainableComparableDoNotConditionBase<TSource, TChainableComparableCondition>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The comparable source object.</param>
        protected ChainableComparableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> WithinRange(TSource min, TSource max)
        {
            return SetResult(s => s.WithinRange(min, max));
        }

        /// <inheritdoc cref="IChainableComparableConditionBase{TSource}" />
        public new IConditionCoupler<TSource, TChainableComparableCondition> EqualTo(TSource other)
        {
            return SetResult(s => s.EqualTo(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> LessThan(TSource other)
        {
            return SetResult(s => s.LessThan(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> LessThanEqualTo(TSource other)
        {
            return SetResult(s => s.LessThanOrEqualTo(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> GreaterThan(TSource other)
        {
            return SetResult(s => s.GreaterThan(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> GreaterThanEqualTo(TSource other)
        {
            return SetResult(s => s.GreaterThanOrEqualTo(other));
        }
    }
}