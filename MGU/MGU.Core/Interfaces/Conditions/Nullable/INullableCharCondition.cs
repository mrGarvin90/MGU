namespace MGU.Core.Interfaces.Conditions.Nullable
{
    using Base;
    using Not;
    using Struct.Not;

    /// <inheritdoc cref="INullableCharNotCondition" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}" />
    /// <summary>
    /// Defines conditions for nullable <see cref="char"/>.
    /// </summary>
    public interface INullableCharCondition
        : INullableCharNotCondition,
          IComparableConditionBase<char?, INullableCharNotCondition>
    {
    }
}