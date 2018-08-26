namespace MGU.Core.Internal.Conditions.Nullable
{
    using System;
    using Base;
    using Interfaces.Conditions.Nullable;
    using Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="NullableComparableStructConditionBase{TSource,TComparableNotCondition}" />
    /// <inheritdoc cref="INullableGuidCondition" />
    /// <summary>
    /// The <see cref="NullableGuidCondition" /> class.
    /// </summary>
    internal sealed class NullableGuidCondition
        : NullableComparableStructConditionBase<Guid, INullableGuidNotCondition>,
            INullableGuidCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableGuidCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable comparable source struct.</param>
        public NullableGuidCondition(Guid? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool Empty => Result(Source == Guid.Empty);

        /// <inheritdoc />
        protected override INullableGuidNotCondition NotCondition => this;
    }
}