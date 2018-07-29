namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.DoNot
{
    using System.Collections.Generic;
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all objects that implement <see cref="IEnumerable{TObject}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object in the source enumerable.</typeparam>
    public interface IChainableEnumerableDoNotCondition<TSource, TObject> : IChainableEnumerableDoNotConditionBase<TSource, TObject, IChainableEnumerableCondition<TSource, TObject>>
        where TSource : IEnumerable<TObject>
    {
    }
}