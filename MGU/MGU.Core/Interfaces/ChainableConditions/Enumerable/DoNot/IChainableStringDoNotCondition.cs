namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.DoNot
{
    using System.Globalization;
    using Base.DoNot;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="string"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableStringDoNotCondition : IChainableEnumerableDoNotConditionBase<string, char, IChainableStringCondition>
    {
        /// <summary>
        /// Determines whether the source string do not start with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string do not start with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <see langword="true"/> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string do not end with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string do not end with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <see langword="true"/> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string do not contain the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source <see cref="string"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> Contain([CanBeNull]string value);
    }
}