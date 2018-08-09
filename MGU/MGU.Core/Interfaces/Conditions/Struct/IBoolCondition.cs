namespace MGU.Core.Interfaces.Conditions.Struct
{
    using Base;
    using Not;

    /// <inheritdoc cref="IBoolNotCondition"/>
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for <see cref="bool"/>.
    /// </summary>
    public interface IBoolCondition
        : IBoolNotCondition,
          IConditionBase<bool, IBoolNotCondition>
    {
        /// <summary>
        /// Gets a value indicating whether the source <see cref="bool"/> is <c>true</c>.
        /// </summary>
        bool True { get; }

        /// <summary>
        /// Gets a value indicating whether the source <see cref="bool"/> is <c>false</c>.
        /// </summary>
        bool False { get; }
    }
}