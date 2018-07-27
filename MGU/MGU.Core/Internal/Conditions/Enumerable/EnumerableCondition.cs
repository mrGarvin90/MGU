namespace MGU.Core.Internal.Conditions.Enumerable
{
    using System.Collections.Generic;
    using Base;
    using Core.Interfaces.Conditions.Enumerable;
    using Core.Interfaces.Conditions.Enumerable.Not;

    /// <inheritdoc cref="EnumerableConditionBase{TSource,TObject,TEnumerableNotConditionBase}" />
    /// <inheritdoc cref="IEnumerableCondition{TSource,TObject}" />
    /// <summary>
    /// The <see cref="EnumerableCondition{TSource,TObject}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    internal sealed class EnumerableCondition<TSource, TObject>
        : EnumerableConditionBase<TSource, TObject, IEnumerableNotCondition<TSource, TObject>>,
          IEnumerableCondition<TSource, TObject>
        where TSource : IEnumerable<TObject>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableCondition{TSource,TObject}"/> class.
        /// </summary>
        /// <param name="source">The enumerable source.</param>
        internal EnumerableCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IEnumerableNotCondition<TSource, TObject> NotCondition => this;
    }
}