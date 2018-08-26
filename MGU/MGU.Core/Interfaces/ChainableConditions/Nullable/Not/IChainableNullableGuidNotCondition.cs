namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using System;
    using Base.Not;
    using Couplers;

    /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="Guid"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableGuidNotCondition
        : IChainableComparableNotConditionBase<Guid?, IChainableNullableGuidCondition>,
            IChainableNullableNotConditionBase<Guid?, IChainableNullableGuidCondition>
    {
        /// <summary>
        /// Determines whether the nullable source <see cref="Guid"/> is equal to <see cref="Guid.Empty"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="Guid"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<Guid?, IChainableNullableGuidCondition> Empty { get; }
    }
}