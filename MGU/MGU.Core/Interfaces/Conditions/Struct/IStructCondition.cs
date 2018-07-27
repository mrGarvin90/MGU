namespace MGU.Core.Interfaces.Conditions.Struct
{
    using Base;
    using Not;

    /// <inheritdoc cref="IStructNotCondition{TSource}" />
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}" />
    /// <summary>
    /// Defines conditions for all structs.
    /// </summary>
    /// <typeparam name="TSource">The type of the source struct.</typeparam>
    public interface IStructCondition<TSource>
        : IStructNotCondition<TSource>,
          IConditionBase<TSource, IStructNotCondition<TSource>>
        where TSource : struct
    {
    }
}