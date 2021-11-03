using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TableOfContentsSection : ISectionWriter
    {
        [Flags]
        public enum Modes
        {
            None = 0,
            Grouped = 1 << 0,
            IncludeKind = 1 << 1,
            IncludeSummary = 1 << 2,
            IncludeNewLine = 1 << 3,
            IncludeSummaryWithNewLine = IncludeSummary | IncludeNewLine
        }

        private static void Write(IWriter writer, Modes modes, DocItem item)
        {
            WriteChildren(writer, modes, writer.Context.GetChildren<ConstructorDocItem>(item), "Constructors", "Constructor");
            WriteChildren(writer, modes, writer.Context.GetChildren<EnumFieldDocItem>(item), "Fields", "Field");
            WriteChildren(writer, modes, writer.Context.GetChildren<FieldDocItem>(item), "Fields", "Field");
            WriteChildren(writer, modes, writer.Context.GetChildren<PropertyDocItem>(item), "Properties", "Property");
            WriteChildren(writer, modes, writer.Context.GetChildren<MethodDocItem>(item), "Methods", "Method");
            WriteChildren(writer, modes, writer.Context.GetChildren<EventDocItem>(item), "Events", "Event");
            WriteChildren(writer, modes, writer.Context.GetChildren<OperatorDocItem>(item), "Operators", "Operator");
            WriteChildren(writer, modes, writer.Context.GetChildren<ExplicitInterfaceImplementationDocItem>(item), "Explicit Interface Implementations", "Explicit Interface Implementation");

            WriteChildren(writer, modes, writer.Context.GetChildren<ClassDocItem>(item), "Classes", "Class");
            WriteChildren(writer, modes, writer.Context.GetChildren<StructDocItem>(item), "Structs", "Struct");
            WriteChildren(writer, modes, writer.Context.GetChildren<InterfaceDocItem>(item), "Interfaces", "Interface");
            WriteChildren(writer, modes, writer.Context.GetChildren<EnumDocItem>(item), "Enums", "Enum");
            WriteChildren(writer, modes, writer.Context.GetChildren<DelegateDocItem>(item), "Delegates", "Delegate");

            WriteChildren(writer, modes, writer.Context.GetChildren<NamespaceDocItem>(item), "Namespaces", "Namespace");
        }

        private static void WriteChildren(IWriter writer, Modes modes, IEnumerable<DocItem> children, string group, string kind)
        {
            bool groupWritten = (modes & Modes.Grouped) == 0;
            foreach (DocItem child in children)
            {
                if (groupWritten is false)
                {
                    groupWritten = true;
                    writer = writer
                        .EnsureLineStart()
                        .Append("- *")
                        .Append(group)
                        .AppendLine("*")
                        .ToPrefixedWriter("  ");
                }

                writer
                    .EnsureLineStart()
                    .Append("- **")
                    .AppendLink(child, child is TypeDocItem ? child.LongName : null)
                    .Append("**");

                if ((modes & Modes.IncludeKind) != 0)
                {
                    writer
                        .Append(" `")
                        .Append(kind)
                        .Append("`");
                }

                if ((modes & Modes.IncludeSummary) != 0)
                {
                    if ((modes & Modes.IncludeNewLine) != 0)
                    {
                        writer.AppendLine();
                    }
                    else
                    {
                        writer.Append(" ");
                    }

                    writer
                        .ToPrefixedWriter("  ")
                        .AppendAsMarkdown(child switch
                        {
                            TypeParameterDocItem item => item.Documentation,
                            ParameterDocItem item => item.Documentation,
                            DocItem item => item.Documentation?.Element("summary")
                        });
                }

                Write(writer.ToPrefixedWriter("  "), modes, child);
            }
        }

        public string Name => "TableOfContents";

        public void Write(IWriter writer)
        {
            Modes modes = writer.GetFromContext(writer.GetCurrentItem(), c => c?.GetSetting<Modes>("Markdown.TableOfContentsModes")).GetValueOrDefault();

            Write(writer, modes, writer.GetCurrentItem());
        }
    }
}
