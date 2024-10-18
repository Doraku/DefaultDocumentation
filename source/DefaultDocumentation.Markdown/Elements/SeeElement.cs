using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements;

/// <summary>
/// Handles <c>see</c> xml element.
/// </summary>
public sealed class SeeElement : IElement
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "see";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer, XElement element)
    {
        writer.ThrowIfNull();
        element.ThrowIfNull();

        string? displayName = element.Value.TrimLinebreakChars().NullIfEmpty();

        string? @ref = element.GetCRefAttribute();
        if (@ref is not null)
        {
            writer.AppendLink(@ref, displayName);
            return;
        }

        @ref = element.GetHRefAttribute();
        if (@ref is not null)
        {
            writer.AppendUrl(@ref, displayName);
            return;
        }

        @ref = element.GetLangWordAttribute();
        if (@ref is not null)
        {
            writer.AppendUrl(
                @ref switch
                {
                    "await" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await",
                    "false" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                    "true" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                    _ => $"https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/{@ref}"
                },
                displayName ?? @ref);
        }
    }
}
