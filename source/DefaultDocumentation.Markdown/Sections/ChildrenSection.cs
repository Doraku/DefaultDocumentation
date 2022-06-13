using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Sections
{
    public abstract class ChildrenSection<T> : ISection
        where T : DocItem
    {
        private readonly string _title;

        protected ChildrenSection(string name, string title)
        {
            Name = name;
            _title = title;
        }

        protected virtual IEnumerable<T>? GetChildren(IGeneralContext context, DocItem item) => context.GetChildren<T>(item);

        public string Name { get; }

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (DocItem item in GetChildren(writer.Context, writer.GetCurrentItem()) ?? Array.Empty<T>())
            {
                if (!titleWritten)
                {
                    writer.EnsureLineStart();

                    if (item.HasOwnPage(writer.Context))
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

                IWriter childWriter = writer
                    .ToOverrideWriter()
                    .SetCurrentItem(item);

                if (item.HasOwnPage(writer.Context))
                {
                    childWriter
                        .Append("| ")
                        .AppendLink(item, item is TypeDocItem ? string.Join(".", item.GetParents().OfType<TypeDocItem>().Concat(Enumerable.Repeat(item, 1)).Select(i => i.Name)) : null)
                        .Append(" | ")
                        .SetDisplayAsSingleLine(true)
                        .AppendAsMarkdown(item.Documentation?.GetSummary())
                        .SetDisplayAsSingleLine(false)
                        .AppendLine(" |");
                }
                else
                {
                    foreach (ISection sectionWriter in writer.Context.GetSetting(item, c => c.Sections)!)
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
            : base("TypeParameters", "#### Type parameters")
        { }

        protected override IEnumerable<TypeParameterDocItem>? GetChildren(IGeneralContext context, DocItem item) => (item as ITypeParameterizedDocItem)?.TypeParameters;
    }

    public sealed class ParametersSection : ChildrenSection<ParameterDocItem>
    {
        public ParametersSection()
            : base("Parameters", "#### Parameters")
        { }

        protected override IEnumerable<ParameterDocItem>? GetChildren(IGeneralContext context, DocItem item) => (item as IParameterizedDocItem)?.Parameters;
    }

    public sealed class EnumFieldsSection : ChildrenSection<EnumFieldDocItem>
    {
        public EnumFieldsSection()
            : base("EnumFields", "### Fields")
        { }
    }

    public sealed class ConstructorsSection : ChildrenSection<ConstructorDocItem>
    {
        public ConstructorsSection()
            : base("Constructors", "### Constructors")
        { }
    }

    public sealed class FieldsSection : ChildrenSection<FieldDocItem>
    {
        public FieldsSection()
            : base("Fields", "### Fields")
        { }
    }

    public sealed class PropertiesSection : ChildrenSection<PropertyDocItem>
    {
        public PropertiesSection()
            : base("Properties", "### Properties")
        { }
    }

    public sealed class MethodsSection : ChildrenSection<MethodDocItem>
    {
        public MethodsSection()
            : base("Methods", "### Methods")
        { }
    }

    public sealed class EventsSection : ChildrenSection<EventDocItem>
    {
        public EventsSection()
            : base("Events", "### Events")
        { }
    }

    public sealed class OperatorsSection : ChildrenSection<OperatorDocItem>
    {
        public OperatorsSection()
            : base("Operators", "### Operators")
        { }
    }

    public sealed class ExplicitInterfaceImplementationsSection : ChildrenSection<ExplicitInterfaceImplementationDocItem>
    {
        public ExplicitInterfaceImplementationsSection()
            : base("Explicitinterfaceimplementations", "### Explicit Interface Implementations")
        { }
    }

    public sealed class ClassesSection : ChildrenSection<ClassDocItem>
    {
        public ClassesSection()
            : base("Classes", "### Classes")
        { }
    }

    public sealed class StructsSection : ChildrenSection<StructDocItem>
    {
        public StructsSection()
            : base("Structs", "### Structs")
        { }
    }

    public sealed class InterfacesSection : ChildrenSection<InterfaceDocItem>
    {
        public InterfacesSection()
            : base("Interfaces", "### Interfaces")
        { }
    }

    public sealed class EnumsSection : ChildrenSection<EnumDocItem>
    {
        public EnumsSection()
            : base("Enums", "### Enums")
        { }
    }

    public sealed class DelegatesSection : ChildrenSection<DelegateDocItem>
    {
        public DelegatesSection()
            : base("Delegates", "### Delegates")
        { }
    }

    public sealed class NamespacesSection : ChildrenSection<NamespaceDocItem>
    {
        public NamespacesSection()
            : base("Namespaces", "### Namespaces")
        { }
    }
}
