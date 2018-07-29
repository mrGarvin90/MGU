﻿namespace MGU.Core.Extensions.If
{
    using System;
    using Base;
    using Interfaces.ChainableConditions.Nullable;
    using Internal.ChainableConditions.Nullable;

    /// <summary>
    /// Contains If extension methods for nullable comparable structs.
    /// </summary>
    public static class IfNullableComparableStructExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="short"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="short"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<short> If(this short? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="ushort"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<ushort> If(this ushort? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="int"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="int"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<int> If(this int? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="uint"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<uint> If(this uint? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="long"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="long"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<long> If(this long? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="ulong"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<ulong> If(this ulong? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="DateTime"/>.</param>
        /// <returns><see cref="IChainableNullableComparableStructCondition{TSource}"/></returns>
        public static IChainableNullableComparableStructCondition<DateTime> If(this DateTime? source)
        {
            return source.IfNullableComparableStruct();
        }

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="char"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="char"/>.</param>
        /// <returns><see cref="IChainableNullableCharCondition"/></returns>
        public static IChainableNullableCharCondition If(this char? source)
        {
            return new ChainableNullableCharCondition(source);
        }
    }
}