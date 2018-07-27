namespace MGU.Core.Interfaces.Conditions.Enumerable
{
    using Base;
    using Not;

    /// <inheritdoc cref="IStringNotCondition" />
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}" />
    /// <summary>
    /// Defines conditions for <see cref="string"/>.
    /// </summary>
    public interface IStringCondition : IStringNotCondition, IEnumerableConditionBase<string, char, IStringNotCondition>
    {
    }
}