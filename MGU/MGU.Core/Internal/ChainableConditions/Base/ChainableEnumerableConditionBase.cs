namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.ChainableConditions.Enumerable.Count;
    using Core.Interfaces.Couplers;
    using Extensions;
    using Interfaces.ChainableConditions.Base.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableEnumerableConditionBase{TSource,TObject,TChainableEnumerableCondition,TChainableEnumerableNotCondition,TChainableEnumerableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableEnumerableDoesNotConditionBase{TSource,TObject,TChainableEnumerableCondition}"/>
    /// <inheritdoc cref="IChainableEnumerableCountCondition{TSource,TObject,TChainableEnumerableCondition}"/>
    /// <inheritdoc cref="IChainableEnumerableCountIsCondition{TSource,TObject,TChainableEnumerableCondition}"/>
    /// <summary>
    /// The <see cref="ChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the enumerable source object.</typeparam>
    /// <typeparam name="TObject">The type of the object that enumerable source object contains.</typeparam>
    /// <typeparam name="TChainableEnumerableCondition">The type of the chainable condition.</typeparam>
    /// <typeparam name="TChainableEnumerableNotCondition">The type of the chainable not condition.</typeparam>
    /// <typeparam name="TChainableEnumerableDoesNotCondition">The type of the chainable does not condition.</typeparam>
    internal abstract class ChainableEnumerableConditionBase<TSource, TObject, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>
        : ChainableConditionBase<TSource, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>,
          IChainableEnumerableConditionBase<TSource, TObject, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>,
          IChainableEnumerableDoesNotConditionBase<TSource, TObject, TChainableEnumerableCondition>,
          IChainableEnumerableCountCondition<TSource, TObject, TChainableEnumerableCondition>,
          IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>
        where TSource : IEnumerable<TObject>
        where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject, TChainableEnumerableCondition, TChainableEnumerableNotCondition, TChainableEnumerableDoesNotCondition>
        where TChainableEnumerableNotCondition : IChainableEnumerableNotConditionBase<TSource, TObject, TChainableEnumerableCondition>
        where TChainableEnumerableDoesNotCondition : IChainableEnumerableDoesNotConditionBase<TSource, TObject, TChainableEnumerableCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The enumerable source object.</param>
        protected ChainableEnumerableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IChainableEnumerableCountCondition<TSource, TObject, TChainableEnumerableCondition> Count => Couple(this);

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> Empty => Evaluate(s => !s.Any());

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> All(Func<TObject, bool> predicate)
        {
            return Evaluate(s => s.All(predicate));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> Any(Func<TObject, bool> predicate)
        {
            return Evaluate(s => s.Any(predicate));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> None(Func<TObject, bool> predicate)
        {
            return Evaluate(s => !s.Any(predicate));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> SequentiallyEqualTo(IEnumerable<TObject> other, IEqualityComparer<TObject> comparer = null)
        {
            return Evaluate(s => other != null && s.SequenceEqual(other, comparer));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> Contains(TObject value, IEqualityComparer<TObject> comparer = null)
        {
            return Evaluate(s => s.Contains(value, comparer));
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableEnumerableCondition> Contain(TObject value, IEqualityComparer<TObject> comparer = null)
        {
            return Contains(value, comparer);
        }

        #region IChainableEnumerableCountCondition

#pragma warning disable SA1201 // Elements must appear in the correct order
        /// <inheritdoc />
        IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition> IChainableEnumerableCountCondition<TSource, TObject, TChainableEnumerableCondition>.Is => Couple(this);

        /// <inheritdoc />
        IChainableEnumerableCountIsNotCondition<TSource, TObject, TChainableEnumerableCondition> IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>.Not
        {
            get
            {
                InvertResult = true;
                return Couple(this);
            }
        }

        /// <inheritdoc />
        IConditionCoupler<TSource, TChainableEnumerableCondition> IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>.LessThan(int value)
        {
            return Evaluate(s => s.Count() < value);
        }

        /// <inheritdoc />
        IConditionCoupler<TSource, TChainableEnumerableCondition> IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>.LessThanEqualTo(int value)
        {
            return Evaluate(s => s.Count() <= value);
        }

        /// <inheritdoc />
        IConditionCoupler<TSource, TChainableEnumerableCondition> IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>.GreaterThan(int value)
        {
            return Evaluate(s => s.Count() > value);
        }

        /// <inheritdoc />
        IConditionCoupler<TSource, TChainableEnumerableCondition> IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition>.GreaterThanEqualTo(int value)
        {
            return Evaluate(s => s.Count() >= value);
        }

        /// <inheritdoc />
        IConditionCoupler<TSource, TChainableEnumerableCondition> IChainableEnumerableCountIsNotCondition<TSource, TObject, TChainableEnumerableCondition>.WithinRange(int min, int max)
        {
            return Evaluate(s => s.Count().WithinRange(min, max));
        }

        #endregion
    }
}