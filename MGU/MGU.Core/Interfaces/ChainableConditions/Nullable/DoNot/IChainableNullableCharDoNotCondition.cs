namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>.
    /// </summary>
    public interface IChainableNullableCharDoNotCondition : IChainableComparableDoNotConditionBase<char?, IChainableNullableCharCondition>
    {
    }
}