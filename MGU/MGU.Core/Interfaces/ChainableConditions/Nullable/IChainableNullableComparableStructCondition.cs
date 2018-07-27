namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using System;
    using Base;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableNullableComparableStructNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for all nullable structs that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableNullableComparableStructCondition<TSource>
        : IChainableNullableComparableStructNotCondition<TSource>,
          IChainableComparableConditionBase<TSource?, IChainableNullableComparableStructCondition<TSource>, IChainableNullableComparableStructNotCondition<TSource>, IChainableNullableComparableStructDoNotCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}