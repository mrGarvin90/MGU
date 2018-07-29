namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using System;
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.DoNot;
    using Core.Interfaces.ChainableConditions.Struct.Not;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <inheritdoc cref="IChainableComparableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableStructDoNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableComparableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    internal sealed class ChainableComparableStructCondition<TSource>
        : ChainableComparableConditionBase<TSource, IChainableComparableStructCondition<TSource>, IChainableComparableStructNotCondition<TSource>, IChainableComparableStructDoNotCondition<TSource>>,
          IChainableComparableStructCondition<TSource>,
          IChainableComparableStructDoNotCondition<TSource>
        where TSource : struct, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableComparableStructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The comparable source struct.</param>
        internal ChainableComparableStructCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableComparableStructCondition<TSource> Condition => this;

        /// <inheritdoc />
        protected override IChainableComparableStructNotCondition<TSource> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableComparableStructDoNotCondition<TSource> DoNotCondition => this;
    }
}