namespace MGU.Core.Internal.Conditions.Nullable
{
    using Base;
    using Core.Interfaces.Conditions.Nullable;
    using Core.Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}" />
    /// <inheritdoc cref="INullableBoolCondition" />
    /// <summary>
    /// The <see cref="NullableBoolCondition"/> class.
    /// </summary>
    internal sealed class NullableBoolCondition
        : ConditionBase<bool?, INullableBoolNotCondition>,
          INullableBoolCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBoolCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source <see cref="bool"/>.</param>
        internal NullableBoolCondition(bool? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool True => Source.HasValue && Source.Value;

        /// <inheritdoc />
        public bool False => Source.HasValue && !Source.Value;

        /// <inheritdoc />
        protected override INullableBoolNotCondition NotCondition => this;
    }
}