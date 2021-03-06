﻿namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using Base;
    using Not;

    /// <inheritdoc cref="INullableBoolNotCondition"/>
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for nullable <see cref="bool"/>.
    /// </summary>
    public interface INullableBoolCondition
        : INullableBoolNotCondition,
          IConditionBase<bool?, INullableBoolNotCondition>
    {
        /// <summary>
        /// Gets a value indicating whether the nullable source <see cref="bool"/> is <c>true</c>.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="bool"/> is <c>null</c>.
        /// </value>
        bool True { get; }

        /// <summary>
        /// Gets a value indicating whether the nullable source <see cref="bool"/> is <c>false</c>.
        /// </summary>
        /// <value>
        /// Will be <c>false</c> if the nullable source <see cref="bool"/> is <c>null</c>.
        /// </value>
        bool False { get; }
    }
}