namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for nullable <see cref="char"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IChainableNullableCharDoesNotCondition : IChainableComparableDoesNotConditionBase<char?, IChainableNullableCharCondition>
    {
    }
}