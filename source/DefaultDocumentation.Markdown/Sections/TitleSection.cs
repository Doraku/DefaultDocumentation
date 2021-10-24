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
                    .EnsureLineStart()
                    .AppendLine()
                    .Append("<a name='")
                    .Append(url.Substring(startIndex, url.Length - startIndex))
                    .Append("'></a>");
            }

            _ = currentItem switch
            {
                AssemblyDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.Name} Assembly"),
                NamespaceDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.Name} Namespace"),
                TypeDocItem typeItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} {typeItem.Type.Kind}"),
                ConstructorDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.Name} Constructor"),
                EventDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Event"),
                FieldDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Field"),
                MethodDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Method"),
                OperatorDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Operator"),
                PropertyDocItem => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Property"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Method"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => writer
                    .EnsureLineStart()
                    .Append($"## {currentItem.LongName} Property"),
                EnumFieldDocItem enumFiedItem => writer
                    .EnsureLineStart()
                    .Append($"`{currentItem.Name}` {enumFiedItem.Field.GetConstantValue()}"),
                ParameterDocItem parameterItem => writer
                    .EnsureLineStart()
                    .Append($"`{currentItem.Name}` ")
                    .AppendLink(currentItem, parameterItem.Parameter.Type),
                TypeParameterDocItem typeParameterItem => writer
                    .EnsureLineStart()
                    .Append($"`{typeParameterItem.TypeParameter.Name}`"),
                _ => writer
            };
        }
    }
}
