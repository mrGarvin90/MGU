namespace MGU.Core.Interfaces.Conditions.Enumerable.Not
{
    using System.Collections.Generic;
    using Conditions.Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for all objects that implement <see cref="IEnumerable{TObject}"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    public interface IEnumerableNotCondition<TSource, in TObject> : IEnumerableNotConditionBase<TSource, TObject>
        where TSource : IEnumerable<TObject>
    {
    }
}