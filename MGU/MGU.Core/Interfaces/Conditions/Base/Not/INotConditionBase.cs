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
        /// or the default equality comparer for the source object if the specified <paramref name="comparer"/> is <c>null</c>.
        /// The result will be <c>false</c> if the source object or the specified <paramref name="collection"/> is <c>null</c>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// <c>true</c> if the source object is in the specified collection;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool In([CanBeNull]IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null);
    }
}