namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using System;
    using Base;
    using Not;

    /// <inheritdoc cref="IComparableClassNotCondition{TSource}" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for all classes that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source class.</typeparam>
    public interface IComparableClassCondition<TSource>
        : IComparableClassNotCondition<TSource>,
          IComparableConditionBase<TSource, IComparableClassNotCondition<TSource>>
        where TSource : class, IComparable<TSource>
    {
    }
}