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
        writer.ThrowIfNull();

        DocItem currentItem = writer.GetCurrentItem();

        Action<IWriter>? action = currentItem switch
        {
            AssemblyDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Assembly"),
            NamespaceDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Namespace"),
            TypeDocItem typeItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} {typeItem.Type.Kind}"),
            ConstructorOverloadsDocItem => w => w.Append($"## {currentItem.Parent!.Name.SanitizeForMarkdown()} Constructors"),
            ConstructorDocItem => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Constructor"),
            EventDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Event"),
            FieldDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Field"),
            MethodOverloadsDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Method"),
            MethodDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Method"),
            OperatorDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Operator"),
            PropertyDocItem => w => w.Append($"## {currentItem.GetLongName().SanitizeForMarkdown()} Property"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IEvent => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Event"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Method"),
            ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => w => w.Append($"## {currentItem.Name.SanitizeForMarkdown()} Property"),
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
