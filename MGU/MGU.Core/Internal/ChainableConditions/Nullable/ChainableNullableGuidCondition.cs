namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using Base;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.ChainableConditions.Nullable.DoesNot;
    using Interfaces.ChainableConditions.Nullable.Not;
    using Interfaces.Couplers;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableNullableGuidCondition" />
    /// <inheritdoc cref="IChainableNullableGuidDoesNotCondition" />
    /// <summary>
    /// The <see cref="ChainableNullableGuidCondition" /> class.
    /// </summary>
    internal sealed class ChainableNullableGuidCondition
        : ChainableNullableComparableStructConditionBase<Guid, IChainableNullableGuidCondition, IChainableNullableGuidNotCondition, IChainableNullableGuidDoesNotCondition>,
            IChainableNullableGuidCondition,
            IChainableNullableGuidDoesNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableGuidCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source <see cref="Guid"/>.</param>
        public ChainableNullableGuidCondition(Guid? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<Guid?, IChainableNullableGuidCondition> Empty => Evaluate(s => s == Guid.Empty);

        /// <inheritdoc />
        protected override IChainableNullableGuidCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableNullableGuidNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableNullableGuidDoesNotCondition DoesNotCondition => this;
    }
}