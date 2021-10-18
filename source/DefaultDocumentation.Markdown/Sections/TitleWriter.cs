using System.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writer;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TitleWriter : ISectionWriter
    {
        public string Name => "title";

        public void Write(PageWriter writer)
        {
            if (writer.PageItem == writer.CurrentItem)
            {
                AssemblyDocItem assembly = writer.Context.Items.OfType<AssemblyDocItem>().Single();
                if (writer.Context.HasOwnPage(assembly))
                {
                    writer
                        .EnsureLineStart()
                        .Append("#### ")
                        .AppendLink(assembly)
                        .AppendLine();
                }

                writer.EnsureLineStart();

                bool firstWritten = false;
                foreach (DocItem parent in writer.CurrentItem.GetParents().Skip(1))
                {
                    if (!firstWritten)
                    {
                        writer.Append("### ");
                        firstWritten = true;
                    }
                    else
                    {
                        writer.Append(".");
                    }

                    writer.AppendLink(parent);
                }
            }

            if (!writer.Context.HasOwnPage(writer.CurrentItem))
            {
                string url = writer.Context.GetUrl(writer.CurrentItem);
                int startIndex = url.IndexOf('#') + 1;
                writer
                    .EnsureLineStart()
                    .Append("<a name='")
                    .Append(url.Substring(startIndex, url.Length - startIndex))
                    .AppendLine("'></a>");
            }

            writer.EnsureLineStart();

            _ = writer.CurrentItem switch
            {
                NamespaceDocItem => writer.AppendLine($"## {writer.CurrentItem.Name} Namespace"),
                TypeDocItem typeItem => writer.AppendLine($"## {writer.CurrentItem.LongName} {typeItem.Type.Kind}"),
                ConstructorDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Constructor"),
                EventDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Event"),
                FieldDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Field"),
                MethodDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Method"),
                OperatorDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Operator"),
                PropertyDocItem => writer.AppendLine($"## {writer.CurrentItem.LongName} Property"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => writer.AppendLine($"## {writer.CurrentItem.LongName} Method"),
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => writer.AppendLine($"## {writer.CurrentItem.LongName} Property"),
                EnumFieldDocItem enumFiedItem => writer.AppendLine($"`{writer.CurrentItem.Name}` {enumFiedItem.Field.GetConstantValue()}  "),
                ParameterDocItem parameterItem => writer.Append($"`{writer.CurrentItem.Name}` ").AppendLink(writer.CurrentItem, parameterItem.Parameter.Type).AppendLine("  "),
                TypeParameterDocItem typeParameterItem => writer.AppendLine($"`{typeParameterItem.TypeParameter.Name}`  "),
                _ => writer
            };
        }
    }
}
