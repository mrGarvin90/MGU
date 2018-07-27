namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using Base;
    using Not;

    /// <inheritdoc cref="INotCondition{TSource}" />
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}"/>
    /// <summary>
    /// Defines conditions for all types.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface ICondition<TSource>
        : INotCondition<TSource>,
          IConditionBase<TSource, INotCondition<TSource>>
    {
    }
}