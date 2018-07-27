namespace MGU.Core.Internal.Extensions
{
    using System;

    /// <summary>
    /// Contains extension methods for all types that implement <see cref="IComparable{T}"/>.
    /// </summary>
    internal static class ComparableExtensions
    {
        /// <summary>
        /// Determines whether the source comparable is equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool EqualTo<TSource>(this TSource source, TSource other)
            where TSource : IComparable<TSource>
        {
            return source == null ? other == null : source.CompareTo(other) == 0;
        }

        /// <summary>
        /// Determines whether the source comparable is equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool EqualTo<TSource>(this TSource? source, TSource? other)
            where TSource : struct, IComparable<TSource>
        {
            if (source.HasValue && other.HasValue)
                return source.Value.CompareTo(other.Value) == 0;
            return !source.HasValue && !other.HasValue;
        }

        /// <summary>
        /// Determines whether the source comparable is less than the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is less than the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool LessThan<TSource>(this TSource source, TSource other)
            where TSource : IComparable<TSource>
        {
            return source?.CompareTo(other) < 0;
        }

        /// <summary>
        /// Determines whether the source comparable is less than the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is less than the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool LessThan<TSource>(this TSource? source, TSource? other)
            where TSource : struct, IComparable<TSource>
        {
            return source.HasValue && other.HasValue && source.Value.CompareTo(other.Value) < 0;
        }

        /// <summary>
        /// Determines whether the source comparable is less than or equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is less than or equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool LessThanOrEqualTo<TSource>(this TSource source, TSource other)
            where TSource : IComparable<TSource>
        {
            return LessThan(source, other) || EqualTo(source, other);
        }

        /// <summary>
        /// Determines whether the source comparable is less than or equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is less than or equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool LessThanOrEqualTo<TSource>(this TSource? source, TSource? other)
            where TSource : struct, IComparable<TSource>
        {
            if (source.HasValue && other.HasValue)
                return source.Value.CompareTo(other.Value) <= 0;
            return !source.HasValue && !other.HasValue;
        }

        /// <summary>
        /// Determines whether the source comparable is greater than the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is greater than the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool GreaterThan<TSource>(this TSource source, TSource other)
            where TSource : IComparable<TSource>
        {
            return source?.CompareTo(other) > 0;
        }

        /// <summary>
        /// Determines whether the source comparable is greater than the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is greater than the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool GreaterThan<TSource>(this TSource? source, TSource? other)
            where TSource : struct, IComparable<TSource>
        {
            return source.HasValue && other.HasValue && source.Value.CompareTo(other.Value) > 0;
        }

        /// <summary>
        /// Determines whether the source comparable is greater than or equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is greater than or equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool GreaterThanOrEqualTo<TSource>(this TSource source, TSource other)
            where TSource : IComparable<TSource>
        {
            return GreaterThan(source, other) || EqualTo(source, other);
        }

        /// <summary>
        /// Determines whether the source comparable is greater than or equal to the specified other.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is greater than or equal to the comparable other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        internal static bool GreaterThanOrEqualTo<TSource>(this TSource? source, TSource? other)
            where TSource : struct, IComparable<TSource>
        {
            if (source.HasValue && other.HasValue)
                return source.Value.CompareTo(other.Value) >= 0;
            return !source.HasValue && !other.HasValue;
        }

        /// <summary>
        /// Determines whether the source comparable is within the specified range.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is within the specified range; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="min"/> or the <paramref name="max"/> is <see langword="null"/>.
        /// </exception>
        internal static bool WithinRange<TSource>(this TSource source, TSource min, TSource max)
            where TSource : IComparable<TSource>
        {
            if (min == null)
                throw new InvalidOperationException($"{nameof(min)} cannot be null.");
            if (max == null)
                throw new InvalidOperationException($"{nameof(max)} cannot be null.");
            return GreaterThanOrEqualTo(source, min) && LessThanOrEqualTo(source, max);
        }

        /// <summary>
        /// Determines whether the source comparable is within the specified range.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>
        /// <see langword="true"/> if the source comparable is within the specified range; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="min"/> or the <paramref name="max"/> is <see langword="null"/>.
        /// </exception>
        internal static bool WithinRange<TSource>(this TSource? source, TSource? min, TSource? max)
            where TSource : struct, IComparable<TSource>
        {
            if (!source.HasValue)
                return false;
            return GreaterThanOrEqualTo(source.Value, min.Value) && LessThanOrEqualTo(source.Value, max.Value);
        }
    }
}