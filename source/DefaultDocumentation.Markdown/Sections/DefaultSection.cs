using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation regrouping the following implementation in this order:
/// <list type="number">
///     <item><see cref="TitleSection"/></item>
///     <item><see cref="SummarySection"/></item>
///     <item><see cref="DefinitionSection"/></item>
///     <item><see cref="ConstructorOverloadsSection"/></item>
///     <item><see cref="MethodOverloadsSection"/></item>
///     <item><see cref="TypeParametersSection"/></item>
///     <item><see cref="ParametersSection"/></item>
///     <item><see cref="EnumFieldsSection"/></item>
///     <item><see cref="InheritanceSection"/></item>
///     <item><see cref="DerivedSection"/></item>
///     <item><see cref="ImplementSection"/></item>
///     <item><see cref="EventTypeSection"/></item>
///     <item><see cref="FieldValueSection"/></item>
///     <item><see cref="ValueSection"/></item>
///     <item><see cref="ReturnsSection"/></item>
///     <item><see cref="ExceptionSection"/></item>
///     <item><see cref="ExampleSection"/></item>
///     <item><see cref="RemarksSection"/></item>
///     <item><see cref="SeeAlsoSection"/></item>
///     <item><see cref="NamespacesSection"/></item>
///     <item><see cref="ClassesSection"/></item>
///     <item><see cref="StructsSection"/></item>
///     <item><see cref="InterfacesSection"/></item>
///     <item><see cref="EnumsSection"/></item>
///     <item><see cref="DelegatesSection"/></item>
///     <item><see cref="ConstructorsSection"/></item>
///     <item><see cref="FieldsSection"/></item>
///     <item><see cref="PropertiesSection"/></item>
///     <item><see cref="MethodsSection"/></item>
///     <item><see cref="EventsSection"/></item>
///     <item><see cref="OperatorsSection"/></item>
///     <item><see cref="ExplicitInterfaceImplementationsSection"/></item>
/// </list>
/// </summary>
public sealed class DefaultSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Default";

    private readonly ISection[] _sections;

    /// <summary>
    /// Initialize a new instance of the <see cref="DefaultSection"/> type.
    /// </summary>
    public DefaultSection()
    {
        _sections =
        [
            new TitleSection(),
            new SummarySection(),
            new DefinitionSection(),

            new ConstructorOverloadsSection(),
            new MethodOverloadsSection(),

            new TypeParametersSection(),
            new ParametersSection(),
            new EnumFieldsSection(),

            new InheritanceSection(),
            new DerivedSection(),
            new ImplementSection(),

            new EventTypeSection(),
            new FieldValueSection(),
            new ValueSection(),
            new ReturnsSection(),
            new ExceptionSection(),
            new ExampleSection(),
            new RemarksSection(),
            new SeeAlsoSection(),

            new NamespacesSection(),

            new ClassesSection(),
            new StructsSection(),
            new InterfacesSection(),
            new EnumsSection(),
            new DelegatesSection(),

            new ConstructorsSection(),
            new FieldsSection(),
            new PropertiesSection(),
            new MethodsSection(),
            new EventsSection(),
            new OperatorsSection(),
            new ExplicitInterfaceImplementationsSection()
        ];
    }

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        foreach (ISection section in _sections)
        {
            section.Write(writer);
        }
    }
}
