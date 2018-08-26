namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using System;
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableNullableGuidNotCondition" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="Guid" />.
    /// </summary>
    public interface IChainableNullableGuidCondition
        : IChainableNullableGuidNotCondition,
          IChainableComparableConditionBase<Guid?, IChainableNullableGuidCondition, IChainableNullableGuidNotCondition, IChainableNullableGuidDoesNotCondition>
    {
    }
}