namespace MGU.Core.Interfaces.ChainableConditions.Base.DoNot
{
    using System;
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines chainable conditions for all objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    public interface IChainableDoNotConditionBase<TSource, out TChainableCondition> : IChainableConditionBase
        where TChainableCondition : IChainableConditionBase
    {
        /// <summary>
        /// Determines whether the source object do not fulfill the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The <paramref name="condition"/> could not be evaluated.
        /// </exception>
        IConditionCoupler<TSource, TChainableCondition> Fulfill([NotNull]Func<TSource, bool> condition);
    }
}