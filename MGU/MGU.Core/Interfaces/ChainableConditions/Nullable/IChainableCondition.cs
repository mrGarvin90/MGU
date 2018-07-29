namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for all objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IChainableCondition<TSource>
        : IChainableNotCondition<TSource>,
          IChainableConditionBase<TSource, IChainableCondition<TSource>, IChainableNotCondition<TSource>, IChainableDoesNotCondition<TSource>>
    {
    }
}