namespace MGU.Core.Extensions.Is
{
    using System.Collections.Generic;
    using Base;
    using Interfaces.Conditions.Enumerable;

    /// <summary>
    /// Contains Is extension methods for generic enumerable interfaces.
    /// </summary>
    public static class IsEnumerableInterfaceExtensions
    {
        #region System.Collections.Generic

        /// <summary>
        /// Gets conditions for <see cref="ICollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ICollection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ICollection<TObject>, TObject> Is<TObject>(this ICollection<TObject> source)
            => source.IsEnumerable<ICollection<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="IDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this IDictionary<TKey, TValue> source)
            => source.IsEnumerable<IDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="IEnumerable{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IEnumerable{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IEnumerable<TObject>, TObject> Is<TObject>(this IEnumerable<TObject> source)
            => source.IsEnumerable<IEnumerable<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="IList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IList{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IList<TObject>, TObject> Is<TObject>(this IList<TObject> source)
            => source.IsEnumerable<IList<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="IReadOnlyCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyCollection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IReadOnlyCollection<TObject>, TObject> Is<TObject>(this IReadOnlyCollection<TObject> source)
            => source.IsEnumerable<IReadOnlyCollection<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="IReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source)
            => source.IsEnumerable<IReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="IReadOnlyList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyList{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<IReadOnlyList<TObject>, TObject> Is<TObject>(this IReadOnlyList<TObject> source)
            => source.IsEnumerable<IReadOnlyList<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="ISet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ISet{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ISet<TObject>, TObject> Is<TObject>(this ISet<TObject> source)
            => source.IsEnumerable<ISet<TObject>, TObject>();

        #endregion
    }
}