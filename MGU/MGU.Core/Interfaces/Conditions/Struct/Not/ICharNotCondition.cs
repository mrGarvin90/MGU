namespace MGU.Core.Interfaces.Conditions.Struct.Not
{
    using System.Globalization;
    using Base.Not;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface ICharNotCondition : IComparableNotConditionBase<char>
    {
        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a control character.
        /// </summary>
        bool Control { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a decimal digit.
        /// </summary>
        bool Digit { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is a high surrogate.
        /// </summary>
        bool HighSurrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a Unicode letter.
        /// </summary>
        bool Letter { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a letter or a decimal digit.
        /// </summary>
        bool LetterOrDigit { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a lowercase letter.
        /// </summary>
        bool Lower { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is a low surrogate.
        /// </summary>
        bool LowSurrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a number.
        /// </summary>
        bool Number { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a punctuation mark.
        /// </summary>
        bool Punctuation { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a separator character.
        /// </summary>
        bool Separator { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> has a surrogate code unit.
        /// </summary>
        bool Surrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a symbol character.
        /// </summary>
        bool Symbol { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as a uppercase letter.
        /// </summary>
        bool Upper { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="char"/> is categorized as white space.
        /// </summary>
        bool WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified string contains the source <see cref="char"/>.
        /// The result will be <c>false</c> if the specified string is <c>null</c>.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// <c>true</c> if the source <see cref="char"/> is in the specified string;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool In([CanBeNull]string str);

        /// <summary>
        /// Determines whether the specified string contains the source <see cref="char"/>.
        /// The result will be <c>false</c> if the specified string is <c>null</c>.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>
        /// <c>true</c> if the source <see cref="char"/> is in the specified string;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool In([CanBeNull]string str, bool ignoreCase, CultureInfo culture = null);
    }
}