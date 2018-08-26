namespace MGU.Core.Extensions.If
{
    using System;
    using Base;
    using Interfaces.ChainableConditions.Struct;
    using Internal.ChainableConditions.Struct;

    /// <summary>
    /// Contains If extension methods for comparable structs.
    /// </summary>
    public static class IfComparableStructExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for <see cref="short"/>.
        /// </summary>
        /// <param name="source">The source <see cref="short"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<short> If(this short source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ushort"/>.
        /// </summary>
        /// <param name="source">The source <see cref="ushort"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<ushort> If(this ushort source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="int"/>.
        /// </summary>
        /// <param name="source">The source <see cref="int"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<int> If(this int source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="uint"/>.
        /// </summary>
        /// <param name="source">The source <see cref="uint"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<uint> If(this uint source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="long"/>.
        /// </summary>
        /// <param name="source">The source <see cref="long"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<long> If(this long source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="ulong"/>.
        /// </summary>
        /// <param name="source">The source <see cref="ulong"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<ulong> If(this ulong source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="DateTime"/>.
        /// </summary>
        /// <param name="source">The source <see cref="DateTime"/>.</param>
        /// <returns><see cref="IChainableComparableStructCondition{TSource}"/></returns>
        public static IChainableComparableStructCondition<DateTime> If(this DateTime source)
            => source.IfComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for <see cref="char"/>.
        /// </summary>
        /// <param name="source">The source <see cref="char"/>.</param>
        /// <returns><see cref="IChainableCharCondition"/></returns>
        public static IChainableCharCondition If(this char source)
            => new ChainableCharCondition(source);

        /// <summary>
        /// Gets conditions that can be chained for <see cref="Guid"/>.
        /// </summary>
        /// <param name="source">The source <see cref="Guid"/>.</param>
        /// <returns><see cref="IChainableGuidCondition"/></returns>
        public static IChainableGuidCondition If(this Guid source)
            => new ChainableGuidCondition(source);
    }
}