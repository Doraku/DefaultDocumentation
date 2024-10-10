using System;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write a link to the top level documentation page.
/// </summary>
public sealed class HeaderSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Header";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        writer.ThrowIfNull();

        if (writer.GetCurrentItem() != writer.Context.DocItem)
        {
            return;
        }

        AssemblyDocItem assembly = writer.Context.Items.Values.OfType<AssemblyDocItem>().Single();
        if (assembly.HasOwnPage(writer.Context))
        {
            writer
                .EnsureLineStart()
                .Append("#### ")
                .AppendLink(assembly);
        }

        bool firstWritten = false;
        foreach (DocItem parent in writer.Context.DocItem.GetParents().Skip(1))
        {
            if (!firstWritten)
            {
                firstWritten = true;
                writer
                    .EnsureLineStart()
                    .Append("### ");
            }
            else
            {
                writer.Append(".");
            }

            writer.AppendLink(parent);
        }
    }
}
