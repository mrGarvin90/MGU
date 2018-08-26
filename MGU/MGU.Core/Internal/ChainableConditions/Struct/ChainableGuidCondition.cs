namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using System;
    using Base;
    using Interfaces.ChainableConditions.Struct;
    using Interfaces.ChainableConditions.Struct.DoesNot;
    using Interfaces.ChainableConditions.Struct.Not;
    using Interfaces.Couplers;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableGuidCondition" />
    /// <inheritdoc cref="IChainableGuidDoesNotCondition" />
    /// <summary>
    /// The <see cref="ChainableGuidCondition" /> class.
    /// </summary>
    internal sealed class ChainableGuidCondition
        : ChainableComparableConditionBase<Guid, IChainableGuidCondition, IChainableGuidNotCondition, IChainableGuidDoesNotCondition>,
            IChainableGuidCondition,
            IChainableGuidDoesNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableGuidCondition"/> class.
        /// </summary>
        /// <param name="source">The source <see cref="Guid"/>.</param>
        internal ChainableGuidCondition(Guid source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<Guid, IChainableGuidCondition> Empty => Evaluate(s => s == Guid.Empty);

        /// <inheritdoc />
        protected override IChainableGuidCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableGuidNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableGuidDoesNotCondition DoesNotCondition => this;
    }
}