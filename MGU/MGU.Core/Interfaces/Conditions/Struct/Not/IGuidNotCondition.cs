namespace MGU.Core.Interfaces.Conditions.Struct.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for <see cref="Guid"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IGuidNotCondition : IComparableNotConditionBase<Guid>
    {
        /// <summary>
        /// Gets a value indicating whether the source <see cref="Guid"/> is equal to <see cref="Guid.Empty"/>.
        /// </summary>
        bool Empty { get; }
    }
}