using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefaultSection : ISectionWriter
    {
        private readonly ISectionWriter[] _sections;

        public DefaultSection()
        {
            _sections = new ISectionWriter[]
            {
                new TitleSection(),
                new SummarySection(),
                new DefinitionSection(),

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
            };
        }

        public string Name => "Default";

        public void Write(IWriter writer)
        {
            foreach (ISectionWriter section in _sections)
            {
                section.Write(writer);
            }
        }
    }
}
