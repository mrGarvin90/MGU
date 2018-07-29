namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableCharDoNotCondition : IChainableComparableDoNotConditionBase<char, IChainableCharCondition>
    {
    }
}