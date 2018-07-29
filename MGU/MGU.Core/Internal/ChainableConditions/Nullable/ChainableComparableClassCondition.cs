namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.DoNot;
    using Core.Interfaces.ChainableConditions.Nullable.Not;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <inheritdoc cref="IChainableComparableClassCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableClassDoNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableComparableClassCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable class.</typeparam>
    internal sealed class ChainableComparableClassCondition<TSource>
        : ChainableComparableConditionBase<TSource, IChainableComparableClassCondition<TSource>, IChainableComparableClassNotCondition<TSource>, IChainableComparableClassDoNotCondition<TSource>>,
          IChainableComparableClassCondition<TSource>,
          IChainableComparableClassDoNotCondition<TSource>
        where TSource : class, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableComparableClassCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The comparable source class.</param>
        internal ChainableComparableClassCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableComparableClassCondition<TSource> Condition => this;

        /// <inheritdoc />
        protected override IChainableComparableClassNotCondition<TSource> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableComparableClassDoNotCondition<TSource> DoNotCondition => this;
    }
}