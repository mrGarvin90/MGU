namespace MGU.Core.Internal.Conditions.Struct
{
    using System;
    using Base;
    using Interfaces.Conditions.Struct;
    using Interfaces.Conditions.Struct.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="IGuidCondition"/>
    /// <summary>
    /// The <see cref="GuidCondition"/> class.
    /// </summary>
    internal class GuidCondition
        : ComparableConditionBase<Guid, IGuidNotCondition>,
          IGuidCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCondition"/> class.
        /// </summary>
        /// <param name="source">The comparable source.</param>
        public GuidCondition(Guid source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool Empty => Result(Source == Guid.Empty);

        /// <inheritdoc />
        protected override IGuidNotCondition NotCondition => this;
    }
}