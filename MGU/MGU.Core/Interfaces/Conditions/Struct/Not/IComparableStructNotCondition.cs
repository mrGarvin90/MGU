namespace MGU.Core.Interfaces.Conditions.Struct.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for all structs that implement <see cref="IComparable{T}"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source.</typeparam>
    public interface IComparableStructNotCondition<TSource> : IComparableNotConditionBase<TSource>
        where TSource : struct , IComparable<TSource>
    {
    }
}