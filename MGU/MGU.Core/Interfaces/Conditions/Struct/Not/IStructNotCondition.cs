namespace MGU.Core.Interfaces.Conditions.Struct.Not
{
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for all structs
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source struct.</typeparam>
    public interface IStructNotCondition<TSource> : INotConditionBase<TSource>
        where TSource : struct
    {
    }
}