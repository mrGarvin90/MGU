namespace MGU.Core.Interfaces.Conditions.Base
{
    using System.Collections.Generic;
    using Not;

    /// <inheritdoc cref="IEnumerableNotConditionBase{TSource, TObject}" />
    /// <inheritdoc cref="IConditionBase{TSource, TEnumerableNotCondition}" />
    /// <summary>
    /// The base interface that defines conditions for enumerable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    /// <typeparam name="TEnumerableNotCondition">The type of the enumerable not condition.</typeparam>
    public interface IEnumerableConditionBase<TSource, in TObject, out TEnumerableNotCondition>
        : IEnumerableNotConditionBase<TSource, TObject>,
          IConditionBase<TSource, TEnumerableNotCondition>
        where TSource : IEnumerable<TObject>
        where TEnumerableNotCondition : IEnumerableNotConditionBase<TSource, TObject>
    {
    }
}