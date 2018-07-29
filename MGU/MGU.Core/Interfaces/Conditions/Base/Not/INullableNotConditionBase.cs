namespace MGU.Core.Interfaces.Conditions.Base.Not
{
    /// <summary>
    /// The base interface that defines conditions for all nullable objects
    /// where the result of the conditions will be inverted.
    /// </summary>
    public interface INullableNotConditionBase
    {
        /// <summary>
        /// Gets a value indicating whether the source object is null.
        /// </summary>
        bool Null { get; }
    }
}