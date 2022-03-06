using System;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.UrlFactories
{
    public sealed class DotnetApiFactory : IUrlFactory
    {
        public string Name => "DotnetApi";

        public string GetUrl(IGeneralContext context, string id)
        {
            id = id.Substring(2);
            int parametersIndex = id.IndexOf("(", StringComparison.Ordinal);
            if (parametersIndex > 0)
            {
                string methodName = id.Substring(0, parametersIndex);

                id = $"{methodName}#{id.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
            }

            return "https://docs.microsoft.com/en-us/dotnet/api/" + id.Replace('`', '-');
        }
    }
}
