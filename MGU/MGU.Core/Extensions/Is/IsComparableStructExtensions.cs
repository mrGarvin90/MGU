namespace MGU.Core.Extensions.Is
{
    using System;
    using Base;
    using Interfaces.Conditions.Struct;
    using Internal.Conditions.Struct;

    /// <summary>
    /// Contains Is extension methods for comparable structs.
    /// </summary>
    public static class IsComparableStructExtensions
    {
        /// <summary>
        /// Gets conditions for <see cref="short"/>.
        /// </summary>
        /// <param name="source">The source short.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<short> Is(this short source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="ushort"/>.
        /// </summary>
        /// <param name="source">The source ushort.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<ushort> Is(this ushort source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="int"/>.
        /// </summary>
        /// <param name="source">The source int.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<int> Is(this int source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="uint"/>.
        /// </summary>
        /// <param name="source">The source uint.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<uint> Is(this uint source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="long"/>.
        /// </summary>
        /// <param name="source">The source long.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<long> Is(this long source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="ulong"/>.
        /// </summary>
        /// <param name="source">The source ulong.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<ulong> Is(this ulong source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="DateTime"/>.
        /// </summary>
        /// <param name="source">The source DateTime.</param>
        /// <returns><see cref="IComparableStructCondition{TSource}"/></returns>
        public static IComparableStructCondition<DateTime> Is(this DateTime source)
            => source.IsComparableStruct();

        /// <summary>
        /// Gets conditions for <see cref="char"/>.
        /// </summary>
        /// <param name="source">The source char.</param>
        /// <returns><see cref="ICharCondition"/></returns>
        public static ICharCondition Is(this char source)
            => new CharCondition(source);

        /// <summary>
        /// Gets conditions for <see cref="Guid"/>.
        /// </summary>
        /// <param name="source">The source Guid.</param>
        /// <returns><see cref="IGuidCondition"/></returns>
        public static IGuidCondition Is(this Guid source)
            => new GuidCondition(source);
    }
}