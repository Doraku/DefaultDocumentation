using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Markdown;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation;

/// <summary>
/// Provides extension methods on the <see cref="IGeneralContext"/> type.
/// </summary>
public static class IGeneralContextExtensions
{
    private const string _nestedTypeVisibilitiesKey = "Markdown.NestedTypeVisibilities";
    private const string _removeFileExtensionFromUrlKey = "Markdown.RemoveFileExtensionFromUrl";
    private const string _invalidCharReplacementKey = "Markdown.InvalidCharReplacement";
    private const string _useFullUrlKey = "Markdown.UseFullUrl";
    private const string _markdownSanitizationRegex = "Markdown.MarkdownSanitizationRegex";

    /// <summary>
    /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_NestedTypeVisibilities">Markdown.NestedTypeVisibilities</see> setting.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <param name="type">The <see cref="Type"/> for which to get the setting.</param>
    /// <returns>The <see cref="NestedTypeVisibilities"/> to use.</returns>
    public static NestedTypeVisibilities GetNestedTypeVisibilities(this IGeneralContext context, Type type)
    {
        context.ThrowIfNull();
        type.ThrowIfNull();

        NestedTypeVisibilities value = context.GetSetting(type, context => context.GetSetting<NestedTypeVisibilities?>(_nestedTypeVisibilitiesKey)) ?? NestedTypeVisibilities.Default;

        if (value is NestedTypeVisibilities.Default)
        {
            value = NestedTypeVisibilities.Namespace;
        }

        return value;
    }

    /// <summary>
    /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_RemoveFileExtensionFromUrl">Markdown.RemoveFileExtensionFromUrl</see> setting.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <returns>Whether to include the file extension in urls.</returns>
    public static bool GetRemoveFileExtensionFromUrl(this IGeneralContext context)
    {
        context.ThrowIfNull();

        return context.GetSetting<bool>(_removeFileExtensionFromUrlKey);
    }

    /// <summary>
    /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_InvalidCharReplacement">Markdown.InvalidCharReplacement</see> setting.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <returns>The <see cref="string"/> to use to replace invalid chars in generated file name.</returns>
    public static string? GetInvalidCharReplacement(this IGeneralContext context)
    {
        context.ThrowIfNull();

        return context.GetSetting<string>(_invalidCharReplacementKey);
    }

    /// <summary>
    /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_UseFullUrl">Markdown.UseFullUrl</see> setting.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    public static bool GetUseFullUrl(this IGeneralContext context)
    {
        context.ThrowIfNull();

        return context.GetSetting<bool>(_useFullUrlKey);
    }

    /// <summary>
    /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#Markdown_MarkdownSanitizationRegex">Markdown.MarkdownSanitizationRegex</see> setting.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    public static string? GetMarkdownSanitizationRegex(this IGeneralContext context)
    {
        context.ThrowIfNull();

        return context.GetSetting<string>(_markdownSanitizationRegex);
    }

    /// <summary>
    /// Gets the children of a specific <see cref="DocItem"/> type of a <see cref="DocItem"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the children to look for.</typeparam>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <param name="item">The <see cref="DocItem"/> instance for which to get its children.</param>
    /// <returns>The children of the provided <see cref="DocItem"/>.</returns>
    public static IEnumerable<T> GetChildren<T>(this IGeneralContext context, DocItem item)
        where T : DocItem
    {
        context.ThrowIfNull();
        item.ThrowIfNull();

        IEnumerable<DocItem> GetAllChildren(DocItem item)
        {
            foreach (DocItem child in context.Items.Values.Where(child => child.Parent == item))
            {
                yield return child;
                foreach (DocItem indirectChild in GetAllChildren(child))
                {
                    yield return indirectChild;
                }
            }
        }

        return (item switch
        {
            NamespaceDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && context.GetNestedTypeVisibilities(typeof(T)).HasFlag(NestedTypeVisibilities.Namespace) => GetAllChildren(item),
            TypeDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && !context.GetNestedTypeVisibilities(typeof(T)).HasFlag(NestedTypeVisibilities.DeclaringType) => Enumerable.Empty<T>(),
            _ => context.Items.Values.Where(child => child.Parent == item)
        }).OfType<T>().OrderBy(child => child.FullName);
    }
}
