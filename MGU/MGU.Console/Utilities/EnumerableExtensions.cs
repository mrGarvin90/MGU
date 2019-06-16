namespace MGU.Console.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumerableExtensions
    {
        public static string EnumerableToString<T>(this IEnumerable<T> enumerable)
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in enumerable)
                stringBuilder.Append(obj);
            return stringBuilder.ToString();
        }

        public static string EnumerableRangeToString<T>(this IEnumerable<T> enumerable, int index, int count)
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            var stringBuilder = new StringBuilder();
            for (var i = index; i < index + count; i++)
                stringBuilder.Append(array[i]);
            return stringBuilder.ToString();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => !enumerable.Any();
    }
}