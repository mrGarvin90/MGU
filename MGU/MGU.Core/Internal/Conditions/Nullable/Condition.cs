namespace MGU.Core.Internal.Conditions.Nullable
{
    using Base;
    using Core.Interfaces.Conditions.Nullable;
    using Core.Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="ICondition{TSource}"/>
    /// <summary>
    /// The <see cref="Condition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    internal sealed class Condition<TSource>
        : ConditionBase<TSource, INotCondition<TSource>>,
          ICondition<TSource>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        internal Condition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override INotCondition<TSource> NotCondition => this;
    }
}