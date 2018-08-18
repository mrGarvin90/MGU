namespace MGU.Core.Extensions.Is
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Base;
    using Interfaces.Conditions.Enumerable;
    using Internal.Conditions.Enumerable;

    /// <summary>
    /// Contains Is extension methods for generic enumerable objects.
    /// </summary>
    public static class IsEnumerableExtensions
    {
        /// <summary>
        /// Gets conditions for an array.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source array.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<TObject[], TObject> Is<TObject>(this TObject[] source)
            => source.IsEnumerable<TObject[], TObject>();

        /// <summary>
        /// Gets conditions for <see cref="string"/>.
        /// </summary>
        /// <param name="source">The source <see cref="string"/>.</param>
        /// <returns><see cref="IStringCondition"/></returns>
        public static IStringCondition Is(this string source)
            => new StringCondition(source);

        #region System.Collections.Generic

        /// <summary>
        /// Gets conditions for <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="Dictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.IsEnumerable<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="HashSet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="HashSet{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<HashSet<TObject>, TObject> Is<TObject>(this HashSet<TObject> source)
            => source.IsEnumerable<HashSet<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="LinkedList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="LinkedList{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<LinkedList<TObject>, TObject> Is<TObject>(this LinkedList<TObject> source)
            => source.IsEnumerable<LinkedList<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="List{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="List{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<List<TObject>, TObject> Is<TObject>(this List<TObject> source)
            => source.IsEnumerable<List<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="Queue{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Queue{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<Queue<TObject>, TObject> Is<TObject>(this Queue<TObject> source)
            => source.IsEnumerable<Queue<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="SortedDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="SortedDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<SortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.IsEnumerable<SortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="SortedList{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="SortedList{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<SortedList<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this SortedList<TKey, TValue> source)
            => source.IsEnumerable<SortedList<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="SortedSet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="SortedSet{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<SortedSet<TObject>, TObject> Is<TObject>(this SortedSet<TObject> source)
            => source.IsEnumerable<SortedSet<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="Stack{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Stack{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<Stack<TObject>, TObject> Is<TObject>(this Stack<TObject> source)
            => source.IsEnumerable<Stack<TObject>, TObject>();

        #endregion

        #region System.Collections.ObjectModel

        /// <summary>
        /// Gets conditions for <see cref="Collection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Collection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<Collection<TObject>, TObject> Is<TObject>(this Collection<TObject> source)
            => source.IsEnumerable<Collection<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="ReadOnlyCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyCollection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ReadOnlyCollection<TObject>, TObject> Is<TObject>(this ReadOnlyCollection<TObject> source)
            => source.IsEnumerable<ReadOnlyCollection<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="ObservableCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ObservableCollection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ObservableCollection<TObject>, TObject> Is<TObject>(this ObservableCollection<TObject> source)
            => source.IsEnumerable<ObservableCollection<TObject>, TObject>();

        /// <summary>
        /// Gets conditions for <see cref="ReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> Is<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> source)
            => source.IsEnumerable<ReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();

        /// <summary>
        /// Gets conditions for <see cref="ReadOnlyObservableCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyObservableCollection{TObject}"/>.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<ReadOnlyObservableCollection<TObject>, TObject> Is<TObject>(this ReadOnlyObservableCollection<TObject> source)
            => source.IsEnumerable<ReadOnlyObservableCollection<TObject>, TObject>();

        #endregion
    }
}