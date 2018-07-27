namespace MGU.Core.Extensions.If.Base
{
    using System;
    using System.Collections.Generic;
    using Interfaces.ChainableConditions.Enumerable;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.ChainableConditions.Struct;
    using Internal.ChainableConditions.Enumerable;
    using Internal.ChainableConditions.Nullable;
    using Internal.ChainableConditions.Struct;

    /// <summary>
    /// Contains base If extension methods.
    /// </summary>
    public static class IfBaseExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for any struct.
        /// </summary>
        /// <typeparam name="TSource">The type of the source struct.</typeparam>
        /// <param name="source">The source struct.</param>
        /// <returns><see cref="IChainableStructCondition{TSource}"/></returns>
        public static IChainableStructCondition<TSource> IfStruct<TSource>(this TSource source)
            where TSource : struct
        {
            return new ChainableStructCondition<TSource>(source);
        }

        /// <summary>
        /// Gets conditions that can be chained for any object that implements <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the enumerable source object.</typeparam>
        /// <typeparam name="TObject">The type of the object that enumerable source object contains.</typeparam>
        /// <param name="source">The enumerable source object.</param>
        /// <returns><see cref="IChainableEnumerableCondition{TSource,TObject}"/></returns>
        public static IChainableEnumerableCondition<TSource, TObject> IfEnumerable<TSource, TObject>(this TSource source)
            where TSource : IEnumerable<TObject>
        {
            return new ChainableEnumerableCondition<TSource, TObject>(source);
        }

        /// <summary>
        /// Gets conditions that can be chained for any class that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable source class.</typeparam>
        /// <param name="source">The comparable source class.</param>
        /// <returns><see cref="IChainableComparableClassCondition{TSource}"/></returns>
        public static IChainableComparableClassCondition<TSource> IfComparableClass<TSource>(this TSource source)
            where TSource : class, IComparable<TSource>
        {
            return new ChainableComparableClassCondition<TSource>(source);
        }

        /// <summary>
        /// Gets conditions that can be chained for any struct that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable source struct.</typeparam>
        /// <param name="source">The comparable source struct.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<TSource> IfComparableStruct<TSource>(this TSource source)
            where TSource : struct, IComparable<TSource>
        {
            return new ChainableComparableStructCondition<TSource>(source);
        }

        /// <summary>
        /// Gets conditions that can be chained for any nullable struct that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the nullable comparable source struct.</typeparam>
        /// <param name="source">The nullable comparable source struct.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<TSource> IfNullableComparableStruct<TSource>(this TSource? source)
            where TSource : struct, IComparable<TSource>
        {
            return new ChainableNullableComparableStructCondition<TSource>(source);
        }
    }
}