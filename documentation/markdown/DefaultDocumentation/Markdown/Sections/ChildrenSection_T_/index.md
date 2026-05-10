#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## ChildrenSection\<T\> Class

Base [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write children of a given type of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public abstract class ChildrenSection<T> : DefaultDocumentation.Api.ISection
    where T : DefaultDocumentation.Models.DocItem
```
#### Type parameters

<a name='DefaultDocumentation.Markdown.Sections.ChildrenSection_T_.T'></a>

`T`

The of [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to write\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ChildrenSection\<T\>

Derived  
↳ [ClassesSection](../ClassesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection')  
↳ [ConstructorOverloadsSection](../ConstructorOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorOverloadsSection')  
↳ [ConstructorsSection](../ConstructorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorsSection')  
↳ [DelegatesSection](../DelegatesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DelegatesSection')  
↳ [EnumFieldsSection](../EnumFieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumFieldsSection')  
↳ [EnumsSection](../EnumsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumsSection')  
↳ [EventsSection](../EventsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EventsSection')  
↳ [ExplicitInterfaceImplementationsSection](../ExplicitInterfaceImplementationsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection')  
↳ [FieldsSection](../FieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.FieldsSection')  
↳ [InterfacesSection](../InterfacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.InterfacesSection')  
↳ [MethodOverloadsSection](../MethodOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection')  
↳ [MethodsSection](../MethodsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection')  
↳ [NamespacesSection](../NamespacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.NamespacesSection')  
↳ [OperatorsSection](../OperatorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection')  
↳ [ParametersSection](../ParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ParametersSection')  
↳ [PropertiesSection](../PropertiesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.PropertiesSection')  
↳ [StructsSection](../StructsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.StructsSection')  
↳ [TypeParametersSection](../TypeParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection')

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection')

| Constructors | |
| :--- | :--- |
| [ChildrenSection\(string, string\)](ChildrenSection(string,string).md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.ChildrenSection\(string, string\)') | Base constructor of the [ChildrenSection&lt;T&gt;](index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') type\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.Name') | Gets the name of the section, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetChildren\(IGeneralContext, DocItem\)](GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.GetChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to write\. |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
| [ShouldWriteTitle\(IGeneralContext, DocItem\)](ShouldWriteTitle(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.ShouldWriteTitle\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the title should be writen or not\. |
| [Write\(IWriter\)](Write(IWriter).md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>\.Write\(DefaultDocumentation\.Api\.IWriter\)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\. |
