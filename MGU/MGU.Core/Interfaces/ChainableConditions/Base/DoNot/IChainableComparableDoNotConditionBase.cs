namespace MGU.Core.Interfaces.ChainableConditions.Base.DoNot
{
    /// <inheritdoc cref="IChainableComparableConditionBase{TSource}" />
    /// <inheritdoc cref="IChainableDoNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for comparable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable.</typeparam>
    /// <typeparam name="TChainableComparableCondition">The type of the chainable comparable condition.</typeparam>
    public interface IChainableComparableDoNotConditionBase<TSource, out TChainableComparableCondition>
        : IChainableComparableConditionBase<TSource>,
          IChainableDoNotConditionBase<TSource, TChainableComparableCondition>
        where TChainableComparableCondition : IChainableComparableConditionBase<TSource>
    {
    }
}