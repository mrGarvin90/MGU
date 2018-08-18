namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>.
    /// </summary>
    public interface IChainableNullableCharDoesNotCondition : IChainableComparableDoesNotConditionBase<char?, IChainableNullableCharCondition>
    {
    }
}