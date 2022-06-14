#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## DefaultSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation regrouping the following implementation in this order:  
              
1. [TitleSection](TitleSection.md 'DefaultDocumentation.Markdown.Sections.TitleSection')  
2. [SummarySection](SummarySection.md 'DefaultDocumentation.Markdown.Sections.SummarySection')  
3. [DefinitionSection](DefinitionSection.md 'DefaultDocumentation.Markdown.Sections.DefinitionSection')  
4. [TypeParametersSection](TypeParametersSection.md 'DefaultDocumentation.Markdown.Sections.TypeParametersSection')  
5. [ParametersSection](ParametersSection.md 'DefaultDocumentation.Markdown.Sections.ParametersSection')  
6. [EnumFieldsSection](EnumFieldsSection.md 'DefaultDocumentation.Markdown.Sections.EnumFieldsSection')  
7. [InheritanceSection](InheritanceSection.md 'DefaultDocumentation.Markdown.Sections.InheritanceSection')  
8. [DerivedSection](DerivedSection.md 'DefaultDocumentation.Markdown.Sections.DerivedSection')  
9. [ImplementSection](ImplementSection.md 'DefaultDocumentation.Markdown.Sections.ImplementSection')  
10. [EventTypeSection](EventTypeSection.md 'DefaultDocumentation.Markdown.Sections.EventTypeSection')  
11. [FieldValueSection](FieldValueSection.md 'DefaultDocumentation.Markdown.Sections.FieldValueSection')  
12. [ValueSection](ValueSection.md 'DefaultDocumentation.Markdown.Sections.ValueSection')  
13. [ReturnsSection](ReturnsSection.md 'DefaultDocumentation.Markdown.Sections.ReturnsSection')  
14. [ExceptionSection](ExceptionSection.md 'DefaultDocumentation.Markdown.Sections.ExceptionSection')  
15. [ExampleSection](ExampleSection.md 'DefaultDocumentation.Markdown.Sections.ExampleSection')  
16. [RemarksSection](RemarksSection.md 'DefaultDocumentation.Markdown.Sections.RemarksSection')  
17. [SeeAlsoSection](SeeAlsoSection.md 'DefaultDocumentation.Markdown.Sections.SeeAlsoSection')  
18. [NamespacesSection](NamespacesSection.md 'DefaultDocumentation.Markdown.Sections.NamespacesSection')  
19. [ClassesSection](ClassesSection.md 'DefaultDocumentation.Markdown.Sections.ClassesSection')  
20. [StructsSection](StructsSection.md 'DefaultDocumentation.Markdown.Sections.StructsSection')  
21. [InterfacesSection](InterfacesSection.md 'DefaultDocumentation.Markdown.Sections.InterfacesSection')  
22. [EnumsSection](EnumsSection.md 'DefaultDocumentation.Markdown.Sections.EnumsSection')  
23. [DelegatesSection](DelegatesSection.md 'DefaultDocumentation.Markdown.Sections.DelegatesSection')  
24. [ConstructorsSection](ConstructorsSection.md 'DefaultDocumentation.Markdown.Sections.ConstructorsSection')  
25. [FieldsSection](FieldsSection.md 'DefaultDocumentation.Markdown.Sections.FieldsSection')  
26. [PropertiesSection](PropertiesSection.md 'DefaultDocumentation.Markdown.Sections.PropertiesSection')  
27. [MethodsSection](MethodsSection.md 'DefaultDocumentation.Markdown.Sections.MethodsSection')  
28. [EventsSection](EventsSection.md 'DefaultDocumentation.Markdown.Sections.EventsSection')  
29. [OperatorsSection](OperatorsSection.md 'DefaultDocumentation.Markdown.Sections.OperatorsSection')  
30. [ExplicitInterfaceImplementationsSection](ExplicitInterfaceImplementationsSection.md 'DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSection')

```csharp
public sealed class DefaultSection :
DefaultDocumentation.Api.ISection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DefaultSection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection')

| Constructors | |
| :--- | :--- |
| [DefaultSection()](DefaultSection.DefaultSection().md 'DefaultDocumentation.Markdown.Sections.DefaultSection.DefaultSection()') | Initialize a new instance of the [DefaultSection](DefaultSection.md 'DefaultDocumentation.Markdown.Sections.DefaultSection') type. |

| Fields | |
| :--- | :--- |
| [ConfigName](DefaultSection.ConfigName.md 'DefaultDocumentation.Markdown.Sections.DefaultSection.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](DefaultSection.Name.md 'DefaultDocumentation.Markdown.Sections.DefaultSection.Name') | Gets the name of the section, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Write(IWriter)](DefaultSection.Write(IWriter).md 'DefaultDocumentation.Markdown.Sections.DefaultSection.Write(DefaultDocumentation.Api.IWriter)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter'). |
