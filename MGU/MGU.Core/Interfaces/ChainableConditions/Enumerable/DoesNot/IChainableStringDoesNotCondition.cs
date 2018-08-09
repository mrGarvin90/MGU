namespace MGU.Core.Interfaces.ChainableConditions.Enumerable.DoesNot
{
    using System.Globalization;
    using Base.DoesNot;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="string"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableStringDoesNotCondition : IChainableEnumerableDoesNotConditionBase<string, char, IChainableStringCondition>
    {
        /// <summary>
        /// Determines whether the source string does not start with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string does not start with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not end with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string does not end with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string does not contain the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> Contain([CanBeNull]string value);
    }
}