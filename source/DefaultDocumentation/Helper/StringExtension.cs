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

        public static string Prettify(this string value)
        {
            int genericIndex = value.IndexOf('`');
            if (genericIndex > 0)
            {
                int memberIndex = value.IndexOf('.', genericIndex);
                value = $"{value.Substring(0, genericIndex)}&lt;&gt;{(memberIndex > 0 ? value.Substring(memberIndex) : string.Empty)}";
            }

            return value;
        }

        public static string AsLink(this string value, string displayedName) => $"[{displayedName.Prettify()}]({value} '{value}')";

        public static string AsDotNetApiLink(this string value, string displayedName = null)
        {
            displayedName = (displayedName ?? value).Prettify();

            string link = value;
            int parametersIndex = link.IndexOf("(");
            if (parametersIndex > 0)
            {
                string methodName = link.Substring(0, parametersIndex);

                link = $"{methodName}#{link.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
            }

            return $"[{displayedName}](https://docs.microsoft.com/en-us/dotnet/api/{link.Replace('`', '-')} '{value}')";
        }
    }
}
