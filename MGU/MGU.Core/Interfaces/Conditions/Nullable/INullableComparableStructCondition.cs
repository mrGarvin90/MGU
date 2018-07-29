namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using System;
    using Base;
    using Not;

    /// <inheritdoc cref="INullableComparableStructNotCondition{TSource}"/>
    /// <inheritdoc cref="IComparableConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for all nullable structs that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable source struct.</typeparam>
    public interface INullableComparableStructCondition<TSource>
        : INullableComparableStructNotCondition<TSource>,
          IComparableConditionBase<TSource?, INullableComparableStructNotCondition<TSource>>
        where TSource : struct, IComparable<TSource>
    {
    }
}