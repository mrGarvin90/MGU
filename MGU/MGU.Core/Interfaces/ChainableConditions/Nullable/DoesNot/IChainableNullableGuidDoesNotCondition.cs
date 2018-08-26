namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using System;
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="Guid"/>.
    /// </summary>
    public interface IChainableNullableGuidDoesNotCondition : IChainableComparableDoesNotConditionBase<Guid?, IChainableNullableGuidCondition>
    {
    }
}