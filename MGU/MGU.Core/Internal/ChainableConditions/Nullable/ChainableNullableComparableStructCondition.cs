namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.DoNot;
    using Core.Interfaces.ChainableConditions.Nullable.Not;

    /// <inheritdoc cref="ChainableNullableComparableStructConditionBase{TSource,TChainableNullableComparableStructCondition,TChainableNullableComparableStructNotCondition,TChainableNullableComparableStructDoNotCondition}" />
    /// <inheritdoc cref="IChainableNullableComparableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableNullableComparableStructDoNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableNullableComparableStructCondition{TCTComparable}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable struct.</typeparam>
    internal sealed class ChainableNullableComparableStructCondition<TSource>
        : ChainableNullableComparableStructConditionBase<TSource, IChainableNullableComparableStructCondition<TSource>, IChainableNullableComparableStructNotCondition<TSource>, IChainableNullableComparableStructDoNotCondition<TSource>>,
          IChainableNullableComparableStructCondition<TSource>,
          IChainableNullableComparableStructDoNotCondition<TSource>
        where TSource : struct, IComparable<TSource>
    {
        /// <inheritdoc />
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
        protected override IChainableNullableComparableStructDoNotCondition<TSource> DoNotCondition => this;
    }
}