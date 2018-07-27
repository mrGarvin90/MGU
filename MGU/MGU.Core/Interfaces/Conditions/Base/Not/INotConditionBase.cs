namespace MGU.Core.Interfaces.Conditions.Base.Not
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    /// <summary>
    /// The base interface that defines conditions for all objects 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface INotConditionBase<TSource>
    {
        /// <summary>
        /// Determines whether the source object is in the specified <paramref name="collection"/> using the specified <paramref name="comparer"/> 
        /// or the default equality comparer for the source object if the specified <paramref name="comparer"/> is <see langword="null"/>. 
        /// The result will be <see langword="false"/> if the source object or the specified <paramref name="collection"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// <see langword="true"/> if the source object is in the specified collection;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool In([CanBeNull]IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null);
    }
}