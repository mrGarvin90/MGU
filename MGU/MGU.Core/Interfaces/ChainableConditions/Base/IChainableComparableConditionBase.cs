namespace MGU.Core.Interfaces.ChainableConditions.Base
{
    using Couplers;
    using DoNot;
    using JetBrains.Annotations;
    using Not;

    /// <inheritdoc />
    /// <summary>
    /// The <see cref="IChainableComparableConditionBase{TSource}"/> interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    public interface IChainableComparableConditionBase<TSource> : IChainableConditionBase
    {
    }

    /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <summary>
    /// The base interface that defines chainable conditions for comparable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    /// <typeparam name="TChainableComparableNotCondition">The type of the chainable comparable not condition.</typeparam>
    /// <typeparam name="TChainableComparableDoNotCondition">The type of the chainable comparable do not condition.</typeparam>
    public interface IChainableComparableConditionBase<TSource, out TChainableComparableCondition, out TChainableComparableNotCondition, out TChainableComparableDoNotCondition>
        : IChainableComparableNotConditionBase<TSource, TChainableComparableCondition>,
          IChainableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoNotCondition>
        where TChainableComparableNotCondition : IChainableComparableNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableDoNotCondition : IChainableComparableDoNotConditionBase<TSource, TChainableComparableCondition>
    {
        /// <summary>
        /// Determines whether the source comparable is less than the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableComparableCondition> LessThan([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is less than or equal to the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableComparableCondition> LessThanEqualTo([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is greater than the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableComparableCondition> GreaterThan([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is greater than or equal to the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        IConditionCoupler<TSource, TChainableComparableCondition> GreaterThanEqualTo([CanBeNull]TSource other);
    }
}