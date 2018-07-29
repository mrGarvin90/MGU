namespace MGU.Core.Internal.Conditions.Nullable
{
    using System;
    using Base;
    using Core.Interfaces.Conditions.Nullable;
    using Core.Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="NullableComparableStructConditionBase{TSource,TComparableNotCondition}"/>
    /// <inheritdoc cref="INullableComparableStructCondition{TSource}"/>
    /// <summary>
    /// The <see cref="NullableComparableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the nullable comparable source struct.</typeparam>
    internal sealed class NullableComparableStructCondition<TSource>
        : NullableComparableStructConditionBase<TSource, INullableComparableStructNotCondition<TSource>>,
          INullableComparableStructCondition<TSource>
        where TSource : struct, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableComparableStructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The nullable comparable source struct.</param>
        internal NullableComparableStructCondition(TSource? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override INullableComparableStructNotCondition<TSource> NotCondition => this;
    }
}