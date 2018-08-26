namespace MGU.Core.Interfaces.ChainableConditions.Base
{
    using System;
    using System.Collections.Generic;
    using Couplers;
    using DoesNot;
    using Enumerable.Count;
    using JetBrains.Annotations;
    using Not;

    /// <inheritdoc />
    /// <summary>
    /// The <see cref="IChainableEnumerableConditionBase{TSource,TObject}"/> interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    public interface IChainableEnumerableConditionBase<TSource, TObject> : IChainableConditionBase<TSource>
    {
    }

    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject}"/>
    /// <inheritdoc cref="IChainableEnumerableNotConditionBase{TSource,TObject,TChainableCondition}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <summary>
    /// The base interface that defines chainable conditions for enumerable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    /// <typeparam name="TChainableEnumerableNotCondition">The type of the chainable enumerable  not condition.</typeparam>
    /// <typeparam name="TChainableEnumerableDoesNotCondition">The type of the chainable enumerable  does not condition.</typeparam>
    public interface IChainableEnumerableConditionBase<TSource, TObject, out TChainableEnumerableCondition, out TChainableEnumerableNotCondition, out TChainableEnumerableDoesNotCondition>
        : IChainableEnumerableNotConditionBase<TSource, TObject, TChainableEnumerableCondition>,
          IChainableConditionBase<TSource, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>
        where TChainableEnumerableNotCondition : IChainableEnumerableNotConditionBase<TSource, TObject, TChainableEnumerableCondition>
        where TChainableEnumerableDoesNotCondition : IChainableEnumerableDoesNotConditionBase<TSource, TObject, TChainableEnumerableCondition>
    {
        /// <summary>
        /// Gets the count condition.
        /// </summary>
        IChainableEnumerableCountCondition<TSource, TObject, TChainableEnumerableCondition> Count { get; }

        /// <summary>
        /// Determines whether all elements of the source enumerable satisfy a condition.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// <paramref name="predicate"/> could not be evaluated.
        /// Inner exception: Cannot specify.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> All([NotNull]Func<TObject, bool> predicate);

        /// <summary>
        /// Determines whether any element of the source enumerable satisfies a condition.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// <paramref name="predicate"/> could not be evaluated.
        /// Inner exception: Cannot specify.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> Any([NotNull]Func<TObject, bool> predicate);

        /// <summary>
        /// Determines whether no element of the source enumerable satisfies a condition.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="ArgumentNullException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// <paramref name="predicate"/> could not be evaluated.
        /// Inner exception: Cannot specify.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> None([NotNull]Func<TObject, bool> predicate);

        /// <summary>
        /// Determines whether the source enumerable contains the specified value by comparing it with the other elements using the specified <paramref name="comparer"/>
        /// or the default <see cref="IEqualityComparer{TObject}"/> if the specified <paramref name="comparer"/> is <c>null</c>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="ArgumentNullException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> Contains(TObject value, IEqualityComparer<TObject> comparer = null);
    }
}