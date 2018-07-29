namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableStructNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}"/>
    /// <summary>
    /// Defines chainable conditions for all structs.
    /// </summary>
    /// <typeparam name="TSource">The type of the struct.</typeparam>
    public interface IChainableStructCondition<TSource>
        : IChainableStructNotCondition<TSource>,
          IChainableConditionBase<TSource, IChainableStructCondition<TSource>, IChainableStructNotCondition<TSource>, IChainableStructDoesNotCondition<TSource>>
        where TSource : struct
    {
    }
}