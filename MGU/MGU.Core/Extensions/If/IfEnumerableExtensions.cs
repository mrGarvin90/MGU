namespace MGU.Core.Extensions.If
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Base;
    using Interfaces.ChainableConditions.Enumerable;
    using Internal.ChainableConditions.Enumerable;

    /// <summary>
    /// Contains If extension methods for generic enumerable objects.
    /// </summary>
    public static class IfEnumerableExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for an array.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source array.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<TObject[], TObject> If<TObject>(this TObject[] source)
        {
            return source.IfEnumerable<TObject[], TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="string"/>.
        /// </summary>
        /// <param name="source">The source <see cref="string"/>.</param>
        /// <returns><see cref="IChainableStringCondition"/></returns>
        public static IChainableStringCondition If(this string source)
        {
            return new ChainableStringCondition(source);
        }

        #region System.Collections.Generic

        /// <summary>
        /// Gets conditions that can be chained for <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="Dictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this Dictionary<TKey, TValue> source)
        {
            return source.IfEnumerable<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="HashSet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="HashSet{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<HashSet<TObject>, TObject> If<TObject>(this HashSet<TObject> source)
        {
            return source.IfEnumerable<HashSet<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="LinkedList{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="LinkedList{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<LinkedList<TObject>, TObject> If<TObject>(this LinkedList<TObject> source)
        {
            return source.IfEnumerable<LinkedList<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="List{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="List{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<List<TObject>, TObject> If<TObject>(this List<TObject> source)
        {
            return source.IfEnumerable<List<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="Queue{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Queue{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<Queue<TObject>, TObject> If<TObject>(this Queue<TObject> source)
        {
            return source.IfEnumerable<Queue<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="SortedDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="SortedDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<SortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
        {
            return source.IfEnumerable<SortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="SortedList{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="SortedList{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<SortedList<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this SortedList<TKey, TValue> source)
        {
            return source.IfEnumerable<SortedList<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="SortedSet{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="SortedSet{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<SortedSet<TObject>, TObject> If<TObject>(this SortedSet<TObject> source)
        {
            return source.IfEnumerable<SortedSet<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="Stack{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Stack{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<Stack<TObject>, TObject> If<TObject>(this Stack<TObject> source)
        {
            return source.IfEnumerable<Stack<TObject>, TObject>();
        }

        #endregion

        #region System.Collections.ObjectModel

        /// <summary>
        /// Gets conditions that can be chained for <see cref="Collection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="Collection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<Collection<TObject>, TObject> If<TObject>(this Collection<TObject> source)
        {
            return source.IfEnumerable<Collection<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ReadOnlyCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyCollection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ReadOnlyCollection<TObject>, TObject> If<TObject>(this ReadOnlyCollection<TObject> source)
        {
            return source.IfEnumerable<ReadOnlyCollection<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ObservableCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ObservableCollection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ObservableCollection<TObject>, TObject> If<TObject>(this ObservableCollection<TObject> source)
        {
            return source.IfEnumerable<ObservableCollection<TObject>, TObject>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyDictionary{TKey,TValue}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> If<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> source)
        {
            return source.IfEnumerable<ReadOnlyDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
        }

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ReadOnlyObservableCollection{TObject}"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyObservableCollection{TObject}"/>.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<ReadOnlyObservableCollection<TObject>, TObject> If<TObject>(this ReadOnlyObservableCollection<TObject> source)
        {
            return source.IfEnumerable<ReadOnlyObservableCollection<TObject>, TObject>();
        }

        #endregion
    }
}