namespace MGU.Core.Interfaces.ChainableConditions.Struct.DoesNot
{
    using System;
    using Base.DoesNot;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all structs that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableComparableStructDoesNotCondition<TSource> : IChainableComparableDoesNotConditionBase<TSource, IChainableComparableStructCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}