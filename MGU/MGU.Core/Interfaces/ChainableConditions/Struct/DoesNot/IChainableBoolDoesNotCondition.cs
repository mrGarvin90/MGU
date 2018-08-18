namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="bool"/>.
    /// </summary>
    public interface IChainableBoolDoesNotCondition : IChainableDoesNotConditionBase<bool, IChainableBoolCondition>
    {
    }
}