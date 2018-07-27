namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.DoNot;
    using Core.Interfaces.ChainableConditions.Nullable.Not;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableCondition{TSource}" />
    /// <inheritdoc cref="IChainableDoNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    internal sealed class ChainableCondition<TSource>
        : ChainableConditionBase<TSource, IChainableCondition<TSource>, IChainableNotCondition<TSource>, IChainableDoNotCondition<TSource>>,
          IChainableCondition<TSource>,
          IChainableDoNotCondition<TSource>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        internal ChainableCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableCondition<TSource> Condition => this;

        /// <inheritdoc />
        protected override IChainableNotCondition<TSource> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableDoNotCondition<TSource> DoNotCondition => this;
    }
}