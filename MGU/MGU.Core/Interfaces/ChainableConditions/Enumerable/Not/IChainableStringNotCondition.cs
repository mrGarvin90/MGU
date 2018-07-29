namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.Not
{
    using System.Globalization;
    using Base.Not;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="string"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableStringNotCondition : IChainableEnumerableNotConditionBase<string, char, IChainableStringCondition>
    {
        /// <summary>
        /// Determines whether the source <see cref="string"/> consists only of white-space characters.
        /// </summary>
        /// <remarks>
        /// The combination [Null.Or.WhiteSpace] will also determine if the source <see cref="string"/> is empty. The combination
        /// [Not.Null.Or.WhiteSpace] will also determine if the source <see cref="string"/> is not empty. [Not.WhiteSpace] will
        /// ALWAYS only determine whether the source <see cref="string"/> do not consist only of white-space characters even in
        /// combination with [Null.Or] or [Not.Null.Or].
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified <paramref name="other"/> contains the source <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <see langword="false"/> if the source string
        /// or the specified <paramref name="other"/> is <see langword="null"/>.
        /// </remarks>
        /// <param name="other">The other string.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<string, IChainableStringCondition> In([CanBeNull]string other);

        /// <summary>
        /// Determines whether the specified other string contains the source <see cref="string"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <see langword="false"/> if the source string
        /// or the specified <paramref name="other"/> is <see langword="null"/>.
        /// </remarks>
        /// <param name="other">The other string.</param>
        /// <param name="ignoreCase">If set to <see langword="true"/> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<string, IChainableStringCondition> In([CanBeNull]string other, bool ignoreCase, CultureInfo culture = null);
    }
}