namespace MGU.Core.Extensions.Is
{
    using Interfaces.Conditions.Nullable;
    using Internal.Conditions.Nullable;

    /// <summary>
    /// Contains Is extension methods for all types.
    /// </summary>
    public static class IsExtensions
    {
        /// <summary>
        /// Determines whether this instance is equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="other">The other object.</param>
        /// <returns>
        /// <see langword="true" /> if this instance is equal to the specified other;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool Is<TSource>(this TSource source, TSource other)
        {
            return ReferenceEquals(source, other) || (source?.Equals(other) ?? other == null);
        }

        /// <summary>
        /// Gets conditions for all types.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns><see cref="ICondition{TSource}"/></returns>
        public static ICondition<TSource> Is<TSource>(this TSource source)
        {
            return new Condition<TSource>(source);
        }
    }
}