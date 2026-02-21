using System;
using System.Globalization;
using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements;

/// <summary>
/// Handles <c>note</c> xml element.
/// </summary>
public sealed class NoteElement : IElement
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "note";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "we want the lower case")]
    public void Write(IWriter writer, XElement element)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(element);

        if (writer.GetDisplayAsSingleLine())
        {
            writer.Append("...");

            return;
        }

        string? type = element.GetTypeAttribute()?.ToLower(CultureInfo.InvariantCulture);
        string notePrefix = type switch
        {
            "note" or "tip" or "caution" or "warning" or "important" => char.ToUpper(type[0], CultureInfo.InvariantCulture) + type[1..],
            "security" or "security note" => "Security Note",
            "implement" => "Notes to Implementers",
            "inherit" => "Notes to Inheritors",
            "caller" => "Notes to Callers",

            "cs" or "csharp" or "c#" or "visual c#" or "visual c# note" => "C# Note",
            "vb" or "vbnet" or "vb.net" or "visualbasic" or "visual basic" or "visual basic note" => "VB.NET Note",
            "fs" or "fsharp" or "f#" => "F# Note",
            // Legacy languages; SandCastle supported
            "cpp" or "c++" or "visual c++" or "visual c++ note" => "C++ Note",
            "jsharp" or "j#" or "visual j#" or "visual j# note" => "J# Note",

            _ => string.Empty
        };

        using (writer.AppendAsRaw())
        {
            writer.EnsureLineStart();

            IWriter prefixedWriter = writer.ToPrefixedWriter("> ");
            if (!string.IsNullOrEmpty(notePrefix))
            {
                prefixedWriter
                    .Append("**")
                    .Append(notePrefix.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex()))
                    .AppendLine(":**  ");
            }

            prefixedWriter.AppendAsMarkdown(element);
        }
    }
}
