namespace MGU.Core.Internal.Conditions.Struct
{
    using System;
    using Base;
    using Core.Interfaces.Conditions.Struct;
    using Core.Interfaces.Conditions.Struct.Not;

    /// <inheritdoc cref="ComparableConditionBase{TSource,TComparableNotCondition}"/>
    /// <inheritdoc cref="IComparableStructCondition{TSource}"/>
    /// <summary>
    /// The <see cref="ComparableStructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source struct.</typeparam>
    internal sealed class ComparableStructCondition<TSource>
        : ComparableConditionBase<TSource, IComparableStructNotCondition<TSource>>,
          IComparableStructCondition<TSource>
        where TSource : struct, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableStructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The comparable source struct.</param>
        internal ComparableStructCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IComparableStructNotCondition<TSource> NotCondition => this;
    }
}