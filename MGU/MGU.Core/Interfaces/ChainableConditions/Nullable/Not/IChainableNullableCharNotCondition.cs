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
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Control { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a decimal digit.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Digit { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is a high surrogate.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> HighSurrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a Unicode letter.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Letter { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a lowercase letter.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Lower { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is a low surrogate.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> LowSurrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a number.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Number { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a punctuation mark.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Punctuation { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a separator character.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Separator { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> has a surrogate code unit.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Surrogate { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a symbol character.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Symbol { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as a uppercase letter.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> Upper { get; }

        /// <summary>
        /// Determines whether the nullable source <see cref="char"/> is categorized as white space.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified string contains the nullable source <see cref="char"/>.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="char"/>
        /// or the specified string is <c>null</c>.
        /// </remarks>
        IConditionCoupler<char?, IChainableNullableCharCondition> In([CanBeNull]string str, bool ignoreCase = false, CultureInfo culture = null);
    }
}