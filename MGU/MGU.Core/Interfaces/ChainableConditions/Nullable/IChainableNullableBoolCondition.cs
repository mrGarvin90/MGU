namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using Base;
    using Couplers;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableNullableBoolNotCondition" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="bool" />.
    /// </summary>
    public interface IChainableNullableBoolCondition
        : IChainableNullableBoolNotCondition,
          IChainableConditionBase<bool?, IChainableNullableBoolCondition, IChainableNullableBoolNotCondition, IChainableNullableBoolDoesNotCondition>
    {
        /// <summary>
        /// Determines whether the source nullable <see cref="bool"/> is <see langword="true"/>.
        /// </summary>
        /// <remarks>
        /// The result of the condition will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>
        /// </remarks>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> True { get; }

        /// <summary>
        /// Determines whether the source nullable <see cref="bool"/> is <see langword="false"/>.
        /// </summary>
        /// <remarks>
        /// The result of the condition will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>
        /// </remarks>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> False { get; }
    }
}