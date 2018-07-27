namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using Base;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableStructNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}"/>
    /// <summary>
    /// Defines chainable conditions for all structs.
    /// </summary>
    /// <typeparam name="TSource">The type of the struct.</typeparam>
    public interface IChainableStructCondition<TSource>
        : IChainableStructNotCondition<TSource>,
          IChainableConditionBase<TSource, IChainableStructCondition<TSource>, IChainableStructNotCondition<TSource>, IChainableStructDoNotCondition<TSource>>
        where TSource : struct
    {
    }
}