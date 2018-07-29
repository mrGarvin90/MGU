namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Core.Interfaces.Couplers;
    using Interfaces.ChainableConditions.Struct.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableBoolCondition" />
    /// <summary>
    /// The <see cref="ChainableBoolCondition" /> class.
    /// </summary>
    internal sealed class ChainableBoolCondition
        : ChainableConditionBase<bool, IChainableBoolCondition, IChainableBoolNotCondition, IChainableBoolDoesNotCondition>,
          IChainableBoolCondition,
          IChainableBoolDoesNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableBoolCondition"/> class.
        /// </summary>
        /// <param name="source">The source <see cref="bool"/>.</param>
        internal ChainableBoolCondition(bool source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<bool, IChainableBoolCondition> True => Evaluate(s => s);

        /// <inheritdoc />
        public IConditionCoupler<bool, IChainableBoolCondition> False => Evaluate(s => !s);

        /// <inheritdoc />
        protected override IChainableBoolCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableBoolNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableBoolDoesNotCondition DoesNotCondition => this;
    }
}