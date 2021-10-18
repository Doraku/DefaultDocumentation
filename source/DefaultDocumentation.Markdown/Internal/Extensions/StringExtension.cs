namespace System
{
    internal static class StringExtension
    {
        public static string NullIfEmpty(this string value) => string.IsNullOrEmpty(value) ? null : value;
    }
}
