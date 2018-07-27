namespace MGU.Core.Internal.Conditions.Struct
{
    using Base;
    using Core.Interfaces.Conditions.Struct;
    using Core.Interfaces.Conditions.Struct.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="IStructCondition{TSource}"/>
    /// <summary>
    /// The <see cref="StructCondition{TSource}"/> class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source struct.</typeparam>
    internal sealed class StructCondition<TSource>
        : ConditionBase<TSource, IStructNotCondition<TSource>>,
          IStructCondition<TSource>
        where TSource : struct
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="StructCondition{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source struct.</param>
        internal StructCondition(TSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IStructNotCondition<TSource> NotCondition => this;
    }
}