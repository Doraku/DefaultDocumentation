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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "we want lowercase")]
    public string GetUrl(IPageContext context, string id)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(id);

        id = id[2..];
        int parametersIndex = id.IndexOf("(", StringComparison.Ordinal);
        if (parametersIndex > 0)
        {
            string methodName = id[..parametersIndex].Replace('#', '-');

            id = $"{methodName}#{id.Replace('.', '-').Replace(',', '-').Replace("#", string.Empty)}";
        }

        return $"https://learn.microsoft.com/en-us/dotnet/api/{id.Replace('`', '-').Replace(" ", string.Empty).ToLowerInvariant()}";
    }
}
