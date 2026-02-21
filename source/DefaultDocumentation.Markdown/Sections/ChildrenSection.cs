using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Models;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// Base <see cref="ISection"/> implementation to write children of a given type of a <see cref="DocItem"/>.
/// </summary>
/// <typeparam name="T">The of <see cref="DocItem"/> to write.</typeparam>
public abstract class ChildrenSection<T> : ISection
    where T : DocItem
{
    private readonly string _title;

    /// <summary>
    /// Base constructor of the <see cref="ChildrenSection{T}"/> type.
    /// </summary>
    /// <param name="name">The name of the section.</param>
    /// <param name="title">The title that will be written before the children.</param>
    protected ChildrenSection(string name, string title)
    {
        Name = name;
        _title = title;
    }

    /// <summary>
    /// Gets if the children should be inlined or not.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to write its children.</param>
    protected abstract bool ShouldInlineChildren(IGeneralContext context, DocItem item);

    /// <summary>
    /// Gets if the title should be writen or not.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to write its children.</param>
    protected virtual bool ShouldWriteTitle(IGeneralContext context, DocItem item) => true;

    /// <summary>
    /// Gets the children of a <see cref="DocItem"/> to write.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to write its children.</param>
    /// <returns>The children to write.</returns>
    protected virtual IEnumerable<T>? GetChildren(IGeneralContext context, DocItem item) => context.GetChildren<T>(item);

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        bool inlineChildren = ShouldInlineChildren(writer.Context, writer.GetCurrentItem());
        bool titleWritten = !(ShouldWriteTitle(writer.Context, writer.GetCurrentItem()) || !inlineChildren);

        foreach (DocItem child in GetChildren(writer.Context, writer.GetCurrentItem()) ?? [])
        {
            if (!titleWritten)
            {
                writer.EnsureLineStart();

                if (inlineChildren)
                {
                    writer
                        .AppendLine(_title);
                }
                else
                {
                    writer
                        .AppendLine()
                        .Append("| ")
                        .Append(_title.Trim('#', ' '))
                        .AppendLine(" | |")
                        .AppendLine("| :--- | :--- |");
                }

                titleWritten = true;
            }

            IWriter childWriter = writer
                .ToOverrideWriter()
                .SetCurrentItem(child);

            if (inlineChildren)
            {
                foreach (ISection sectionWriter in writer.Context.GetSetting(child, context => context.Sections)!)
                {
                    sectionWriter.Write(childWriter);
                }
            }
            else
            {
                childWriter
                    .Append("| ")
                    .AppendLink(child, child is TypeDocItem ? string.Join(".", child.GetParents().OfType<TypeDocItem>().Concat(Enumerable.Repeat(child, 1)).Select(parent => parent.Name)) : null)
                    .Append(" | ")
                    .SetDisplayAsSingleLine(true)
                    .AppendAsMarkdown(child.Documentation?.GetSummary())
                    .SetDisplayAsSingleLine(false)
                    .AppendLine(" |");
            }
        }
    }
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="TypeParameterDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class TypeParametersSection : ChildrenSection<TypeParameterDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "TypeParameters";

    /// <summary>
    /// Initialize a new instance of the <see cref="TypeParametersSection"/> type.
    /// </summary>
    public TypeParametersSection()
        : base(ConfigName, "#### Type parameters")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item) => true;

    /// <inheritdoc/>
    protected override IEnumerable<TypeParameterDocItem>? GetChildren(IGeneralContext context, DocItem item) => (item as ITypeParameterizedDocItem)?.TypeParameters;
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="ParameterDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class ParametersSection : ChildrenSection<ParameterDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Parameters";

    /// <summary>
    /// Initialize a new instance of the <see cref="ParametersSection"/> type.
    /// </summary>
    public ParametersSection()
        : base(ConfigName, "#### Parameters")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item) => true;

    /// <inheritdoc/>
    protected override IEnumerable<ParameterDocItem>? GetChildren(IGeneralContext context, DocItem item) => (item as IParameterizedDocItem)?.Parameters;
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="EnumFieldDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class EnumFieldsSection : ChildrenSection<EnumFieldDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "EnumFields";

    /// <summary>
    /// Initialize a new instance of the <see cref="EnumFieldsSection"/> type.
    /// </summary>
    public EnumFieldsSection()
        : base(ConfigName, "### Fields")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item) => true;

    /// <inheritdoc/>
    protected override IEnumerable<EnumFieldDocItem>? GetChildren(IGeneralContext context, DocItem item)
        => item is EnumDocItem enumType
        ? base.GetChildren(context, item).OrderBy(child => enumType.Type.Fields.TakeWhile(field => field != child.Field).Count())
        : [];
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="ConstructorDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class ConstructorsSection : ChildrenSection<ConstructorDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Constructors";

    /// <summary>
    /// Initialize a new instance of the <see cref="ConstructorsSection"/> type.
    /// </summary>
    public ConstructorsSection()
        : base(ConfigName, "### Constructors")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => item is ConstructorOverloadsDocItem || !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Constructors);

    /// <inheritdoc/>
    protected override bool ShouldWriteTitle(IGeneralContext context, DocItem item) => item is not ConstructorOverloadsDocItem;

    /// <inheritdoc/>
    protected override IEnumerable<ConstructorDocItem>? GetChildren(IGeneralContext context, DocItem item) =>
        item is ConstructorOverloadsDocItem overloadsItem
        ? context.GetChildren<ConstructorDocItem>(overloadsItem.Parent!)
        : base.GetChildren(context, item);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="ConstructorOverloadsSection"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class ConstructorOverloadsSection : ChildrenSection<ConstructorDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "ConstructorOverloads";

    /// <summary>
    /// Initialize a new instance of the <see cref="ConstructorsSection"/> type.
    /// </summary>
    public ConstructorOverloadsSection()
        : base(ConfigName, "Overloads")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item) => false;

    /// <inheritdoc/>
    protected override IEnumerable<ConstructorDocItem>? GetChildren(IGeneralContext context, DocItem item) =>
        item is ConstructorOverloadsDocItem overloadsItem
        ? context.GetChildren<ConstructorDocItem>(overloadsItem.Parent!)
        : [];
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="FieldDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class FieldsSection : ChildrenSection<FieldDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Fields";

    /// <summary>
    /// Initialize a new instance of the <see cref="FieldsSection"/> type.
    /// </summary>
    public FieldsSection()
        : base(ConfigName, "### Fields")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Fields);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="PropertyDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class PropertiesSection : ChildrenSection<PropertyDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Properties";

    /// <summary>
    /// Initialize a new instance of the <see cref="PropertiesSection"/> type.
    /// </summary>
    public PropertiesSection()
        : base(ConfigName, "### Properties")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Properties);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="MethodDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class MethodsSection : ChildrenSection<MethodDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Methods";

    /// <summary>
    /// Initialize a new instance of the <see cref="MethodsSection"/> type.
    /// </summary>
    public MethodsSection()
        : base(ConfigName, "### Methods")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => item is MethodOverloadsDocItem || !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Methods);

    /// <inheritdoc/>
    protected override bool ShouldWriteTitle(IGeneralContext context, DocItem item) => item is not MethodOverloadsDocItem;

    /// <inheritdoc/>
    protected override IEnumerable<MethodDocItem>? GetChildren(IGeneralContext context, DocItem item) =>
        item is MethodOverloadsDocItem overloadsItem
        ? context.GetChildren<MethodDocItem>(overloadsItem.Parent!).Where(item => item.Method.Name == overloadsItem.Name)
        : base.GetChildren(context, item);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="MethodOverloadsSection"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class MethodOverloadsSection : ChildrenSection<MethodDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "MethodOverloads";

    /// <summary>
    /// Initialize a new instance of the <see cref="ConstructorsSection"/> type.
    /// </summary>
    public MethodOverloadsSection()
        : base(ConfigName, "Overloads")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item) => false;

    /// <inheritdoc/>
    protected override IEnumerable<MethodDocItem>? GetChildren(IGeneralContext context, DocItem item) =>
        item is MethodOverloadsDocItem overloadsItem
        ? context.GetChildren<MethodDocItem>(overloadsItem.Parent!).Where(item => item.Method.Name == overloadsItem.Name)
        : [];
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="EventDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class EventsSection : ChildrenSection<EventDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Events";

    /// <summary>
    /// Initialize a new instance of the <see cref="EventsSection"/> type.
    /// </summary>
    public EventsSection()
        : base(ConfigName, "### Events")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Events);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="OperatorDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class OperatorsSection : ChildrenSection<OperatorDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Operators";

    /// <summary>
    /// Initialize a new instance of the <see cref="OperatorsSection"/> type.
    /// </summary>
    public OperatorsSection()
        : base(ConfigName, "### Operators")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Operators);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="ExplicitInterfaceImplementationDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class ExplicitInterfaceImplementationsSection : ChildrenSection<ExplicitInterfaceImplementationDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "ExplicitInterfaceImplementations";

    /// <summary>
    /// Initialize a new instance of the <see cref="ExplicitInterfaceImplementationsSection"/> type.
    /// </summary>
    public ExplicitInterfaceImplementationsSection()
        : base(ConfigName, "### Explicit Interface Implementations")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.ExplicitInterfaceImplementations);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="ClassDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class ClassesSection : ChildrenSection<ClassDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Classes";

    /// <summary>
    /// Initialize a new instance of the <see cref="ClassesSection"/> type.
    /// </summary>
    public ClassesSection()
        : base(ConfigName, "### Classes")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Classes);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="StructDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class StructsSection : ChildrenSection<StructDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Structs";

    /// <summary>
    /// Initialize a new instance of the <see cref="StructsSection"/> type.
    /// </summary>
    public StructsSection()
        : base(ConfigName, "### Structs")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Structs);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="InterfaceDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class InterfacesSection : ChildrenSection<InterfaceDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Interfaces";

    /// <summary>
    /// Initialize a new instance of the <see cref="InterfacesSection"/> type.
    /// </summary>
    public InterfacesSection()
        : base(ConfigName, "### Interfaces")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Interfaces);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="EnumDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class EnumsSection : ChildrenSection<EnumDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Enums";

    /// <summary>
    /// Initialize a new instance of the <see cref="EnumsSection"/> type.
    /// </summary>
    public EnumsSection()
        : base(ConfigName, "### Enums")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Enums);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="DelegateDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class DelegatesSection : ChildrenSection<DelegateDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Delegates";

    /// <summary>
    /// Initialize a new instance of the <see cref="DelegatesSection"/> type.
    /// </summary>
    public DelegatesSection()
        : base(ConfigName, "### Delegates")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Delegates);
}

/// <summary>
/// <see cref="ISection"/> implementation to write <see cref="NamespaceDocItem"/> children of a <see cref="DocItem"/>.
/// </summary>
public sealed class NamespacesSection : ChildrenSection<NamespaceDocItem>
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Namespaces";

    /// <summary>
    /// Initialize a new instance of the <see cref="NamespacesSection"/> type.
    /// </summary>
    public NamespacesSection()
        : base(ConfigName, "### Namespaces")
    { }

    /// <inheritdoc/>
    protected override bool ShouldInlineChildren(IGeneralContext context, DocItem item)
        => !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Namespaces);
}
