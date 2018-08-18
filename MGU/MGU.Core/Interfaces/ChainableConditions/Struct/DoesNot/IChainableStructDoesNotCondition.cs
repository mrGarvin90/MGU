namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all structs.
    /// </summary>
    /// <typeparam name="TSource">The type of the struct.</typeparam>
    public interface IChainableStructDoesNotCondition<TSource> : IChainableDoesNotConditionBase<TSource, IChainableStructCondition<TSource>>
        where TSource : struct
    {
    }
}