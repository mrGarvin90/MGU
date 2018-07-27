namespace MGU.Core.Interfaces.Conditions.Nullable.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc cref="IComparableNotConditionBase{TSource}" />
    /// <inheritdoc cref="INullableNotConditionBase" />
    /// <summary>
    /// Defines conditions for all classes that implement <see cref="IComparable{T}"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source class.</typeparam>
    public interface IComparableClassNotCondition<TSource>
        : IComparableNotConditionBase<TSource>,
          INullableNotConditionBase
        where TSource : class, IComparable<TSource>
    {
    }
}