namespace MGU.Core.Interfaces.ChainableConditions.Base.DoesNot
{
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource}" />
    /// <inheritdoc cref="IChainableDoesNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for comparable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    public interface IChainableComparableDoesNotConditionBase<TSource, out TChainableComparableCondition>
        : IChainableComparableConditionBase<TSource>,
          IChainableDoesNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource>
    {
    }
}