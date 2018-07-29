namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using System;
    using Base.DoNot;
    using Nullable;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all classes that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    public interface IChainableComparableClassDoNotCondition<TSource> : IChainableComparableDoNotConditionBase<TSource, IChainableComparableClassCondition<TSource>>
        where TSource : class, IComparable<TSource>
    {
    }
}