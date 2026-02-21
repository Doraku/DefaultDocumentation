using System;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Models;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write a title of the <see cref="DocItem"/>.
/// </summary>
public sealed class TitleSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Title";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        DocItem currentItem = writer.GetCurrentItem();

        Action<IWriter>? action = currentItem switch
        {
            AssemblyDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Assembly"),
            NamespaceDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Namespace"),
            TypeDocItem typeItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} {typeItem.Type.Kind}"),
            ConstructorOverloadsDocItem => w => w.Append($"## {currentItem.Parent!.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Constructors"),
            ConstructorDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Constructor"),
            EventDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Event"),
            FieldDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Field"),
            MethodOverloadsDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Method"),
            MethodDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Method"),
            OperatorDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Operator"),
            PropertyDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Property"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IEvent => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Event"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Method"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown(writer.Context.GetMarkdownSanitizationRegex())} Property"),
            EnumFieldDocItem enumFiedItem => w => w
                .Append($"`{currentItem.Name}`")
                .Append(enumFiedItem.Field.IsConst ? $" {enumFiedItem.Field.GetConstantValue()}" : string.Empty),
            ParameterDocItem parameterItem => w => w
                .Append($"`{currentItem.Name}` ")
                .AppendLink(currentItem, parameterItem.Parameter.Type),
            TypeParameterDocItem typeParameterItem => w => w.Append($"`{typeParameterItem.TypeParameter.Name}`"),
            _ => null
        };

        if (action != null)
        {
            if (!writer.Context.ItemsWithOwnPage.Contains(currentItem))
            {
                string? url = writer.Context.GetUrl(currentItem);

                if (url != null)
                {
                    int startIndex = url.IndexOf('#') + 1;
                    writer
                        .EnsureLineStartAndAppendLine()
                        .Append("<a name='")
                        .Append(url[startIndex..])
                        .Append("'></a>");
                }
            }

            writer.EnsureLineStartAndAppendLine();
            action(writer);
        }
    }
}
