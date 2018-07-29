namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="bool"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableBoolDoNotCondition : IChainableDoNotConditionBase<bool?, IChainableNullableBoolCondition>
    {
    }
}