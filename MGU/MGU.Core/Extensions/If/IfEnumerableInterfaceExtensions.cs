namespace MGU.Core.Extensions.If
{
    using System.Collections.Generic;
    using Interfaces.ChainableConditions.Enumerable;
    using Base;

    /// <summary>
    /// Contains If extension methods for generic enumerable interfaces.
    /// </summary>
    public static class IfEnumerableInterfaceExtensions
    {
        #region System.Collections.Generic

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ICollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ICollection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ICollection<TObject>, TObject> If<TObject>(this ICollection<TObject> source)
        {
            return source.IfEnumerable<ICollection<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="IDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            return source.IfEnumerable<IDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IEnumerable{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IEnumerable{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IEnumerable<TObject>, TObject> If<TObject>(this IEnumerable<TObject> source)
        {
            return source.IfEnumerable<IEnumerable<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IList{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IList<TObject>, TObject> If<TObject>(this IList<TObject> source)
        {
            return source.IfEnumerable<IList<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IReadOnlyCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyCollection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IReadOnlyCollection<TObject>, TObject> If<TObject>(this IReadOnlyCollection<TObject> source)
        {
            return source.IfEnumerable<IReadOnlyCollection<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source)
        {
            return source.IfEnumerable<IReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="IReadOnlyList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyList{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<IReadOnlyList<TObject>, TObject> If<TObject>(this IReadOnlyList<TObject> source)
        {
            return source.IfEnumerable<IReadOnlyList<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ISet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ISet{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ISet<TObject>, TObject> If<TObject>(this ISet<TObject> source)
        {
            return source.IfEnumerable<ISet<TObject>, TObject>();
        }

        #endregion
    }
}