namespace MGU.Core.Interfaces.ChainableConditions.Base.Not
{
    using Couplers;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines chainable conditions for all nullable objects 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    public interface IChainableNullableNotConditionBase<TSource, out TChainableCondition> : IChainableConditionBase
        where TChainableCondition : IChainableConditionBase
    {
        /// <summary>
        /// Determines whether the source object is <see langword="null"/>.
        /// </summary>
        IConditionCoupler<TSource, TChainableCondition> Null { get; }
    }
}