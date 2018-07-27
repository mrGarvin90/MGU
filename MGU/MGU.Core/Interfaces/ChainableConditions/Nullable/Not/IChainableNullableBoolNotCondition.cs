namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using Base.Not;

    /// <inheritdoc cref="IChainableNotConditionBase{TSource,TChainableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="bool"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableBoolNotCondition
        : IChainableNotConditionBase<bool?, IChainableNullableBoolCondition>,
          IChainableNullableNotConditionBase<bool?, IChainableNullableBoolCondition>
    {
    }
}