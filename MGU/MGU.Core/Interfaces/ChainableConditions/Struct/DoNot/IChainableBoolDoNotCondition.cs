namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="bool"/>.
    /// </summary>
    public interface IChainableBoolDoNotCondition : IChainableDoNotConditionBase<bool, IChainableBoolCondition>
    {
    }
}