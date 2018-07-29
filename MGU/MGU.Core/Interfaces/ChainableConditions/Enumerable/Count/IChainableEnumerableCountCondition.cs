namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.Count
{
    using System.Collections.Generic;
    using Base;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable count conditions for all objects that implement <see cref="IEnumerable{TObject}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableCountCondition<TSource, out TObject, out TChainableEnumerableCondition> : IChainableConditionBase
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject>
    {
        /// <summary>
        /// Gets the count is condition.
        /// </summary>
        /// <returns><see cref="IChainableEnumerableCountIsCondition{TSource,TObject,TChainableEnumerableCondition}"/></returns>
        IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition> Is { get; }
    }
}