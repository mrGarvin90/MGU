namespace MGU.Core.Interfaces.Conditions.Struct
{
    using System;
    using Base;
    using Not;

    /// <inheritdoc cref="IGuidNotCondition" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}" />
    /// <summary>
    /// Defines conditions for <see cref="Guid"/>.
    /// </summary>
    public interface IGuidCondition
        : IGuidNotCondition,
          IComparableConditionBase<Guid, IGuidNotCondition>
    {
    }
}