using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write a table of content of all children of the <see cref="DocItem"/>.
    /// </summary>
    public sealed class TableOfContentsSection : ISection
    {
        /// <summary>
        /// The different options to customize the table of contents.
        /// </summary>
        [Flags]
        public enum Modes
        {
            /// <summary>
            /// Default generation.
            /// </summary>
            None = 0,
            /// <summary>
            /// <see cref="DocItem"/> will appear in their kind section.
            /// </summary>
            Grouped = 1 << 0,
            /// <summary>
            /// The kind of each <see cref="DocItem"/> will appear explicitely.
            /// </summary>
            IncludeKind = 1 << 1,
            /// <summary>
            /// The summary of each <see cref="DocItem"/> will be displayed.
            /// </summary>
            IncludeSummary = 1 << 2,
            /// <summary>
            /// There should be a new line when displaying the summary of the <see cref="DocItem"/>.
            /// </summary>
            IncludeNewLine = 1 << 3,
            /// <summary>
            /// Same as <see cref="IncludeSummary"/> and <see cref="IncludeNewLine"/>
            /// </summary>
            IncludeSummaryWithNewLine = IncludeSummary | IncludeNewLine
        }

        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "TableOfContents";

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
                if (!groupWritten)
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
                    .AppendLink(child, child is TypeDocItem ? child.GetLongName() : null)
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

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer)
        {
            ArgumentNullException.ThrowIfNull(writer);

            Modes modes = writer.Context.GetSetting(writer.GetCurrentItem(), c => c.GetSetting<Modes?>("Markdown.TableOfContentsModes")).GetValueOrDefault();

            Write(writer, modes, writer.GetCurrentItem());
        }
    }
}
