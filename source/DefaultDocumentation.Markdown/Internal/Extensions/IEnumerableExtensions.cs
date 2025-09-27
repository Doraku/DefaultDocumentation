using System.Collections.Generic;

namespace System.Linq;

internal static class IEnumerableExtensions
{
    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, Func<T, string> selector)
        // Fixes inconsistencies between net framework and net (core) ordering.
        => source.OrderBy(selector, StringComparer.OrdinalIgnoreCase);
}
