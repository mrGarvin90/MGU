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
    /// The <see cref="ChainableNullableComparableStructConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable struct.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructCondition">The type of the chainable nullable comparable struct condition.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructNotCondition">The type of the chainable nullable comparable struct not condition.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructDoNotCondition">The type of the chainable nullable comparable struct do not condition.</typeparam>
    internal abstract class ChainableNullableComparableStructConditionBase<TSource, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoNotCondition>
        : ChainableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoNotCondition>,
          IChainableComparableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoNotCondition>,
          IChainableComparableDoNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
        where TSource : struct, IComparable<TSource>
        where TChainableNullableComparableStructCondition : IChainableComparableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoNotCondition>
        where TChainableNullableComparableStructNotCondition : IChainableComparableNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
        where TChainableNullableComparableStructDoNotCondition : IChainableComparableDoNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableComparableStructConditionBase{TSource,TChainableNullableComparableStructCondition,TChainableNullableComparableStructNotCondition,TChainableNullableComparableStructDoNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The comparable source object.</param>
        /// <inheritdoc />
        protected ChainableNullableComparableStructConditionBase(TSource? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> WithinRange(TSource? min, TSource? max)
        {
            return SetResult(s => s.WithinRange(min, max));
        }

        /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
        public new IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> EqualTo(TSource? other)
        {
            return SetResult(s => s.EqualTo(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> LessThan(TSource? other)
        {
            return SetResult(s => s.LessThan(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> LessThanEqualTo(TSource? other)
        {
            return SetResult(s => s.LessThanOrEqualTo(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> GreaterThan(TSource? other)
        {
            return SetResult(s => s.GreaterThan(other));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> GreaterThanEqualTo(TSource? other)
        {
            return SetResult(s => s.GreaterThanOrEqualTo(other));
        }
    }
}