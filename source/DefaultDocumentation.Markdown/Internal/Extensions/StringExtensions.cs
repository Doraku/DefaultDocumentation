﻿using System.Text.RegularExpressions;

namespace System;

internal static class StringExtensions
{
    private static readonly char[] _linebreakChars = ['\r', '\n'];

    public static string SanitizeForMarkdown(this string value, string? regex) => Regex.Replace(value, regex ?? @"[\\\`\*_\{\}\[\]\<\>\(\)\#\+\-\.\!\|]", @"\$&");

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

    public static string? TrimLinebreakChars(this string? value) => value?.Trim(_linebreakChars);
}
