namespace MGU.Core.Internal.Conditions.Nullable
{
    using System;
    using Base;
    using Core.Interfaces.Conditions.Nullable;
    using Core.Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="ComparableConditionBase{TSource,TComparableNotCondition}"/>
    /// <inheritdoc cref="IComparableClassCondition{TSource}"/>
    /// <summary>
    /// The <see cref="ComparableClassCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source class.</typeparam>
    internal sealed class ComparableClassCondition<TSource>
        : ComparableConditionBase<TSource, IComparableClassNotCondition<TSource>>,
          IComparableClassCondition<TSource>
        where TSource : class, IComparable<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableClassCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The comparable source class.</param>
        internal ComparableClassCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IComparableClassNotCondition<TSource> NotCondition => this;
    }
}