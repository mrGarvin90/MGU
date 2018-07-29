namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using Base.Not;

    /// <inheritdoc cref="IChainableNotConditionBase{TSource,TChainableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// Defines chainable conditions for all objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    public interface IChainableNotCondition<TSource>
        : IChainableNotConditionBase<TSource, IChainableCondition<TSource>>,
          IChainableNullableNotConditionBase<TSource, IChainableCondition<TSource>>
    {
    }
}