namespace MGU.Core.Interfaces.Conditions.Nullable.Not
{
    using Base.Not;

    /// <inheritdoc cref="INotConditionBase{TSource}" />
    /// <inheritdoc cref="INullableNotConditionBase" />
    /// <summary>
    /// Defines conditions for nullable <see cref="bool"/>
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface INullableBoolNotCondition
        : INotConditionBase<bool?>,
          INullableNotConditionBase
    {
    }
}