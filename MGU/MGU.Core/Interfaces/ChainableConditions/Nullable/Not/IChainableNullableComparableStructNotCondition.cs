namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}" />
    /// <summary>
    /// Defines chainable conditions for all nullable structs that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableNullableComparableStructNotCondition<TSource>
        : IChainableComparableNotConditionBase<TSource?, IChainableNullableComparableStructCondition<TSource>>,
          IChainableNullableNotConditionBase<TSource?, IChainableNullableComparableStructCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}