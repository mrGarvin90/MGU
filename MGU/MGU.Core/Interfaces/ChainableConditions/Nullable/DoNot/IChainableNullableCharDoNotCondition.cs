namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableCharDoNotCondition : IChainableComparableDoNotConditionBase<char?, IChainableNullableCharCondition>
    {
    }
}