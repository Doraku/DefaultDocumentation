using System;
using System.Linq;
using System.Text.RegularExpressions;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.DocItemGenerators;

/// <summary>
/// Implementation of the <see cref="IDocItemGenerator"/> to remove <see cref="DocItem"/> from the documentation generation based on <see href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_Exclude">Markdown.Exclude</see>.
/// </summary>
public sealed class ExcludeGenerator : IDocItemGenerator
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Exclude";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Generate(IDocItemsContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        void Remove(DocItem item)
        {
            context.Items.Remove(item.Id);
            context.ItemsWithOwnPage.Remove(item);

            foreach (DocItem child in context.Items.Values.Where(child => child.Parent == item).ToArray())
            {
                Remove(child);
            }
        }

        foreach (DocItem item in (context.GetSetting<string[]>("Markdown.Exclude") ?? [])
            .SelectMany(regex => context.Items.Values.Where(item => Regex.IsMatch(item.Id, regex)))
            .ToArray())
        {
            Remove(item);
        }
    }
}
