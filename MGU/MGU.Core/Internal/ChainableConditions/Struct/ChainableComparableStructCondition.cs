namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using System;
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Interfaces.ChainableConditions.Struct.DoesNot;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableComparableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableStructDoesNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableComparableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    internal sealed class ChainableComparableStructCondition<TSource>
        : ChainableComparableConditionBase<TSource, IChainableComparableStructCondition<TSource>, IChainableComparableStructNotCondition<TSource>, IChainableComparableStructDoesNotCondition<TSource>>,
          IChainableComparableStructCondition<TSource>,
          IChainableComparableStructDoesNotCondition<TSource>
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
        protected override IChainableComparableStructDoesNotCondition<TSource> DoesNotCondition => this;
    }
}