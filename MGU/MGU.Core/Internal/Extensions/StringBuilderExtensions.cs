namespace MGU.Core.Internal.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains extension methods for <see cref="StringBuilder"/>.
    /// </summary>
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>The source builder.</returns>
        internal static StringBuilder AppendValue<TValue>(this StringBuilder source, TValue value)
            => value == null
                ? source.Append("<null>")
                : source.Append("'").Append(value).Append("'");

        /// <summary>
        /// Appends the values.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="values">The values.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The source builder.</returns>
        internal static StringBuilder AppendValues<TValue>(this StringBuilder source, IEnumerable<TValue> values, string separator)
        {
            var vals = values?.ToArray();
            if (!vals?.Any() ?? true)
                return source;
            source.AppendValue(vals[0]);
            if (vals.Length == 1)
                return source;
            for (var index = 1; index < vals.Length; index++)
                source.Append(separator).AppendValue(vals[index]);
            return source;
        }

        /// <summary>
        /// Appends the values and types.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="values">The values.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The source builder.</returns>
        internal static StringBuilder AppendValuesAndTypes<TValue>(this StringBuilder source, IEnumerable<TValue> values, string separator)
        {
            var vals = values?.ToArray();
            if (!vals?.Any() ?? true)
                return source;
            source.AppendValue(vals[0]);
            AppendType(vals[0]);
            if (vals.Length == 1)
                return source;
            for (var index = 1; index < vals.Length; index++)
            {
                source.Append(separator).AppendValue(vals[index]);
                AppendType(vals[index]);
            }

            return source;

            void AppendType(TValue value)
                => source.Append(" : '").Append(value == null ? "<undefined>" : value.GetType().FullName).Append("'");
        }
    }
}