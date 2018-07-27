namespace MGU.Core.Interfaces.ChainableConditions.Base
{
    using System;
    using Couplers;
    using DoNot;
    using JetBrains.Annotations;
    using Not;

    /// <summary>
    /// The <see cref="IChainableConditionBase"/> interface.
    /// </summary>
    public interface IChainableConditionBase
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines chainable conditions for all objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    /// <typeparam name="TChainableNotCondition">The type of the chainable not condition.</typeparam>
    /// <typeparam name="TChainableDoNotCondition">The type of the chainable do not condition.</typeparam>
    public interface IChainableConditionBase<TSource, out TChainableCondition, out TChainableNotCondition, out TChainableDoNotCondition> : IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableCondition : IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoNotCondition>
        where TChainableNotCondition : IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableDoNotCondition : IChainableDoNotConditionBase<TSource, TChainableCondition>
    {
        /// <summary>
        /// Gets the not conditions where the result of the conditions will be inverted.
        /// </summary>
        TChainableNotCondition Not { get; }

        /// <summary>
        /// Gets the do not condition.
        /// </summary>
        TChainableDoNotCondition DoNot { get; }

        /// <summary>
        /// Determines whether the source object fulfills the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The <paramref name="condition"/> could not be evaluated.
        /// </exception>
        IConditionCoupler<TSource, TChainableCondition> Fulfills([NotNull]Func<TSource, bool> condition);
    }
}