namespace MGU.Core.Interfaces.Conditions.Struct.Not
{
    using Base.Not;

    /// <inheritdoc />
    /// <summary>
    /// Defines conditions for <see cref="bool"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface IBoolNotCondition : INotConditionBase<bool>
    {
    }
}