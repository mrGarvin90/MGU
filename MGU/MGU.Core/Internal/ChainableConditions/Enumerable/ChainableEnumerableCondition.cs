namespace MGU.Core.Internal.ChainableConditions.Enumerable
{
    using System.Collections.Generic;
    using Base;
    using Core.Interfaces.ChainableConditions.Enumerable;
    using Core.Interfaces.ChainableConditions.Enumerable.DoNot;
    using Core.Interfaces.ChainableConditions.Enumerable.Not;

    /// <inheritdoc cref="ChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition, TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableEnumerableCondition{TSource,TObject}" />
    /// <inheritdoc cref="IChainableEnumerableDoNotCondition{TSource,TObject}" />
    /// <summary>
    /// The <see cref="ChainableEnumerableCondition{TSource, TObject}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the enumerable source object.</typeparam>
    /// <typeparam name="TObject">The type of the object that enumerable source object contains.</typeparam>
    internal sealed class ChainableEnumerableCondition<TSource, TObject>
        : ChainableEnumerableConditionBase<TSource, TObject, IChainableEnumerableCondition<TSource, TObject>, IChainableEnumerableNotCondition<TSource, TObject>, IChainableEnumerableDoNotCondition<TSource, TObject>>,
          IChainableEnumerableCondition<TSource, TObject>,
          IChainableEnumerableDoNotCondition<TSource, TObject>
        where TSource : IEnumerable<TObject>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableEnumerableCondition{TSource, TObject}"/> class.
        /// </summary>
        /// <param name="source">The enumerable source object.</param>
        internal ChainableEnumerableCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableEnumerableNotCondition<TSource, TObject> NotCondition => this;

        /// <inheritdoc />
        protected override IChainableEnumerableCondition<TSource, TObject> Condition => this;

        /// <inheritdoc />
        protected override IChainableEnumerableDoNotCondition<TSource, TObject> DoNotCondition => this;
    }
}