namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="bool"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableBoolDoesNotCondition : IChainableDoesNotConditionBase<bool, IChainableBoolCondition>
    {
    }
}