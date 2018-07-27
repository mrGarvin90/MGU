﻿namespace MGU.Core.Internal.Conditions.Base
{
    using System;
    using Core.Interfaces.Conditions.Base;
    using Core.Interfaces.Conditions.Base.Not;
    using Extensions;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}"/>
    /// <summary>
    /// The <see cref="ComparableConditionBase{TSource,TComparableNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source.</typeparam>
    /// <typeparam name="TComparableNotCondition">The type of the comparable not condition.</typeparam>
    /// <inheritdoc cref="ConditionBase{TSource, TComparableNotCondition}" />
    /// <inheritdoc cref="IComparableConditionBase{TSource, TComparableNotCondition}" />
    internal abstract class ComparableConditionBase<TSource, TComparableNotCondition>
        : ConditionBase<TSource, TComparableNotCondition>,
          IComparableConditionBase<TSource, TComparableNotCondition>
        where TSource : IComparable<TSource>
        where TComparableNotCondition : IComparableNotConditionBase<TSource>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableConditionBase{TSource, TComparableNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The comparable source.</param>
        protected ComparableConditionBase(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool WithinRange(TSource min, TSource max)
        {
            return Result(Source.WithinRange(min, max));
        }

        /// <inheritdoc />
        public bool EqualTo(TSource other)
        {
            return Result(Source.EqualTo(other));
        }

        /// <inheritdoc />
        public bool LessThan(TSource other)
        {
            return Result(Source.LessThan(other));
        }

        /// <inheritdoc />
        public bool LessThanEqualTo(TSource other)
        {
            return Result(Source.LessThanOrEqualTo(other));
        }

        /// <inheritdoc />
        public bool GreaterThan(TSource other)
        {
            return Result(Source.GreaterThan(other));
        }

        /// <inheritdoc />
        public bool GreaterThanEqualTo(TSource other)
        {
            return Result(Source.GreaterThanOrEqualTo(other));
        }
    }
}