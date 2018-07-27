namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="char"/>.
    /// </summary>
    public interface IChainableCharDoNotCondition : IChainableComparableDoNotConditionBase<char, IChainableCharCondition>
    {
    }
}