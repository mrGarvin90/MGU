namespace MGU.Core.Interfaces.ChainableConditions.Nullable.Not
{
    using System;
    using Base.Not;
    using Nullable;

    /// <inheritdoc cref="IChainableComparableNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <inheritdoc cref="IChainableNullableNotConditionBase{TSource,TChainableCondition}" />
    /// <summary>
    /// Defines chainable conditions for all classes that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    public interface IChainableComparableClassNotCondition<TSource>
        : IChainableComparableNotConditionBase<TSource, IChainableComparableClassCondition<TSource>>,
          IChainableNullableNotConditionBase<TSource, IChainableComparableClassCondition<TSource>>
        where TSource : class, IComparable<TSource>
    {
    }
}