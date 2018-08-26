namespace MGU.Core.Interfaces.Couplers
{
    using Options;

    /// <summary>
    /// The <see cref="INotTypeConditionResultOptionCoupler{TValue}"/> interface.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface INotTypeConditionResultOptionCoupler<TValue>
    {
        /// <summary>
        /// Gets the <see cref="IConditionResultOption{TValue}"/>.
        /// </summary>
        IConditionResultOption<TValue> And { get; }
    }
}