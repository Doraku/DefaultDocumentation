using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;

namespace DefaultDocumentation.Writer.Section
{
    internal abstract class ChildrenWriter<T> : SectionWriter
        where T : DocItem
    {
        private readonly string _title;

        protected ChildrenWriter(string name, string title)
            : base(name)
        {
            _title = title;
        }

        protected virtual IEnumerable<T> GetChildren(DocumentationContext context, DocItem item) => context.GetChildren<T>(item);

        public override void Write(PageWriter writer)
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

                if (writer.Context.HasOwnPage(item))
                {
                    PageWriter childWriter = writer.With(item);

                    childWriter
                        .Append("| ")
                        .AppendLink(item, item is TypeDocItem ? string.Join(".", item.GetParents().OfType<TypeDocItem>().Concat(Enumerable.Repeat(item, 1)).Select(i => i.Name)) : null)
                        .Append(" | ");

                    using (RollbackSetter<bool> _ = new(() => ref childWriter.DisplayAsSingleLine, true))
                    {
                        childWriter.Append(item.Documentation.GetSummary());
                    }

                    childWriter.AppendLine(" |");
                }
                else
                {
                    foreach (SectionWriter sectionWriter in writer.Context.SectionWriters)
                    {
                        PageWriter childWriter = writer.With(item);

                        sectionWriter.Write(childWriter);
                        childWriter.EnsureLineStart();
                    }
                }
            }
        }
    }

    internal sealed class TypeParametersWriter : ChildrenWriter<TypeParameterDocItem>
    {
        public TypeParametersWriter()
            : base("typeparameters", "#### Type parameters")
        { }

        protected override IEnumerable<TypeParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as ITypeParameterizedDocItem)?.TypeParameters;
    }

    internal sealed class ParametersWriter : ChildrenWriter<ParameterDocItem>
    {
        public ParametersWriter()
            : base("parameters", "#### Parameters")
        { }

        protected override IEnumerable<ParameterDocItem> GetChildren(DocumentationContext context, DocItem item) => (item as IParameterizedDocItem)?.Parameters;
    }

    internal sealed class EnumFieldsWriter : ChildrenWriter<EnumFieldDocItem>
    {
        public EnumFieldsWriter()
            : base("enumfields", "### Fields")
        { }
    }

    internal sealed class ConstructorsWriter : ChildrenWriter<ConstructorDocItem>
    {
        public ConstructorsWriter()
            : base("constructors", "### Constructors")
        { }
    }

    internal sealed class FieldsWriter : ChildrenWriter<FieldDocItem>
    {
        public FieldsWriter()
            : base("fields", "### Fields")
        { }
    }

    internal sealed class PropertiesWriter : ChildrenWriter<PropertyDocItem>
    {
        public PropertiesWriter()
            : base("properties", "### Properties")
        { }
    }

    internal sealed class MethodsWriter : ChildrenWriter<MethodDocItem>
    {
        public MethodsWriter()
            : base("methods", "### Methods")
        { }
    }

    internal sealed class EventsWriter : ChildrenWriter<EventDocItem>
    {
        public EventsWriter()
            : base("events", "### Events")
        { }
    }

    internal sealed class OperatorsWriter : ChildrenWriter<OperatorDocItem>
    {
        public OperatorsWriter()
            : base("operators", "### Operators")
        { }
    }

    internal sealed class ExplicitInterfaceImplementationsWriter : ChildrenWriter<ExplicitInterfaceImplementationDocItem>
    {
        public ExplicitInterfaceImplementationsWriter()
            : base("explicitinterfaceimplementations", "### Explicit Interface Implementations")
        { }
    }

    internal sealed class ClassesWriter : ChildrenWriter<ClassDocItem>
    {
        public ClassesWriter()
            : base("classes", "### Classes")
        { }
    }

    internal sealed class StructsWriter : ChildrenWriter<StructDocItem>
    {
        public StructsWriter()
            : base("structs", "### Structs")
        { }
    }

    internal sealed class InterfacesWriter : ChildrenWriter<InterfaceDocItem>
    {
        public InterfacesWriter()
            : base("interfaces", "### Interfaces")
        { }
    }

    internal sealed class EnumsWriter : ChildrenWriter<EnumDocItem>
    {
        public EnumsWriter()
            : base("enums", "### Enums")
        { }
    }

    internal sealed class DelegatesWriter : ChildrenWriter<DelegateDocItem>
    {
        public DelegatesWriter()
            : base("delegates", "### Delegates")
        { }
    }

    internal sealed class NamespacesWriter : ChildrenWriter<NamespaceDocItem>
    {
        public NamespacesWriter()
            : base("namespaces", "### Namespaces")
        { }
    }
}
