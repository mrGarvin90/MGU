namespace MGU.Core.Interfaces.ChainableConditions.Base.Not
{
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc cref="IChainableComparableConditionBase{TSource}" />
    /// <inheritdoc cref="IChainableNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for comparable objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    public interface IChainableComparableNotConditionBase<TSource, out TChainableComparableCondition>
        : IChainableComparableConditionBase<TSource>,
          IChainableNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource>
    {
        /// <summary>
        /// Determines whether the source comparable is within the specified range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The <paramref name="min"/> or <paramref name="max"/> is <see langword="null"/>.
        /// </exception>
        IConditionCoupler<TSource, TChainableComparableCondition> WithinRange([NotNull]TSource min, [NotNull]TSource max);

        /// <summary>
        /// Determines whether the source comparable is equal to the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        new IConditionCoupler<TSource, TChainableComparableCondition> EqualTo([CanBeNull]TSource other);
    }
}