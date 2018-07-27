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
        /// The result will be <see langword="false"/> if the source string 
        /// or the specified <paramref name="other"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <see langword="true"/> if the source string is in the specified other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool In([CanBeNull]string other);

        /// <summary>
        /// Determines whether the source string is in the specified other. 
        /// The result will be <see langword="false"/> if the source string 
        /// or the specified <paramref name="other"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <param name="ignoreCase">If set to <see langword="true"/> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>
        /// <see langword="true"/> if the source string is in the specified other; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        bool In([CanBeNull]string other, bool ignoreCase, CultureInfo culture = null);
    }
}