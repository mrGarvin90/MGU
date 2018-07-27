namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using Base;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableCharNotCondition" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for <see cref="char" />.
    /// </summary>
    public interface IChainableCharCondition
        : IChainableCharNotCondition,
          IChainableComparableConditionBase<char, IChainableCharCondition, IChainableCharNotCondition, IChainableCharDoNotCondition>
    {
    }
}