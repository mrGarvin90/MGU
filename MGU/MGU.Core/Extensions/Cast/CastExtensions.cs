namespace MGU.Core.Extensions.Cast
{
    using Interfaces.Options;
    using Internal.Options;

    /// <summary>
    /// Contains extension methods to cast an object to an other type.
    /// </summary>
    public static class CastExtensions
    {
        /// <summary>
        /// Gets options for casting the source object to an other type.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>A <see cref="ICastOption"/>.</returns>
        public static ICastOption Cast(this object source)
        {
            return new CastOption(source);
        }
    }
}