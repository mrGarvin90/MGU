namespace MGU.Core.Interfaces.ChainableConditions.Enumerable
{
    using System.Globalization;
    using Base;
    using Count;
    using Couplers;
    using DoesNot;
    using JetBrains.Annotations;
    using Not;

    /// <inheritdoc cref="IChainableStringNotCondition" />
    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for <see cref="string"/>.
    /// </summary>
    public interface IChainableStringCondition
        : IChainableStringNotCondition,
          IChainableEnumerableConditionBase<string, char, IChainableStringCondition, IChainableStringNotCondition, IChainableStringDoesNotCondition>
    {
        /// <summary>
        /// Gets the length condition.
        /// </summary>
        IChainableEnumerableCountCondition<string, char, IChainableStringCondition> Length { get; }

        /// <summary>
        /// Determines whether the source string starts with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartsWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string starts with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> StartsWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string ends with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndsWith([CanBeNull]string value);

        /// <summary>
        /// Determines whether the source string ends with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> EndsWith([CanBeNull]string value, bool ignoreCase, CultureInfo culture = null);

        /// <summary>
        /// Determines whether the source string contains the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> Contains([CanBeNull]string value);
    }
}