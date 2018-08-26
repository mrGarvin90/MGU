namespace MGU.Core.Interfaces.Conditions.Nullable.Not
{
    using System;
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for nullable <see cref="Guid"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface INullableGuidNotCondition : IComparableNotConditionBase<Guid?>
    {
        /// <summary>
        /// Gets a value indicating whether the nullable source <see cref="Guid"/> is equal to <see cref="Guid.Empty"/>.
        /// </summary>
        /// <remarks>
        /// The condition will evaluate to <c>false</c> if the nullable source <see cref="Guid"/> is <c>null</c>
        /// </remarks>
        bool Empty { get; }
    }
}