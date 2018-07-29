namespace MGU.Core.Internal.Conditions.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces.Conditions.Base;
    using Core.Interfaces.Conditions.Base.Not;

    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}" />
    /// <inheritdoc cref="INullableNotConditionBase"/>
    /// <summary>
    /// The <see cref="ConditionBase{TSource,TNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TNotCondition">The type of the not condition.</typeparam>
    /// <seealso cref="INotConditionBase{TSource}" />
    internal abstract class ConditionBase<TSource, TNotCondition>
        : IConditionBase<TSource, TNotCondition>,
          INullableNotConditionBase
        where TNotCondition : INotConditionBase<TSource>
    {
        private bool _invertResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionBase{TSource,TNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        protected ConditionBase(TSource source)
        {
            Source = source;
        }

        /// <inheritdoc />
        public TNotCondition Not
        {
            get
            {
                _invertResult = true;
                return NotCondition;
            }
        }

        /// <inheritdoc />
        public bool Null => Result(Source == null);

        /// <summary>
        /// Gets the not condition.
        /// </summary>
        protected abstract TNotCondition NotCondition { get; }

        /// <summary>
        /// Gets the source object.
        /// </summary>
        protected TSource Source { get; }

        /// <inheritdoc />
        public bool In(IEnumerable<TSource> collection, IEqualityComparer<TSource> comparer = null)
        {
            return Result(collection.Contains(Source, comparer));
        }

        /// <summary>
        /// Inverts the condition if <see cref="Not"/> was called.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns><see langword="bool"/></returns>
        protected bool Result(bool condition)
        {
            return _invertResult ? !condition : condition;
        }
    }
}