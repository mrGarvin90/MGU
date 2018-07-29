namespace MGU.Core.Interfaces.ChainableConditions.Base.DoesNot
{
    using System.Collections.Generic;
    using Couplers;

    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject}"/>
    /// <inheritdoc cref="IChainableDoesNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for enumerable objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableDoesNotConditionBase<TSource, TObject, out TChainableEnumerableCondition>
        : IChainableEnumerableConditionBase<TSource, TObject>,
          IChainableDoesNotConditionBase<TSource, TChainableEnumerableCondition>
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableConditionBase
    {
        /// <summary>
        /// Determines whether the source enumerable does not contain the specified value by comparing it with the other elements using the specified <paramref name="comparer"/>
        /// or the default <see cref="IEqualityComparer{TObject}"/> if the specified <paramref name="comparer"/> is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableEnumerableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source enumerable is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> Contain(TObject value, IEqualityComparer<TObject> comparer = null);
    }
}