namespace MGU.Core.Interfaces.Conditions.Base
{
    using Not;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines conditions for all objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TNotCondition">The type of the not condition.</typeparam>
    public interface IConditionBase<TSource, out TNotCondition> : INotConditionBase<TSource>
        where TNotCondition : INotConditionBase<TSource>
    {
        /// <summary>
        /// Gets the not conditions where the result of the conditions will be inverted.
        /// </summary>
        TNotCondition Not { get; }
    }
}