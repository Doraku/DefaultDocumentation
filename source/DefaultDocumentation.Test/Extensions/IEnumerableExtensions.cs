using System.Collections.Generic;

namespace System.Linq;

internal static class IEnumerableExtensions
{
    public static IEnumerable<T> IntoEnumerable<T>(this T item) => Enumerable.Repeat(item, 1);

    public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item) => source.Concat(item.IntoEnumerable());
}
