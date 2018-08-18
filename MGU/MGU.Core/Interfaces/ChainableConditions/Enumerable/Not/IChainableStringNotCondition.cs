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
        /// Determines whether the source <see cref="string"/> is empty.
        /// </summary>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        new IConditionCoupler<string, IChainableStringCondition> Empty { get; }

        /// <summary>
        /// Determines whether the source <see cref="string"/> consists only of white-space characters.
        /// </summary>
        /// <remarks>
        /// The combination [Null.Or.WhiteSpace] will also determine if the source <see cref="string"/> is empty.
        /// The combination [Not.Null.Or.WhiteSpace] will also determine if the source <see cref="string"/> is not empty.
        /// [Not.WhiteSpace] will always only determine whether the source <see cref="string"/> does not consist only of white-space characters
        /// even in combination with [Null.Or] or [Not.Null.Or].
        /// </remarks>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// Source <see cref="string"/> is <c>null</c>.
        /// Inner exception: <see cref="System.NullReferenceException"/>.
        /// </exception>
        IConditionCoupler<string, IChainableStringCondition> WhiteSpace { get; }

        /// <summary>
        /// Determines whether the specified other string contains the source <see cref="string"/>.
        /// </summary>
        /// <param name="other">The other string.</param>
        /// <param name="ignoreCase">If set to <c>true</c> the case will be ignored.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// <paramref name="culture"/> will only be used if <paramref name="ignoreCase"/> is <c>true</c>.
        /// The condition will evaluate to <c>false</c> if the source <see cref="string"/>
        /// or the specified <paramref name="other"/> is <c>null</c>.
        /// </remarks>
        IConditionCoupler<string, IChainableStringCondition> In([CanBeNull]string other, bool ignoreCase = false, CultureInfo culture = null);
    }
}