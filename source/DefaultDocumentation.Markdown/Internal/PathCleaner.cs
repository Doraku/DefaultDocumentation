using System.Text.RegularExpressions;

namespace DefaultDocumentation.Markdown.Internal;

internal static class PathCleaner
{
    public static string Clean(string value, IGeneralContext context)
    {
        value = Regex.Replace(value, context.GetInvalidCharToTrimRegex() ?? @"[\=\ ]", string.Empty);
        value = Regex.Replace(value, context.GetInvalidCharToReplaceRegex() ?? @"[\\\<\>\:\*\?]", context.GetInvalidCharReplacement() ?? "_");

        return value;
    }
}
