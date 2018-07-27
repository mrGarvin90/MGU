namespace MGU.Core.Interfaces.Conditions.Struct
{
    using System;
    using Base;
    using Not;

    /// <inheritdoc cref="IComparableStructNotCondition{TSource}" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}" />
    /// <summary>
    /// Defines conditions for all structs that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source struct.</typeparam>
    public interface IComparableStructCondition<TSource>
        : IComparableStructNotCondition<TSource>,
          IComparableConditionBase<TSource, IComparableStructNotCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}