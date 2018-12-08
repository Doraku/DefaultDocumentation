using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Helper
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

        private static readonly IReadOnlyDictionary<string, string> _operators =
            OperatorItem.OperatorNames
            .ToDictionary(p => p.Value + '(', p => p.Key + '(')
            .Concat(new Dictionary<string, string>
            {
                [" "] = "_",
                ["&lt;"] = "-",
                ["&gt;"] = "-"
            }).ToDictionary(p => p.Key, p => p.Value);

        private static string CleanForDotNetApiLink(this string value) => value.Replace('`', '-');

        public static string CleanForLink(this string value)
        {
            foreach (char c in _invalidLinkChars)
            {
                value = value.Replace(c, '-');
            }
            foreach (var pair in _operators)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
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

        public static string AsLink(this string value, string text = null) => $"[{text ?? value}](./{value.CleanForLink()}.md '{value}')";

        public static string AsLinkWithTarget(this string value, string target, string text) => $"[{text}](./{value.CleanForLink()}.md#{target.CleanForLink()} '{text}')";

        public static string AsPageLink(this string value, string text = null) => $"[{text ?? value}](#{value.CleanForLink()} '{value}')";
    }
}
