namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using System;
    using Base.DoesNot;
    using Nullable;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all classes that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    public interface IChainableComparableClassDoesNotCondition<TSource> : IChainableComparableDoesNotConditionBase<TSource, IChainableComparableClassCondition<TSource>>
        where TSource : class, IComparable<TSource>
    {
    }
}