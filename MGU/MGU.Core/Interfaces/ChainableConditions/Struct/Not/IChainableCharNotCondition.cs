namespace MGU.Core.Interfaces.ChainableConditions.Struct.Not
{
    using System.Globalization;
    using Base.Not;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableCharNotCondition : IChainableComparableNotConditionBase<char, IChainableCharCondition>
    {
        /// <summary>
        /// Determines whether the source character is categorized as a control character.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Control { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a decimal digit.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Digit { get; }

        /// <summary>
        /// Determines whether the source character is a high surrogate.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> HighSurrogate { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a Unicode letter.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Letter { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a lowercase letter.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Lower { get; }

        /// <summary>
        /// Determines whether the source character is a low surrogate.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> LowSurrogate { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a number.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Number { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a punctuation mark.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Punctuation { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a separator character.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Separator { get; }

        /// <summary>
        /// Determines whether the source character has a surrogate code unit.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Surrogate { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a symbol character.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Symbol { get; }

        /// <summary>
        /// Determines whether the source character is categorized as a uppercase letter.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> Upper { get; }

        /// <summary>
        /// Determines whether the source character is categorized as white space.
        /// </summary>
        IConditionCoupler<char, IChainableCharCondition> WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified string contains the source character.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// The condition will evaluate to <c>false</c> if the
        /// the specified string is <c>null</c>.
        /// </remarks>
        IConditionCoupler<char, IChainableCharCondition> In([CanBeNull]string str, bool ignoreCase = false, CultureInfo culture = null);
    }
}