using System.Text.RegularExpressions;

namespace System;

internal static class StringExtensions
{
    private static readonly Regex _markdownSanitization = new(@"[\\\`\*_\{\}\[\]\<\>\(\)\#\+\-\.\!\|]", RegexOptions.Compiled);

    public static string SanitizeForMarkdown(this string value) => _markdownSanitization.Replace(value, @"\$&");

    public static string Prettify(this string value)
    {
        int genericIndex = value.IndexOf('`');
        if (genericIndex > 0)
        {
            int memberIndex = value.IndexOf('.', genericIndex);
            int argsIndex = value.IndexOf('(', genericIndex);
            if (memberIndex > 0)
            {
                value = $"{value[..genericIndex]}<>{Prettify(value[memberIndex..])}";
            }
            else if (argsIndex > 0)
            {
                value = $"{value[..genericIndex]}<>{Prettify(value[argsIndex..])}";
            }
            else if (value.IndexOf('(') < 0)
            {
                value = $"{value[..genericIndex]}<>";
            }
        }

        return value.Replace('`', '@').Replace("<", "&lt;").Replace(">", "&gt;");
    }

    public static string? NullIfEmpty(this string? value) => string.IsNullOrEmpty(value) ? null : value;
}
