namespace MGU.Core.Extensions.Is
{
    using System;
    using Base;
    using Interfaces.Conditions.Nullable;
    using Internal.Conditions.Nullable;

    /// <summary>
    /// Contains Is extension methods for nullable comparable structs.
    /// </summary>
    public static class IsNullableComparableStructExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="short"/>.
        /// </summary>
        /// <param name="source">The source short.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<short> Is(this short? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="source">The source ushort.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<ushort> Is(this ushort? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="int"/>.
        /// </summary>
        /// <param name="source">The source int.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<int> Is(this int? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="source">The source uint.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<uint> Is(this uint? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="long"/>.
        /// </summary>
        /// <param name="source">The source long.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<long> Is(this long? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="source">The source ulong.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<ulong> Is(this ulong? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="source">The source DateTime.</param>
        /// <returns><see cref="INullableComparableStructCondition{TSource}"/></returns>
        public static INullableComparableStructCondition<DateTime> Is(this DateTime? source)
            => source.IsNullableComparableStruct();

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="char"/>.
        /// </summary>
        /// <param name="source">The source char.</param>
        /// <returns><see cref="INullableCharCondition"/></returns>
        public static INullableCharCondition Is(this char? source)
            => new NullableCharCondition(source);

        /// <summary>
        /// Gets conditions that can be chained for nullable <see cref="Guid"/>.
        /// </summary>
        /// <param name="source">The source Guid.</param>
        /// <returns><see cref="INullableGuidCondition"/></returns>
        public static INullableGuidCondition Is(this Guid? source)
            => new NullableGuidCondition(source);
    }
}