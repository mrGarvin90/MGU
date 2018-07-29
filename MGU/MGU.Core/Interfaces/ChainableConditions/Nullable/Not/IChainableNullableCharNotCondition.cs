namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using System.Globalization;
    using Base.Not;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableCharNotCondition
        : IChainableComparableNotConditionBase<char?, IChainableNullableCharCondition>,
          IChainableNullableNotConditionBase<char?, IChainableNullableCharCondition>
    {
        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a control character.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Control { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a decimal digit.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Digit { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is a high surrogate.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> HighSurrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a Unicode letter.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Letter { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a lowercase letter.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Lower { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is a low surrogate.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> LowSurrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a number.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Number { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a punctuation mark.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Punctuation { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a separator character.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Separator { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> has a surrogate code unit.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Surrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a symbol character.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Symbol { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a uppercase letter.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> Upper { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as white space.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The nullable source <see cref="char"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<char?, IChainableNullableCharCondition> WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified string contains the nullable source <see cref="char"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <see langword="false"/> if the nullable source <see cref="char"/>
        /// or the specified string is <see langword="null"/>.
        /// </remarks>
        /// <param name="str">The string.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<char?, IChainableNullableCharCondition> In([CanBeNull]string str);

        /// <summary>
        /// Determines whether the specified string contains the nullable source <see cref="char"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <see langword="false"/> if the nullable source <see cref="char"/>
        /// or the specified string is <see langword="null"/>.
        /// </remarks>
        /// <param name="str">The string.</param>
        /// <param name="ignoreCase">If set to <see langword="true"/> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<char?, IChainableNullableCharCondition> In([CanBeNull]string str, bool ignoreCase, CultureInfo culture = null);
    }
}