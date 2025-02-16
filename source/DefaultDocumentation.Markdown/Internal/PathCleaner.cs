using System.IO;
using System.Linq;

namespace DefaultDocumentation.Markdown.Internal;

internal static class PathCleaner
{
    private static readonly string[] _toTrimChars = [.. new[] { '=', ' ' }.Select(@char => $"{@char}")];
    private static readonly string[] _invalidChars = [.. new[] { '\"', '<', '>', ':', '*', '?' }.Concat(Path.GetInvalidPathChars()).Select(@char => $"{@char}")];

    public static string Clean(string value, string? invalidCharReplacement)
    {
        foreach (string toTrimChar in _toTrimChars)
        {
            value = value.Replace(toTrimChar, string.Empty);
        }

        invalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;

        foreach (string invalidChar in _invalidChars)
        {
            value = value.Replace(invalidChar, invalidCharReplacement);
        }

        return value.Trim('/');
    }
}
