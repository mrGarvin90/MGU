namespace MGU.Core.Interfaces.ChainableConditions.Base.Not
{
    using System.Collections.Generic;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines chainable conditions for all objects 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    public interface IChainableNotConditionBase<TSource, out TChainableCondition> : IChainableConditionBase
        where TChainableCondition : IChainableConditionBase
    {
        /// <summary>
        /// Determines whether the source object is equal to the specified <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableCondition> EqualTo(TSource other);

        /// <summary>
        /// Determines whether the source object is the specified type. 
        /// If the source object is <see langword="null"/> the specific types of the source object and <typeparamref name="T"/> 
        /// will be compared, otherwise the <see langword="is"/> operator will be used.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableCondition> Type<T>();

        /// <summary>
        /// Determines whether the source object is in the specified collection using the specified <paramref name="comparer"/> 
        /// or the default equality comparer for the source object if the specified <paramref name="comparer"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableCondition> In([CanBeNull]IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null);
    }
}