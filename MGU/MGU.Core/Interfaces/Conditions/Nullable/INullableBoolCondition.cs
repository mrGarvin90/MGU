namespace MGU.Core.Interfaces.Conditions.Nullable
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
        /// Gets a value indicating whether the nullable source <see cref="bool"/> is <see langword="true"/>.
        /// The value will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>.
        /// </summary>
        bool True { get; }

        /// <summary>
        /// Gets a value indicating whether the nullable source <see cref="bool"/> is <see langword="true"/>.
        /// The value will be <see langword="false"/> if the nullable source <see cref="bool"/> is <see langword="null"/>.
        /// </summary>
        bool False { get; }
    }
}