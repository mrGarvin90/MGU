namespace MGU.Core.Internal.ChainableConditions.Base
{
    using System;
    using Core.Interfaces.ChainableConditions.Base;
    using Core.Interfaces.ChainableConditions.Base.Not;
    using Core.Interfaces.Couplers;
    using Extensions;
    using Interfaces.ChainableConditions.Base.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableComparableDoesNotConditionBase{TSource,TChainableComparableCondition}" />
    /// <summary>
    /// The <see cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source object.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    /// <typeparam name="TChainableComparableNotCondition">The type of the chainable comparable not condition.</typeparam>
    /// <typeparam name="TChainableComparableDoesNotCondition">The type of the chainable comparable does not condition.</typeparam>
    internal abstract class ChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoesNotCondition>
        : ChainableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoesNotCondition>,
          IChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoesNotCondition>,
          IChainableComparableDoesNotConditionBase<TSource, TChainableComparableCondition>
        where TSource : IComparable<TSource>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource, TChainableComparableCondition, TChainableComparableNotCondition, TChainableComparableDoesNotCondition>
        where TChainableComparableNotCondition : IChainableComparableNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableDoesNotCondition : IChainableComparableDoesNotConditionBase<TSource, TChainableComparableCondition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The comparable source object.</param>
        protected ChainableComparableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> WithinRange(TSource min, TSource max)
            => Evaluate(s => s.WithinRange(min, max));

        /// <inheritdoc cref="IChainableComparableConditionBase{TSource}" />
        public new IConditionCoupler<TSource, TChainableComparableCondition> EqualTo(TSource other)
            => Evaluate(s => s.EqualTo(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> LessThan(TSource other)
            => Evaluate(s => s.LessThan(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> LessThanEqualTo(TSource other)
            => Evaluate(s => s.LessThanOrEqualTo(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> GreaterThan(TSource other)
            => Evaluate(s => s.GreaterThan(other));

        /// <inheritdoc />
        public IConditionCoupler<TSource, TChainableComparableCondition> GreaterThanEqualTo(TSource other)
            => Evaluate(s => s.GreaterThanOrEqualTo(other));
    }
}