namespace MGU.Core.Internal.Conditions.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces.Conditions.Base;
    using Core.Interfaces.Conditions.Base.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}" />
    /// <inheritdoc cref="IEnumerableNotConditionBase{TSource,TObject}" />
    /// <summary>
    /// The <see cref="EnumerableConditionBase{TSource,TObject,TEnumerableNotConditionBase}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    /// <typeparam name="TEnumerableNotConditionBase">The type of the enumerable not condition.</typeparam>
    internal abstract class EnumerableConditionBase<TSource, TObject, TEnumerableNotConditionBase>
        : ConditionBase<TSource, TEnumerableNotConditionBase>,
          IEnumerableConditionBase<TSource, TObject, TEnumerableNotConditionBase>
        where TSource : IEnumerable<TObject>
        where TEnumerableNotConditionBase : IEnumerableNotConditionBase<TSource, TObject>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableConditionBase{TSource,TObject,TEnumerableNotConditionBase}"/> class.
        /// </summary>
        /// <param name="source">The enumerable source.</param>
        protected EnumerableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool Empty => Result(!Source.Any());
        
        /// <inheritdoc />
        public bool NullOrEmpty => Result(Source == null || !Source.Any());
    }
}