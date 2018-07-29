namespace MGU.Core.Interfaces.Couplers
{
    using ChainableConditions.Base;
    using Options;

    /// <inheritdoc />
    /// <summary>
    /// Defines different ways to couple conditions.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    public interface IConditionCoupler<TSource, out TChainableCondition> : IConditionResultOption<TSource>
        where TChainableCondition : IChainableConditionBase
    {
        /// <summary>
        /// Gets the and condition.
        /// </summary>
        TChainableCondition And { get; }

        /// <summary>
        /// Gets the or condition.
        /// </summary>
        TChainableCondition Or { get; }
    }
}