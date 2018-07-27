namespace MGU.Core.Interfaces.ChainableConditions.Struct
{
    using System;
    using Base;
    using DoNot;
    using Not;

    /// <inheritdoc cref="IChainableComparableStructNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for all structs that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableComparableStructCondition<TSource>
        : IChainableComparableStructNotCondition<TSource>,
          IChainableComparableConditionBase<TSource, IChainableComparableStructCondition<TSource>, IChainableComparableStructNotCondition<TSource>, IChainableComparableStructDoNotCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}