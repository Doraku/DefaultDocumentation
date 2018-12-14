using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Helper
{
    internal static class StringExtension
    {
        private static readonly IReadOnlyDictionary<string, string> _operators =
            OperatorItem.OperatorNames
            .ToDictionary(p => p.Value + '(', p => p.Key + '(')
            .Concat(new Dictionary<string, string>
            {
                [" "] = "_",
                ["."] = "-",
                [","] = "-",
                ["#"] = "-",
                ["["] = "-",
                ["]"] = "-",
                ["&lt;"] = "-",
                ["&gt;"] = "-"
            }).ToDictionary(p => p.Key, p => p.Value);

        private static string CleanForDotNetApiLink(this string value) => value.Replace('`', '-');

        public static string CleanForLink(this string value)
        {
            foreach (KeyValuePair<string, string> pair in _operators)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
        }

        public static string AsDotNetApiLink(this string value)
        {
            string name = value;
            if (name.Contains('`'))
            {
                name = $"{name.Substring(0, name.IndexOf('`'))}&lt;&gt;";
            }

            return $"[{name}](https://docs.microsoft.com/en-us/dotnet/api/{value.CleanForDotNetApiLink()} '{name}')";
        }

        public static string AsLink(this string value) => $"[{value}](./{value.CleanForLink()}.md '{value}')";
    }
}
