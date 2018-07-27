namespace MGU.Core.Interfaces.ChainableConditions.Enumerable
{
    using System.Collections.Generic;
    using Base;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableEnumerableNotCondition{TSource, TObject}" />
    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for all objects that implement <see cref="IEnumerable{TObject}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object in the source enumerable.</typeparam>
    public interface IChainableEnumerableCondition<TSource, TObject>
        : IChainableEnumerableNotCondition<TSource, TObject>,
          IChainableEnumerableConditionBase<TSource, TObject, IChainableEnumerableCondition<TSource, TObject>, IChainableEnumerableNotCondition<TSource, TObject>, IChainableEnumerableDoNotCondition<TSource, TObject>>
        where TSource : IEnumerable<TObject>
    {
    }
}