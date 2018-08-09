namespace MGU.Core.Interfaces.Options
{
    /// <summary>
    /// Defines methods for casting the source object to an other type.
    /// </summary>
    public interface ICastOption
    {
        /// <summary>
        /// Casts the source object to <typeparamref name="TTarget"/>.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="unboxBeforeCast">
        /// If set to <c>true</c> the source object will be unboxed before cast to
        /// <typeparamref name="TTarget"/>. This means that if the source object is an <see langword="int" />
        /// it can be cast to an <see langword="uint" />. Use with caution. Cast an <see langword="int"/> with
        /// a value of -1 to an <see langword="uint"/> will not throw an <see cref="System.InvalidCastException"/>.
        /// Instead it will return the max value of <see langword="uint"/>.
        /// </param>
        /// <exception cref="System.InvalidCastException">
        /// The source object could not be cast to <typeparamref name="TTarget"/>.
        /// </exception>
        /// <returns>The source object as <typeparamref name="TTarget"/>.</returns>
        TTarget To<TTarget>(bool unboxBeforeCast = false);

        /// <summary>
        /// Casts the source object to <typeparamref name="TTarget"/>.
        /// If the cast fails the default value of <typeparamref name="TTarget"/> will be returned.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="unboxBeforeCast">
        /// If set to <c>true</c> the source object will be unboxed before cast to
        /// <typeparamref name="TTarget"/>. This means that if the source object is an <see langword="int" />
        /// it can be cast to an <see langword="uint" />. Use with caution. Cast an <see langword="int"/> with
        /// a value of -1 to an <see langword="uint"/> will not throw an <see cref="System.InvalidCastException"/>.
        /// Instead it will return the max value of <see langword="uint"/>.
        /// </param>
        /// <returns>
        /// The source object as <typeparamref name="TTarget"/> if the cast is successful;
        /// otherwise the default value of <typeparamref name="TTarget"/>.
        /// </returns>
        TTarget ToOrDefault<TTarget>(bool unboxBeforeCast = false);
    }
}