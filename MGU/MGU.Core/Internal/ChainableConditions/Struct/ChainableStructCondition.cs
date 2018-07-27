namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.DoNot;
    using Core.Interfaces.ChainableConditions.Struct.Not;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableStructDoNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source struct.</typeparam>
    internal sealed class ChainableStructCondition<TSource>
        : ChainableConditionBase<TSource, IChainableStructCondition<TSource>, IChainableStructNotCondition<TSource>, IChainableStructDoNotCondition<TSource>>,
          IChainableStructCondition<TSource>,
          IChainableStructDoNotCondition<TSource>
        where TSource : struct
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableStructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source struct.</param>
        internal ChainableStructCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableStructCondition<TSource> Condition => this;

        /// <inheritdoc />
        protected override IChainableStructNotCondition<TSource> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableStructDoNotCondition<TSource> DoNotCondition => this;
    }
}