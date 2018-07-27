namespace MGU.Core.Interfaces.Conditions.Enumerable
{
    using System.Collections.Generic;
    using Base;
    using Not;

    /// <inheritdoc cref="IEnumerableNotCondition{TSource,TObject}"/>
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for all objects that implement <see cref="IEnumerable{TObject}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    public interface IEnumerableCondition<TSource, in TObject>
        : IEnumerableNotCondition<TSource, TObject>,
          IConditionBase<TSource, IEnumerableNotCondition<TSource, TObject>>
        where TSource : IEnumerable<TObject>
    {
    }
}