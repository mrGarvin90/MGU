namespace MGU.Core.Interfaces.Options
{
    using Couplers;

    /// <inheritdoc cref="IConditionResultOption{TSource}" />
    /// <summary>
    /// Defines options performed after the specified conditions are evaluated.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface INotTypeConditionResultOption<TSource> : IConditionResultOption<TSource>
    {
        /// <summary>
        /// Uses the specified value as the source object for a <see cref="IConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns><see cref="INotTypeConditionResultOptionCoupler{TValue}"/></returns>
        INotTypeConditionResultOptionCoupler<TValue> Use<TValue>(TValue value);
    }
}