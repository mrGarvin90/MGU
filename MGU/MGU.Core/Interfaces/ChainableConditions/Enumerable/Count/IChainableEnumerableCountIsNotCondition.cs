namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.Count
{
    using System.Collections.Generic;
    using Base;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable count conditions for all objects that implement <see cref="IEnumerable{TObject}"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableCountIsNotCondition<TSource, out TObject, out TChainableEnumerableCondition> : IChainableConditionBase
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject>
    {
        /// <summary>
        /// Determines whether the number of elements in the source enumerable is within the specified range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source enumerable is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> WithinRange(int min, int max);
    }
}