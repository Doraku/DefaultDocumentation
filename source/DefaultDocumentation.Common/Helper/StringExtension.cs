namespace DefaultDocumentation.Helper
{
    internal static class StringExtension
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
                    value = $"{value.Substring(0, genericIndex)}&lt;&gt;{Prettify(value.Substring(memberIndex))}";
                }
                else if (argsIndex > 0)
                {
                    value = $"{value.Substring(0, genericIndex)}&lt;&gt;{Prettify(value.Substring(argsIndex))}";
                }
                else if (value.IndexOf('(') < 0)
                {
                    value = $"{value.Substring(0, genericIndex)}&lt;&gt;";
                }
            }

            return value.Replace('`', '@').Replace("<", "&lt;").Replace(">", "&gt;");
        }

        public static string NullIfEmpty(this string value) => string.IsNullOrEmpty(value) ? null : value;

        public static string ToDotNetApiUrl(this string id)
        {
            id = id.Substring(2);
            int parametersIndex = id.IndexOf("(");
            if (parametersIndex > 0)
            {
                string methodName = id.Substring(0, parametersIndex);

                id = $"{methodName}#{id.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
            }

            return "https://docs.microsoft.com/en-us/dotnet/api/" + id.Replace('`', '-');
        }
    }
}
