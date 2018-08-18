namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.Couplers;
    using Extensions;
    using Interfaces.ChainableConditions.Base.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableComparableDoesNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <summary>
    /// The <see cref="ChainableNullableComparableStructConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable struct.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructCondition">The type of the chainable nullable comparable struct condition.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructNotCondition">The type of the chainable nullable comparable struct not condition.</typeparam>
    /// <typeparam name="TChainableNullableComparableStructDoesNotCondition">The type of the chainable nullable comparable struct does not condition.</typeparam>
    internal abstract class ChainableNullableComparableStructConditionBase<TSource, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoesNotCondition>
        : ChainableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoesNotCondition>,
          IChainableComparableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoesNotCondition>,
          IChainableComparableDoesNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
        where TSource : struct, IComparable<TSource>
        where TChainableNullableComparableStructCondition : IChainableComparableConditionBase<TSource?, TChainableNullableComparableStructCondition, TChainableNullableComparableStructNotCondition, TChainableNullableComparableStructDoesNotCondition>
        where TChainableNullableComparableStructNotCondition : IChainableComparableNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
        where TChainableNullableComparableStructDoesNotCondition : IChainableComparableDoesNotConditionBase<TSource?, TChainableNullableComparableStructCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableComparableStructConditionBase{TSource,TChainableNullableComparableStructCondition,TChainableNullableComparableStructNotCondition,TChainableNullableComparableStructDoesNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The comparable source object.</param>
        protected ChainableNullableComparableStructConditionBase(TSource? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> WithinRange(TSource? min, TSource? max)
            => Evaluate(s => s.WithinRange(min, max));

        /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
        public new IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> EqualTo(TSource? other)
            => Evaluate(s => s.EqualTo(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> LessThan(TSource? other)
            => Evaluate(s => s.LessThan(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> LessThanEqualTo(TSource? other)
            => Evaluate(s => s.LessThanOrEqualTo(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> GreaterThan(TSource? other)
            => Evaluate(s => s.GreaterThan(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource?, TChainableNullableComparableStructCondition> GreaterThanEqualTo(TSource? other)
            => Evaluate(s => s.GreaterThanOrEqualTo(other));
    }
}