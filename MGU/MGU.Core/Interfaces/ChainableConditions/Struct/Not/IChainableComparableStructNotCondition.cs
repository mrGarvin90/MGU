namespace MGU.Core.Interfaces.ChainableConditions.Struct.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines chainable conditions for all structs that implement <see cref="IComparable{T}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable struct.</typeparam>
    public interface IChainableComparableStructNotCondition<TSource> : IChainableComparableNotConditionBase<TSource, IChainableComparableStructCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}