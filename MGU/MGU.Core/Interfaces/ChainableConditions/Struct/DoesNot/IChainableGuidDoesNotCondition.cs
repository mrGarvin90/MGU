namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using System;
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="Guid"/>.
    /// </summary>
    public interface IChainableGuidDoesNotCondition : IChainableComparableDoesNotConditionBase<Guid, IChainableGuidCondition>
    {
    }
}