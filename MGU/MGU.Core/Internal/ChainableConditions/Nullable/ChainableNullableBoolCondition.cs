namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.Not;
    using Core.Interfaces.Couplers;
    using Interfaces.ChainableConditions.Nullable.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableNullableBoolCondition" />
    /// <summary>
    /// The <see cref="ChainableNullableBoolCondition" /> class.
    /// </summary>
    internal sealed class ChainableNullableBoolCondition
        : ChainableConditionBase<bool?, IChainableNullableBoolCondition, IChainableNullableBoolNotCondition, IChainableNullableBoolDoesNotCondition>,
            IChainableNullableBoolCondition,
            IChainableNullableBoolDoesNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableBoolCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source <see cref="bool"/>.</param>
        internal ChainableNullableBoolCondition(bool? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<bool?, IChainableNullableBoolCondition> True => Evaluate(s => s.HasValue && s.Value);

        /// <inheritdoc />
        public IConditionCoupler<bool?, IChainableNullableBoolCondition> False => Evaluate(s => s.HasValue && !s.Value);

        /// <inheritdoc />
        protected override IChainableNullableBoolCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableNullableBoolNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableNullableBoolDoesNotCondition DoesNotCondition => this;
    }
}