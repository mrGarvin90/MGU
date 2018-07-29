namespace MGU.Core.Interfaces.ChainableConditions.Struct.Not
{
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all structs
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the struct.</typeparam>
    public interface IChainableStructNotCondition<TSource> : IChainableNotConditionBase<TSource, IChainableStructCondition<TSource>>
        where TSource : struct
    {
    }
}