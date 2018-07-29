namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IChainableDoesNotCondition<TSource> : IChainableDoesNotConditionBase<TSource, IChainableCondition<TSource>>
    {
    }
}