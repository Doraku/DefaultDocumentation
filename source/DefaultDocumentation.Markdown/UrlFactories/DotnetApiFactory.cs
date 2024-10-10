using System;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.UrlFactories;

/// <summary>
/// Transforms any id as a dotnet api url.
/// </summary>
public sealed class DotnetApiFactory : IUrlFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "DotnetApi";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public string GetUrl(IPageContext context, string id)
    {
        context.ThrowIfNull();
        id.ThrowIfNull();

        id = id[2..];
        int parametersIndex = id.IndexOf("(", StringComparison.Ordinal);
        if (parametersIndex > 0)
        {
            string methodName = id[..parametersIndex];

            id = $"{methodName}#{id.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
        }

        return "https://docs.microsoft.com/en-us/dotnet/api/" + id.Replace('`', '-');
    }
}
