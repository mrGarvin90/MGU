namespace MGU.Core.Internal.Conditions.Struct
{
    using Base;
    using Core.Interfaces.Conditions.Struct;
    using Core.Interfaces.Conditions.Struct.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}" />
    /// <inheritdoc cref="IBoolCondition" />
    /// <summary>
    /// The <see cref="BoolCondition"/> class.
    /// </summary>
    internal sealed class BoolCondition
        : ConditionBase<bool, IBoolNotCondition>,
          IBoolCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolCondition"/> class.
        /// </summary>
        /// <param name="source">The source <see cref="bool"/>.</param>
        internal BoolCondition(bool source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool True => Source;

        /// <inheritdoc />
        public bool False => !Source;

        /// <inheritdoc />
        protected override IBoolNotCondition NotCondition => this;
    }
}