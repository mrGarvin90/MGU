namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.Count
{
    using System.Collections.Generic;
    using Base;
    using Couplers;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable count conditions for all objects that implement <see cref="IEnumerable{TObject}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableCountIsNotCondition<TSource, out TObject, out TChainableEnumerableCondition> : IChainableConditionBase<TSource>
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
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The number of elements in source enumerable is larger than <see cref="F:System.Int32.MaxValue"/>.
        /// Inner exception: <see cref="System.OverflowException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> WithinRange(int min, int max);
    }
}