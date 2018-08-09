namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.Count
{
    using System.Collections.Generic;
    using Base;
    using Couplers;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable count conditions for all objects that implement <see cref="IEnumerable{TObject}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableCountIsCondition<TSource, out TObject, out TChainableEnumerableCondition> : IChainableEnumerableCountIsNotCondition<TSource, TObject, TChainableEnumerableCondition>
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject>
    {
        /// <summary>
        /// Gets the count is not conditions where the result of the conditions will be inverted.
        /// </summary>
        /// <returns><see cref="IChainableEnumerableCountIsNotCondition{TSource,TObject,TChainableEnumerableCondition}"/></returns>
        IChainableEnumerableCountIsNotCondition<TSource, TObject, TChainableEnumerableCondition> Not { get; }

        /// <summary>
        /// Determines whether the number of elements in the source enumerable is less than the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The number of elements in source enumerable is larger than <see cref="F:System.Int32.MaxValue"/>.
        /// Inner exception: <see cref="System.OverflowException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> LessThan(int value);

        /// <summary>
        /// Determines whether the number of elements in the source enumerable is less than or equal to the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The number of elements in source enumerable is larger than <see cref="F:System.Int32.MaxValue"/>.
        /// Inner exception: <see cref="System.OverflowException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> LessThanEqualTo(int value);

        /// <summary>
        /// Determines whether the number of elements in the source enumerable is greater than the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The number of elements in source enumerable is larger than <see cref="F:System.Int32.MaxValue"/>.
        /// Inner exception: <see cref="System.OverflowException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> GreaterThan(int value);

        /// <summary>
        /// Determines whether the number of elements in the source enumerable is greater than or equal to the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The number of elements in source enumerable is larger than <see cref="F:System.Int32.MaxValue"/>.
        /// Inner exception: <see cref="System.OverflowException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> GreaterThanEqualTo(int value);
    }
}