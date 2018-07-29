namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableNullableCharNotCondition" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>.
    /// </summary>
    public interface IChainableNullableCharCondition
        : IChainableNullableCharNotCondition,
          IChainableComparableConditionBase<char?, IChainableNullableCharCondition, IChainableNullableCharNotCondition, IChainableNullableCharDoesNotCondition>
    {
    }
}