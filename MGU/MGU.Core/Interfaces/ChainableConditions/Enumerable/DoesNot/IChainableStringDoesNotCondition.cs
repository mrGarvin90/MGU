namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.DoesNot
{
    using System.Globalization;
    using Base.DoesNot;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="string"/>.
    /// </summary>
    public interface IChainableStringDoesNotCondition : IChainableEnumerableDoesNotConditionBase<string, char, IChainableStringCondition>
    {
        /// <summary>
        /// Determines whether the source string does not start with the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith(char character, bool ignoreCase = false, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not start with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith([CanBeNull]string value, bool ignoreCase = false, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not end with the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith(char character, bool ignoreCase = false, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not end with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith([CanBeNull]string value, bool ignoreCase = false, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not contain the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> Contain(char character, bool ignoreCase = false, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not contain the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> Contain([CanBeNull]string value, bool ignoreCase = false, CultureInfo culture = null);
    }
}