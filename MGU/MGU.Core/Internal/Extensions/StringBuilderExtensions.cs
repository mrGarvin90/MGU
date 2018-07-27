namespace MGU.Core.Internal.Extensions
{
    using System.Text;

    /// <summary>
    /// Contains extension methods for <see cref="StringBuilder"/>.
    /// </summary>
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the value.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        internal static StringBuilder AppendValue(this StringBuilder builder, object obj)
        {
            return obj is null ? builder.Append("<null>") : builder.Append("'").Append(obj).Append("'");
        }
    }
}