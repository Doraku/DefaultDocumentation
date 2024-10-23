#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## DefaultSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation regrouping the following implementation in this order:
            
1. [TitleSection](../TitleSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.TitleSection')
2. [SummarySection](../SummarySection/index.md 'DefaultDocumentation\.Markdown\.Sections\.SummarySection')
3. [DefinitionSection](../DefinitionSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DefinitionSection')
4. [ConstructorOverloadsSection](../ConstructorOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorOverloadsSection')
5. [MethodOverloadsSection](../MethodOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection')
6. [TypeParametersSection](../TypeParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection')
7. [ParametersSection](../ParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ParametersSection')
8. [EnumFieldsSection](../EnumFieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumFieldsSection')
9. [InheritanceSection](../InheritanceSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.InheritanceSection')
10. [DerivedSection](../DerivedSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DerivedSection')
11. [ImplementSection](../ImplementSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ImplementSection')
12. [EventTypeSection](../EventTypeSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EventTypeSection')
13. [FieldValueSection](../FieldValueSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.FieldValueSection')
14. [ValueSection](../ValueSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ValueSection')
15. [ReturnsSection](../ReturnsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ReturnsSection')
16. [ExceptionSection](../ExceptionSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExceptionSection')
17. [ExampleSection](../ExampleSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExampleSection')
18. [RemarksSection](../RemarksSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.RemarksSection')
19. [SeeAlsoSection](../SeeAlsoSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.SeeAlsoSection')
20. [NamespacesSection](../NamespacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.NamespacesSection')
21. [ClassesSection](../ClassesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection')
22. [StructsSection](../StructsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.StructsSection')
23. [InterfacesSection](../InterfacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.InterfacesSection')
24. [EnumsSection](../EnumsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumsSection')
25. [DelegatesSection](../DelegatesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DelegatesSection')
26. [ConstructorsSection](../ConstructorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorsSection')
27. [FieldsSection](../FieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.FieldsSection')
28. [PropertiesSection](../PropertiesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.PropertiesSection')
29. [MethodsSection](../MethodsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection')
30. [EventsSection](../EventsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EventsSection')
31. [OperatorsSection](../OperatorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection')
32. [ExplicitInterfaceImplementationsSection](../ExplicitInterfaceImplementationsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection')

```csharp
public sealed class DefaultSection : DefaultDocumentation.Api.ISection
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; DefaultSection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection')

| Constructors | |
| :--- | :--- |
| [DefaultSection\(\)](DefaultSection().md 'DefaultDocumentation\.Markdown\.Sections\.DefaultSection\.DefaultSection\(\)') | Initialize a new instance of the [DefaultSection](DefaultDocumentation/Markdown/Sections/DefaultSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DefaultSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.DefaultSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.Sections\.DefaultSection\.Name') | Gets the name of the section, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [Write\(IWriter\)](Write(IWriter).md 'DefaultDocumentation\.Markdown\.Sections\.DefaultSection\.Write\(DefaultDocumentation\.Api\.IWriter\)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\. |
