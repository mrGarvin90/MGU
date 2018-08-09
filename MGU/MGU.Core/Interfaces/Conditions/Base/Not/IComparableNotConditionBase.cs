namespace MGU.Core.Interfaces.Conditions.Base.Not
{
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines conditions for comparable objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source.</typeparam>
    public interface IComparableNotConditionBase<TSource> : INotConditionBase<TSource>
    {
        /// <summary>
        /// Determines whether the source comparable is within the specified range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is within the specified range;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="min"/> or the <paramref name="max"/> is <c>null</c>.
        /// </exception>
        bool WithinRange([NotNull]TSource min, [NotNull]TSource max);

        /// <summary>
        /// Determines whether the source comparable is equal to the specified other.
        /// </summary>
        /// <param name="other">The other comparable.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is equal to the comparable other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool EqualTo([CanBeNull]TSource other);
    }
}