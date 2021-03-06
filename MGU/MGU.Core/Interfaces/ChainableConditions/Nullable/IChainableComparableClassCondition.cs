﻿namespace MGU.Core.Interfaces.ChainableConditions.Nullable
{
    using System;
    using Base;
    using DoesNot;
    using Not;

    /// <inheritdoc cref="IChainableComparableClassNotCondition{TSource}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <summary>
    /// Defines chainable conditions for all classes that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    public interface IChainableComparableClassCondition<TSource>
        : IChainableComparableClassNotCondition<TSource>,
          IChainableComparableConditionBase<TSource, IChainableComparableClassCondition<TSource>, IChainableComparableClassNotCondition<TSource>, IChainableComparableClassDoesNotCondition<TSource>>
        where TSource : class, IComparable<TSource>
    {
    }
}