namespace MGU.Core.Interfaces.ChainableConditions.Struct.Not
{
    using System;
    using Base.Not;
    using Couplers;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="Guid"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableGuidNotCondition : IChainableComparableNotConditionBase<Guid, IChainableGuidCondition>
    {
        /// <summary>
        /// Determines whether the source <see cref="Guid"/> is equal to <see cref="Guid.Empty"/>.
        /// </summary>
        IConditionCoupler<Guid, IChainableGuidCondition> Empty { get; }
    }
}