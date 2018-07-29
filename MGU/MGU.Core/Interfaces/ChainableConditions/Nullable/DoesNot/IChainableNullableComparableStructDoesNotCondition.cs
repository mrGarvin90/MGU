namespace MGU.Core.Interfaces.ChainableConditions.Nullable.DoesNot
{
    using System;
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all nullable structs that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableNullableComparableStructDoesNotCondition<TSource> : IChainableComparableDoesNotConditionBase<TSource?, IChainableNullableComparableStructCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}