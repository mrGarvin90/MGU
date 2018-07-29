namespace MGU.Core.Internal.Conditions.Base
{
    using System;
    using Core.Interfaces.Conditions.Base;
    using Core.Interfaces.Conditions.Base.Not;
    using Extensions;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}"/>
    /// <summary>
    /// The <see cref="NullableComparableStructConditionBase{TSource,TComparableNotCondition}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable source struct.</typeparam>
    /// <typeparam name="TComparableNotCondition">The type of the comparable not condition.</typeparam>
    internal abstract class NullableComparableStructConditionBase<TSource, TComparableNotCondition>
        : ConditionBase<TSource?, TComparableNotCondition>,
          IComparableConditionBase<TSource?, TComparableNotCondition>
        where TSource : struct, IComparable<TSource>
        where TComparableNotCondition : IComparableNotConditionBase<TSource?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableComparableStructConditionBase{TSource, TComparableNotCondition}"/> class.
        /// </summary>
        /// <param name="source">The nullable comparable source struct.</param>
        protected NullableComparableStructConditionBase(TSource? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool WithinRange(TSource? min, TSource? max)
        {
            return Result(Source.WithinRange(min, max));
        }

        /// <inheritdoc />
        public bool EqualTo(TSource? other)
        {
            return Result(Source.EqualTo(other));
        }

        /// <inheritdoc />
        public bool LessThan(TSource? other)
        {
            return Result(Source.LessThan(other));
        }

        /// <inheritdoc />
        public bool LessThanEqualTo(TSource? other)
        {
            return Result(Source.LessThanOrEqualTo(other));
        }

        /// <inheritdoc />
        public bool GreaterThan(TSource? other)
        {
            return Result(Source.GreaterThan(other));
        }

        /// <inheritdoc />
        public bool GreaterThanEqualTo(TSource? other)
        {
            return Result(Source.GreaterThanOrEqualTo(other));
        }
    }
}