namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using System;
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableGuidNotCondition" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for <see cref="Guid" />.
    /// </summary>
    public interface IChainableGuidCondition
        : IChainableGuidNotCondition,
          IChainableComparableConditionBase<Guid, IChainableGuidCondition, IChainableGuidNotCondition, IChainableGuidDoesNotCondition>
    {
    }
}