namespace MGU.Core.Interfaces.Conditions.Enumerable.Not
{
    using System.Globalization;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for <see cref="string"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IStringNotCondition : IEnumerableNotCondition<string, char>
    {
        /// <summary>
        /// Gets a value indicating whether the source string is null, empty or consists only of white-space characters.
        /// </summary>
        bool NullOrWhitespace { get; }

        /// <summary>
        /// Determines whether the source string is in the specified other.
        /// The result will be <c>false</c> if the source string
        /// or the specified <paramref name="other"/> is <c>null</c>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the source string is in the specified other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool In([CanBeNull]string other);

        /// <summary>
        /// Determines whether the source string is in the specified other.
        /// The result will be <c>false</c> if the source string
        /// or the specified <paramref name="other"/> is <c>null</c>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>
        /// <c>true</c> if the source string is in the specified other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool In([CanBeNull]string other, bool ignoreCase, CultureInfo culture = null);
    }
}