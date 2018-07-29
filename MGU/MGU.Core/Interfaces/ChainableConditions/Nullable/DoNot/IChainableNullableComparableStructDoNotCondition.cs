namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoNot
{
    using System;
    using Base.DoNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all nullable structs that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableNullableComparableStructDoNotCondition<TSource> : IChainableComparableDoNotConditionBase<TSource?, IChainableNullableComparableStructCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}