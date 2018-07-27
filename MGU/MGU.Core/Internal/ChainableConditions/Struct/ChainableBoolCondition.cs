namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.DoNot;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Core.Interfaces.Couplers;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableBoolCondition" />
    /// <summary>
    /// The <see cref="ChainableBoolCondition" /> class.
    /// </summary>
    internal sealed class ChainableBoolCondition
        : ChainableConditionBase<bool, IChainableBoolCondition, IChainableBoolNotCondition, IChainableBoolDoNotCondition>,
          IChainableBoolCondition,
          IChainableBoolDoNotCondition
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableBoolCondition"/> class.
        /// </summary>
        /// <param name="source">The source <see cref="bool"/>.</param>
        internal ChainableBoolCondition(bool source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableBoolCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableBoolNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableBoolDoNotCondition DoNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<bool, IChainableBoolCondition> True => SetResult(s => s);

        /// <inheritdoc />
        public IConditionCoupler<bool, IChainableBoolCondition> False => SetResult(s => !s);
    }
}