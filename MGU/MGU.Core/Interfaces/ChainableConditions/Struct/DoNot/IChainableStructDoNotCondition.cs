namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoNot
{
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all structs.
    /// </summary>
    /// <typeparam name="TSource">The type of the struct.</typeparam>
    public interface IChainableStructDoNotCondition<TSource> : IChainableDoNotConditionBase<TSource, IChainableStructCondition<TSource>>
        where TSource : struct
    {
    }
}