namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using Base;
    using Couplers;
    using DoNot;
    using JetBrains.Annotations;
    using Not;

    /// <inheritdoc cref="IChainableNullableBoolNotCondition" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="bool" />.
    /// </summary>
    public interface IChainableNullableBoolCondition
        : IChainableNullableBoolNotCondition,
          IChainableConditionBase<bool?, IChainableNullableBoolCondition, IChainableNullableBoolNotCondition, IChainableNullableBoolDoNotCondition>
    {
        /// <summary>
        /// Determines whether the source nullable <see cref="bool"/> is <see langword="true"/>. 
        /// The result of the condition will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>
        /// </summary>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> True { get; }

        /// <summary>
        /// Determines whether the source nullable <see cref="bool"/> is <see langword="false"/>. 
        /// The result of the condition will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>
        /// </summary>
        IConditionCoupler<bool?, IChainableNullableBoolCondition> False { get; }
    }
}