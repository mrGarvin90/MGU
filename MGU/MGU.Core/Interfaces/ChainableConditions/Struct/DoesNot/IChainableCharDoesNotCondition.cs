namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="char"/>.
    /// </summary>
    public interface IChainableCharDoesNotCondition : IChainableComparableDoesNotConditionBase<char, IChainableCharCondition>
    {
    }
}