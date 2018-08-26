namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using System;
    using Base;
    using Not;

    /// <inheritdoc cref="INullableGuidNotCondition" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}" />
    /// <summary>
    /// Defines conditions for nullable <see cref="Guid"/>.
    /// </summary>
    public interface INullableGuidCondition
        : INullableGuidNotCondition,
          IComparableConditionBase<Guid?, INullableGuidNotCondition>
    {
    }
}