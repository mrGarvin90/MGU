namespace MGU.Core.Interfaces.Conditions.Base.Not
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The base interface that defines conditions for all objects that implement <see cref="IEnumerable{TObject}"/> 
    /// where the result of the conditions will be inverted.
    /// </summary>
    /// <typeparam name="TSource">The type of the source enumerable.</typeparam>
    /// <typeparam name="TObject">The type of the object that source enumerable contains.</typeparam>
    public interface IEnumerableNotConditionBase<TSource, in TObject> : INotConditionBase<TSource>
        where TSource : IEnumerable<TObject>
    {
        /// <summary>
        /// Gets a value indicating whether the source enumerable is empty.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// The source object is null.
        /// </exception>
        bool Empty { get; }

        /// <summary>
        /// Gets a value indicating whether the source enumerable is null or empty.
        /// </summary>
        bool NullOrEmpty { get; }
    }
}