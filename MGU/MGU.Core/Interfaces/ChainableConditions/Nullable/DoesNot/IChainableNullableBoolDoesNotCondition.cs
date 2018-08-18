namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="bool"/>.
    /// </summary>
    public interface IChainableNullableBoolDoesNotCondition : IChainableDoesNotConditionBase<bool?, IChainableNullableBoolCondition>
    {
    }
}