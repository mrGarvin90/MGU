namespace MGU.Core.Interfaces.ChainableConditions.Struct.Not
{
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for <see cref="bool"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableBoolNotCondition : IChainableNotConditionBase<bool, IChainableBoolCondition>
    {
    }
}