namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.Not;
    using Interfaces.ChainableConditions.Nullable.DoesNot;

    /// <inheritdoc cref="ChainableNullableComparableStructConditionBase{TSource,TChainableNullableComparableStructCondition,TChainableNullableComparableStructNotCondition,TChainableNullableComparableStructDoesNotCondition}" />
    /// <inheritdoc cref="IChainableNullableComparableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableNullableComparableStructDoesNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableNullableComparableStructCondition{TCTComparable}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable struct.</typeparam>
    internal sealed class ChainableNullableComparableStructCondition<TSource>
        : ChainableNullableComparableStructConditionBase<TSource, IChainableNullableComparableStructCondition<TSource>, IChainableNullableComparableStructNotCondition<TSource>, IChainableNullableComparableStructDoesNotCondition<TSource>>,
          IChainableNullableComparableStructCondition<TSource>,
          IChainableNullableComparableStructDoesNotCondition<TSource>
        where TSource : struct, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableComparableStructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The nullable comparable source object.</param>
        internal ChainableNullableComparableStructCondition(TSource? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableNullableComparableStructCondition<TSource> Condition => this;

        /// <inheritdoc />
        protected override IChainableNullableComparableStructNotCondition<TSource> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableNullableComparableStructDoesNotCondition<TSource> DoesNotCondition => this;
    }
}