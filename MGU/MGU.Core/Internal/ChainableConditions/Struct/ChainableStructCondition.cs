namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Interfaces.ChainableConditions.Struct.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableStructCondition{TSource}" />
    /// <inheritdoc cref="IChainableStructDoesNotCondition{TSource}" />
    /// <summary>
    /// The <see cref="ChainableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source struct.</typeparam>
    internal sealed class ChainableStructCondition<TSource>
        : ChainableConditionBase<TSource, IChainableStructCondition<TSource>, IChainableStructNotCondition<TSource>, IChainableStructDoesNotCondition<TSource>>,
          IChainableStructCondition<TSource>,
          IChainableStructDoesNotCondition<TSource>
        where TSource : struct
    {
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
        protected override IChainableStructDoesNotCondition<TSource> DoesNotCondition => this;
    }
}