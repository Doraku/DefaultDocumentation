namespace DefaultApiReference
{
    internal static class StringExtension
    {
        private static readonly char[] _invalidLinkChars = new[]
        {
            '.',
            ',',
            '#',
            '[',
            ']'
        };

        private static string CleanForDotNetApiLink(this string value) => value.Replace('`', '-');

        public static string CleanForLink(this string value)
        {
            foreach (char c in _invalidLinkChars)
            {
                value = value.Replace(c, '-');
            }
            
            return value.Replace(' ', '_').Replace("&lt;", "-").Replace("&gt;", "-");
        }

        public static string AsLinkTarget(this string value) => $"<a name='{value.CleanForLink()}'></a>";

        public static string AsDotNetApiLink(this string value)
        {
            string name = value;
            if (name.Contains('`'))
            {
                name = $"{name.Substring(0, name.IndexOf('`'))}&lt;&gt;";
            }

            return $"[{name}](https://docs.microsoft.com/en-us/dotnet/api/{value.CleanForDotNetApiLink()} '{name}')";
        }

        public static string AsLink(this string value, string text = null) => $"[{text ?? value}](./{value.CleanForLink()} '{value}')";

        public static string AsPageLink(this string value, string text = null) => $"[{text ?? value}](#{value.CleanForLink()} '{value}')";
    }
}
