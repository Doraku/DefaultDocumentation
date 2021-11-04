using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TitleSection : ISectionWriter
    {
        public string Name => "Title";

        public void Write(IWriter writer)
        {
            DocItem currentItem = writer.GetCurrentItem();

            if (!writer.Context.HasOwnPage(currentItem))
            {
                string url = writer.Context.GetUrl(currentItem);
                int startIndex = url.IndexOf('#') + 1;
                writer
                    .EnsureLineStartAndAppendLine()
                    .Append("<a name='")
                    .Append(url.Substring(startIndex, url.Length - startIndex))
                    .Append("'></a>");
            }

            _ = currentItem switch
            {
                AssemblyDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.Name} Assembly"),
                NamespaceDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.Name} Namespace"),
                TypeDocItem typeItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} {typeItem.Type.Kind}"),
                ConstructorDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.Name} Constructor"),
                EventDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Event"),
                FieldDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Field"),
                MethodDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Method"),
                OperatorDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Operator"),
                PropertyDocItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Property"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IEvent => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Event"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Method"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"## {currentItem.LongName} Property"),
                EnumFieldDocItem enumFiedItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"`{currentItem.Name}` {enumFiedItem.Field.GetConstantValue()}"),
                ParameterDocItem parameterItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"`{currentItem.Name}` ")
                    .AppendLink(currentItem, parameterItem.Parameter.Type),
                TypeParameterDocItem typeParameterItem => writer
                    .EnsureLineStartAndAppendLine()
                    .Append($"`{typeParameterItem.TypeParameter.Name}`"),
                _ => writer
            };
        }
    }
}
