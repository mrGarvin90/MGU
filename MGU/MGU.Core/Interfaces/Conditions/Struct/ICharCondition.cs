namespace MGU.Core.Interfaces.Conditions.Struct
{
    using Base;
    using Not;

    /// <inheritdoc cref="ICharNotCondition" />
    /// <inheritdoc cref="IComparableConditionBase{TSource,TComparableNotCondition}" />
    /// <summary>
    /// Defines conditions for <see cref="char"/>.
    /// </summary>
    public interface ICharCondition
        : ICharNotCondition,
          IComparableConditionBase<char, ICharNotCondition>
    {
    }
}