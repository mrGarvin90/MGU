namespace MGU.Core.Interfaces.Conditions.Nullable.Not
{
    using Base.Not;

    /// <inheritdoc cref="INotConditionBase{TSource}" />
    /// <inheritdoc cref="INullableNotConditionBase" />
    /// <summary>
    /// Defines conditions for all types 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface INotCondition<TSource>
        : INotConditionBase<TSource>,
          INullableNotConditionBase
    {
    }
}