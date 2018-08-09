namespace MGU.Core.Interfaces.ChainableConditions.Base.Not
{
    using System.Collections.Generic;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject}"/>
    /// <inheritdoc cref="IChainableNotConditionBase{TSource,TChainableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for enumerable objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
    public interface IChainableEnumerableNotConditionBase<TSource, TObject, out TChainableEnumerableCondition>
        : IChainableEnumerableConditionBase<TSource, TObject>,
          IChainableNotConditionBase<TSource, TChainableEnumerableCondition>,
          IChainableNullableNotConditionBase<TSource, TChainableEnumerableCondition>
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject>
    {
        /// <summary>
        /// Determines whether the source enumerable is empty.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> Empty { get; }

        /// <summary>
        /// Determines whether the source enumerable and the other enumerable are equal by comparing their elements using the specified <paramref name="comparer"/>
        /// or the default <see cref="IEqualityComparer{TObject}"/> if the specified <paramref name="comparer"/> is <c>null</c>.
        /// </summary>
        /// <param name="other">The other <see cref="IEnumerable{TObject}"/>.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source enumerable is <c>null</c>.
        /// Inner exception: <see cref="System.ArgumentNullException"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableEnumerableCondition> SequentiallyEqualTo([CanBeNull]IEnumerable<TObject> other, IEqualityComparer<TObject> comparer = null);
    }
}