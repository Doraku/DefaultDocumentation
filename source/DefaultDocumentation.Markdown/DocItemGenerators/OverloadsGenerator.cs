using System;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.DocItemGenerators;

/// <summary>
/// Implementation of the <see cref="IDocItemGenerator"/> to add <see cref="ConstructorOverloadsDocItem"/> and <see cref="MethodOverloadsDocItem"/> to the documentation generated.
/// </summary>
public sealed class OverloadsGenerator : IDocItemGenerator
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Overloads";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Generate(IDocItemsContext context)
    {
        context.ThrowIfNull();

        if (context.Settings.GeneratedPages.HasFlag(GeneratedPages.Constructors))
        {
            foreach (IGrouping<TypeDocItem, ConstructorDocItem> group in context
                .Items
                .Values
                .OfType<ConstructorDocItem>()
                .GroupBy(item => (TypeDocItem)item.Parent!)
                .Where(group => group.Skip(1).Any())
                .ToArray())
            {
                ConstructorOverloadsDocItem newItem = new(group.Key);

                context.Items.Add(newItem.Id, newItem);
                context.ItemsWithOwnPage.Add(newItem);

                foreach (ConstructorDocItem constructorItem in group)
                {
                    context.ItemsWithOwnPage.Remove(constructorItem);
                }
            }
        }

        if (context.Settings.GeneratedPages.HasFlag(GeneratedPages.Methods))
        {
            foreach (IGrouping<(TypeDocItem Parent, string Name), MethodDocItem> group in context
                .Items
                .Values
                .OfType<MethodDocItem>()
                .GroupBy(item => (Parent: (TypeDocItem)item.Parent!, item.Method.Name))
                .Where(group => group.Skip(1).Any())
                .ToArray())
            {
                MethodOverloadsDocItem newItem = new(group.Key.Parent, group.Key.Name);

                context.Items.Add(newItem.Id, newItem);
                context.ItemsWithOwnPage.Add(newItem);

                foreach (MethodDocItem methodItem in group)
                {
                    context.ItemsWithOwnPage.Remove(methodItem);
                }
            }
        }
    }
}
