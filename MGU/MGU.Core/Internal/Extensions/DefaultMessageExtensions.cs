namespace MGU.Core.Internal.Extensions
{
    using Core.Helpers;

    /// <summary>
    /// Contains extension methods for <see cref="DefaultMessage"/>.
    /// </summary>
    internal static class DefaultMessageExtensions
    {
        /// <summary>
        /// Determines whether the default message is null or empty.
        /// </summary>
        /// <param name="defaultMessage">The default message.</param>
        /// <returns><see langword="true" /> if null or empty;
        /// otherwise, <see langword="false" />.
        /// </returns>
        internal static bool IsNullOrEmpty(this DefaultMessage defaultMessage)
        {
            return defaultMessage is null || string.IsNullOrEmpty(defaultMessage.Value);
        }
    }
}