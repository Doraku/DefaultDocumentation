using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Markdown.Writers;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public abstract class ChildrenSection<T> : ISectionWriter
        where T : DocItem
    {
        private readonly string _title;

        protected ChildrenSection(string name, string title)
        {
            Name = name;
            _title = title;
        }

        protected virtual IEnumerable<T> GetChildren(DocumentationContext context, DocItem item) => context.GetChildren<T>(item);

        public string Name { get; }

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (DocItem item in GetChildren(writer.Context, writer.GetCurrentItem()) ?? Array.Empty<T>())
            {
                if (!titleWritten)
                {
                    writer.EnsureLineStart();

                    if (writer.Context.HasOwnPage(item))
                    {
                        writer
                            .AppendLine()
                            .Append("| ")
                            .Append(_title.Trim('#', ' '))
                            .AppendLine(" | |")
                            .AppendLine("| :--- | :--- |");
                    }
                    else
                    {
                        writer
                            .AppendLine(_title);
                    }

                    titleWritten = true;
                }

                IWriter childWriter = new WrapWriter(writer).SetCurrentItem(item);

                if (writer.Context.HasOwnPage(item))
                {
                    childWriter
                        .Append("| ")
                        .AppendLink(item, item is TypeDocItem ? string.Join(".", item.GetParents().OfType<TypeDocItem>().Concat(Enumerable.Repeat(item, 1)).Select(i => i.Name)) : null)
                        .Append(" | ")
                        .SetDisplayAsSingleLine(true)
                        .AppendAsMarkdown(item.Documentation.GetSummary())
                        .SetDisplayAsSingleLine(false)
                        .AppendLine(" |");
                }
                else
                {
                    foreach (ISectionWriter sectionWriter in writer.Context.SectionWriters)
                    {
                        sectionWriter.Write(childWriter);
                    }
                }
            }
        }
    }

    public sealed class TypeParametersSection : ChildrenSection<TypeParameterDocItem>
    {
        public TypeParametersSection()
            : base("typeparameters", "#### Type parameters")
        { }

        protected override IEnumerable<TypeParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as ITypeParameterizedDocItem)?.TypeParameters;
    }

    public sealed class ParametersSection : ChildrenSection<ParameterDocItem>
    {
        public ParametersSection()
            : base("parameters", "#### Parameters")
        { }

        protected override IEnumerable<ParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as IParameterizedDocItem)?.Parameters;
    }

    public sealed class EnumFieldsSection : ChildrenSection<EnumFieldDocItem>
    {
        public EnumFieldsSection()
            : base("enumfields", "### Fields")
        { }
    }

    public sealed class ConstructorsSection : ChildrenSection<ConstructorDocItem>
    {
        public ConstructorsSection()
            : base("constructors", "### Constructors")
        { }
    }

    public sealed class FieldsSection : ChildrenSection<FieldDocItem>
    {
        public FieldsSection()
            : base("fields", "### Fields")
        { }
    }

    public sealed class PropertiesSection : ChildrenSection<PropertyDocItem>
    {
        public PropertiesSection()
            : base("properties", "### Properties")
        { }
    }

    public sealed class MethodsSection : ChildrenSection<MethodDocItem>
    {
        public MethodsSection()
            : base("methods", "### Methods")
        { }
    }

    public sealed class EventsSection : ChildrenSection<EventDocItem>
    {
        public EventsSection()
            : base("events", "### Events")
        { }
    }

    public sealed class OperatorsSection : ChildrenSection<OperatorDocItem>
    {
        public OperatorsSection()
            : base("operators", "### Operators")
        { }
    }

    public sealed class ExplicitInterfaceImplementationsSection : ChildrenSection<ExplicitInterfaceImplementationDocItem>
    {
        public ExplicitInterfaceImplementationsSection()
            : base("explicitinterfaceimplementations", "### Explicit Interface Implementations")
        { }
    }

    public sealed class ClassesSection : ChildrenSection<ClassDocItem>
    {
        public ClassesSection()
            : base("classes", "### Classes")
        { }
    }

    public sealed class StructsSection : ChildrenSection<StructDocItem>
    {
        public StructsSection()
            : base("structs", "### Structs")
        { }
    }

    public sealed class InterfacesSection : ChildrenSection<InterfaceDocItem>
    {
        public InterfacesSection()
            : base("interfaces", "### Interfaces")
        { }
    }

    public sealed class EnumsSection : ChildrenSection<EnumDocItem>
    {
        public EnumsSection()
            : base("enums", "### Enums")
        { }
    }

    public sealed class DelegatesSection : ChildrenSection<DelegateDocItem>
    {
        public DelegatesSection()
            : base("delegates", "### Delegates")
        { }
    }

    public sealed class NamespacesSection : ChildrenSection<NamespaceDocItem>
    {
        public NamespacesSection()
            : base("namespaces", "### Namespaces")
        { }
    }
}
