namespace MGU.Core.Extensions.Is.Base
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Conditions.Enumerable;
    using Interfaces.Conditions.Nullable;
    using Interfaces.Conditions.Struct;
    using Internal.Conditions.Enumerable;
    using Internal.Conditions.Nullable;
    using Internal.Conditions.Struct;

    /// <summary>
    /// Contains base Is extension methods.
    /// </summary>
    public static class IsBaseExtensions
    {
        /// <summary>
        /// Gets conditions for any struct.
        /// </summary>
        /// <typeparam name="TSource">The type of the source struct.</typeparam>
        /// <param name="source">The source struct.</param>
        /// <returns><see cref="IStructCondition{TSource}"/></returns>
        public static IStructCondition<TSource> IsStruct<TSource>(this TSource source)
            where TSource : struct
            => new StructCondition<TSource>(source);

        /// <summary>
        /// Gets conditions for any object that implements <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the enumerable source object.</typeparam>
        /// <typeparam name="TObject">The type of the object that enumerable source object contains.</typeparam>
        /// <param name="source">The enumerable source object.</param>
        /// <returns><see cref="IEnumerableCondition{TSource,TObject}"/></returns>
        public static IEnumerableCondition<TSource, TObject> IsEnumerable<TSource, TObject>(this TSource source)
            where TSource : IEnumerable<TObject>
            => new EnumerableCondition<TSource, TObject>(source);

        /// <summary>
        /// Gets conditions for any class that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable source class.</typeparam>
        /// <param name="source">The comparable source class.</param>
        /// <returns><see cref="IComparableClassCondition{TSource}"/></returns>
        public static IComparableClassCondition<TSource> IsComparableClass<TSource>(this TSource source)
            where TSource : class, IComparable<TSource>
            => new ComparableClassCondition<TSource>(source);

        /// <summary>
        /// Gets conditions for any struct that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable source struct.</typeparam>
        /// <param name="source">The comparable source struct.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<TSource> IsComparableStruct<TSource>(this TSource source)
            where TSource : struct, IComparable<TSource>
            => new ComparableStructCondition<TSource>(source);

        /// <summary>
        /// Gets conditions for any nullable struct that implements <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the nullable comparable source struct.</typeparam>
        /// <param name="source">The nullable comparable source struct.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<TSource> IsNullableComparableStruct<TSource>(this TSource? source)
            where TSource : struct, IComparable<TSource>
            => new NullableComparableStructCondition<TSource>(source);
    }
}