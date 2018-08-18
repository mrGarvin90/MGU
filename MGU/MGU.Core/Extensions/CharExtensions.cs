namespace MGU.Core.Extensions
{
    using System.Globalization;

    /// <summary>
    /// Contains extension methods for <see cref="char"/>.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Converts the value of a Unicode character to its lowercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        /// The lowercase equivalent of <paramref name="c"/>,
        /// or the unchanged value of <paramref name="c"/>,
        /// if <paramref name="c"/> is already lowercase or not alphabetic.
        /// </returns>
        public static char ToLower(this char c)
            => char.ToLower(c);

        /// <summary>
        /// Converts the value of a specified Unicode character to its lowercase equivalent
        /// using specified culture-specific formatting information.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>
        /// The lowercase equivalent of <paramref name="c"/>,
        /// modified according to <paramref name="culture"/>,
        /// or the unchanged value of <paramref name="c"/>,
        /// if <paramref name="c"/> is already lowercase or not alphabetic.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="culture"/> is <c>null</c>.
        /// </exception>
        public static char ToLower(this char c, CultureInfo culture)
            => char.ToLower(c, culture);

        /// <summary>
        /// Converts the value of a Unicode character to its lowercase equivalent
        /// using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        /// The lowercase equivalent of the <paramref name="c"/> parameter,
        /// or the unchanged value of <paramref name="c"/>,
        /// if <paramref name="c"/> is already lowercase or not alphabetic.
        /// </returns>
        public static char ToLowerInvariant(this char c)
            => char.ToLowerInvariant(c);

        /// <summary>
        /// Converts the value of a Unicode character to its uppercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        /// The uppercase equivalent of <paramref name="c"/>,
        /// or the unchanged value of <paramref name="c"/> if <paramref name="c"/> is already uppercase,
        /// has no uppercase equivalent, or is not alphabetic.
        /// </returns>
        public static char ToUpper(this char c)
            => char.ToUpper(c);

        /// <summary>
        /// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>The uppercase equivalent of <paramref name="c"/>,
        /// modified according to <paramref name="culture"/>,
        /// or the unchanged value of <paramref name="c"/> if <paramref name="c"/> is already uppercase,
        /// has no uppercase equivalent, or is not alphabetic.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="culture"/> is null.
        /// </exception>
        public static char ToUpper(this char c, CultureInfo culture)
            => char.ToUpper(c, culture);

        /// <summary>
        /// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        /// The uppercase equivalent of the <paramref name="c"/> parameter,
        /// or the unchanged value of <paramref name="c"/>,
        /// if <paramref name="c"/> is already uppercase or not alphabetic.
        /// </returns>
        public static char ToUpperInvariant(this char c)
            => char.ToUpperInvariant(c);
    }
}