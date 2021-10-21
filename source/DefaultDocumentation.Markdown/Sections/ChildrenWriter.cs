using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Writers;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public abstract class ChildrenWriter<T> : ISectionWriter
        where T : DocItem
    {
        private readonly string _title;

        protected ChildrenWriter(string name, string title)
        {
            Name = name;
            _title = title;
        }

        protected virtual IEnumerable<T> GetChildren(DocumentationContext context, DocItem item) => context.GetChildren<T>(item);

        public string Name { get; }

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (DocItem item in GetChildren(writer.Context, writer.CurrentItem) ?? Array.Empty<T>())
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

                IWriter childWriter = new ChildWriter(writer, item);

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

    public sealed class TypeParametersWriter : ChildrenWriter<TypeParameterDocItem>
    {
        public TypeParametersWriter()
            : base("typeparameters", "#### Type parameters")
        { }

        protected override IEnumerable<TypeParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as ITypeParameterizedDocItem)?.TypeParameters;
    }

    public sealed class ParametersWriter : ChildrenWriter<ParameterDocItem>
    {
        public ParametersWriter()
            : base("parameters", "#### Parameters")
        { }

        protected override IEnumerable<ParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as IParameterizedDocItem)?.Parameters;
    }

    public sealed class EnumFieldsWriter : ChildrenWriter<EnumFieldDocItem>
    {
        public EnumFieldsWriter()
            : base("enumfields", "### Fields")
        { }
    }

    public sealed class ConstructorsWriter : ChildrenWriter<ConstructorDocItem>
    {
        public ConstructorsWriter()
            : base("constructors", "### Constructors")
        { }
    }

    public sealed class FieldsWriter : ChildrenWriter<FieldDocItem>
    {
        public FieldsWriter()
            : base("fields", "### Fields")
        { }
    }

    public sealed class PropertiesWriter : ChildrenWriter<PropertyDocItem>
    {
        public PropertiesWriter()
            : base("properties", "### Properties")
        { }
    }

    public sealed class MethodsWriter : ChildrenWriter<MethodDocItem>
    {
        public MethodsWriter()
            : base("methods", "### Methods")
        { }
    }

    public sealed class EventsWriter : ChildrenWriter<EventDocItem>
    {
        public EventsWriter()
            : base("events", "### Events")
        { }
    }

    public sealed class OperatorsWriter : ChildrenWriter<OperatorDocItem>
    {
        public OperatorsWriter()
            : base("operators", "### Operators")
        { }
    }

    public sealed class ExplicitInterfaceImplementationsWriter : ChildrenWriter<ExplicitInterfaceImplementationDocItem>
    {
        public ExplicitInterfaceImplementationsWriter()
            : base("explicitinterfaceimplementations", "### Explicit Interface Implementations")
        { }
    }

    public sealed class ClassesWriter : ChildrenWriter<ClassDocItem>
    {
        public ClassesWriter()
            : base("classes", "### Classes")
        { }
    }

    public sealed class StructsWriter : ChildrenWriter<StructDocItem>
    {
        public StructsWriter()
            : base("structs", "### Structs")
        { }
    }

    public sealed class InterfacesWriter : ChildrenWriter<InterfaceDocItem>
    {
        public InterfacesWriter()
            : base("interfaces", "### Interfaces")
        { }
    }

    public sealed class EnumsWriter : ChildrenWriter<EnumDocItem>
    {
        public EnumsWriter()
            : base("enums", "### Enums")
        { }
    }

    public sealed class DelegatesWriter : ChildrenWriter<DelegateDocItem>
    {
        public DelegatesWriter()
            : base("delegates", "### Delegates")
        { }
    }

    public sealed class NamespacesWriter : ChildrenWriter<NamespaceDocItem>
    {
        public NamespacesWriter()
            : base("namespaces", "### Namespaces")
        { }
    }
}
