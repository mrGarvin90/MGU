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
        /// Determines whether the source nullable <see cref="bool"/> is <c>true</c>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="bool"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> True { get; }

        /// <summary>
        /// Determines whether the source nullable <see cref="bool"/> is <c>false</c>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="bool"/> is <c>null</c>
        /// </remarks>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> False { get; }
    }
}