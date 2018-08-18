namespace MGU.Core.Interfaces.Conditions.Nullable.Not
{
    using System.Globalization;
    using Base.Not;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for nullable <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface INullableCharNotCondition : IComparableNotConditionBase<char?>
    {
        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a control character.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Control { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a decimal digit.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Digit { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is a high surrogate.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool HighSurrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a Unicode letter.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Letter { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a letter or a decimal digit.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool LetterOrDigit { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a lowercase letter.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Lower { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is a low surrogate.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool LowSurrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a number.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Number { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a punctuation mark.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Punctuation { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a separator character.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Separator { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> has a surrogate code unit.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Surrogate { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a symbol character.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Symbol { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as a uppercase letter.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool Upper { get; }

        /// <summary>
        /// Gets a value indicating whether the source nullable <see cref="char"/> is categorized as white space.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified string contains the source nullable <see cref="char"/>.
        /// The result will be <c>false</c> if the specified string is <c>null</c>.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// <c>true</c> if the source nullable <see cref="char"/> is in the specified string;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool In([CanBeNull]string str);

        /// <summary>
        /// Determines whether the specified string contains the source nullable <see cref="char"/>.
        /// The result will be <c>false</c> if the specified string is <c>null</c>.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>
        /// <c>true</c> if the source nullable <see cref="char"/> is in the specified string;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>.
        /// </value>
        bool In([CanBeNull]string str, bool ignoreCase, CultureInfo culture = null);
    }
}