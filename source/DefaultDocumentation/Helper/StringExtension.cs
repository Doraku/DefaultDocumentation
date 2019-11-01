using System.Collections.Generic;

namespace DefaultDocumentation.Helper
{
    internal static class StringExtension
    {
        private static readonly IReadOnlyDictionary<string, string> _invalidStrings = new Dictionary<string, string>
        {
            [" "] = string.Empty,
            [","] = "_",
            ["."] = "-",
            ["["] = "-",
            ["]"] = "-",
            ["&lt;"] = "-",
            ["&gt;"] = "-",
        };

        public static string Clean(this string value)
        {
            foreach (KeyValuePair<string, string> pair in _invalidStrings)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
        }

        public static string AsDotNetApiLink(this string value)
        {
            string name = value;
            if (name.Contains("`"))
            {
                name = $"{name.Substring(0, name.IndexOf('`'))}&lt;&gt;";
            }

            return $"[{name}](https://docs.microsoft.com/en-us/dotnet/api/{value.Replace('`', '-')} '{name}')";
        }
    }
}
