namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IChainableDoNotCondition<TSource> : IChainableDoNotConditionBase<TSource, IChainableCondition<TSource>>
    {
    }
}