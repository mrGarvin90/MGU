namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using Base;
    using Couplers;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableBoolNotCondition" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for <see cref="bool" />.
    /// </summary>
    public interface IChainableBoolCondition
        : IChainableBoolNotCondition,
          IChainableConditionBase<bool, IChainableBoolCondition, IChainableBoolNotCondition, IChainableBoolDoNotCondition>
    {
        /// <summary>
        /// Determines whether the source <see cref="bool"/> is <see langword="true"/>.
        /// </summary>
        IConditionCoupler<bool, IChainableBoolCondition> True { get; }

        /// <summary>
        /// Determines whether the source <see cref="bool"/> is <see langword="false"/>.
        /// </summary>
        IConditionCoupler<bool, IChainableBoolCondition> False { get; }
    }
}