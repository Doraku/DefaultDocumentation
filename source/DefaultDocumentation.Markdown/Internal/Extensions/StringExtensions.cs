namespace System;

internal static class StringExtensions
{
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
