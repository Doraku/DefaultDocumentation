using System;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TitleSection : ISection
    {
        public string Name => "Title";

        public void Write(IWriter writer)
        {
            DocItem currentItem = writer.GetCurrentItem();

            Action<IWriter>? action = currentItem switch
            {
                AssemblyDocItem => w => w.Append($"## {currentItem.Name} Assembly"),
                NamespaceDocItem => w => w.Append($"## {currentItem.Name} Namespace"),
                TypeDocItem typeItem => w => w.Append($"## {currentItem.GetLongName()} {typeItem.Type.Kind}"),
                ConstructorDocItem => w => w.Append($"## {currentItem.Name} Constructor"),
                EventDocItem => w => w.Append($"## {currentItem.GetLongName()} Event"),
                FieldDocItem => w => w.Append($"## {currentItem.GetLongName()} Field"),
                MethodDocItem => w => w.Append($"## {currentItem.GetLongName()} Method"),
                OperatorDocItem => w => w.Append($"## {currentItem.GetLongName()} Operator"),
                PropertyDocItem => w => w.Append($"## {currentItem.GetLongName()} Property"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IEvent => w => w.Append($"## {currentItem.GetLongName()} Event"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => w => w.Append($"## {currentItem.GetLongName()} Method"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => w => w.Append($"## {currentItem.GetLongName()} Property"),
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
                if (!currentItem.HasOwnPage(writer.Context))
                {
                    string url = writer.Context.GetUrl(currentItem);
                    int startIndex = url.IndexOf('#') + 1;
                    writer
                        .EnsureLineStartAndAppendLine()
                        .Append("<a name='")
                        .Append(url.Substring(startIndex, url.Length - startIndex))
                        .Append("'></a>");
                }

                writer.EnsureLineStartAndAppendLine();
                action(writer);
            }
        }
    }
}
