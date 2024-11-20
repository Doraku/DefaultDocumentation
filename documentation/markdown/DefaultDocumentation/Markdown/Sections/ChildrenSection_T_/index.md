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

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; ChildrenSection<T>

Derived  
&#8627; [ClassesSection](../ClassesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection')  
&#8627; [ConstructorOverloadsSection](../ConstructorOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorOverloadsSection')  
&#8627; [ConstructorsSection](../ConstructorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorsSection')  
&#8627; [DelegatesSection](../DelegatesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.DelegatesSection')  
&#8627; [EnumFieldsSection](../EnumFieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumFieldsSection')  
&#8627; [EnumsSection](../EnumsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EnumsSection')  
&#8627; [EventsSection](../EventsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.EventsSection')  
&#8627; [ExplicitInterfaceImplementationsSection](../ExplicitInterfaceImplementationsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection')  
&#8627; [FieldsSection](../FieldsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.FieldsSection')  
&#8627; [InterfacesSection](../InterfacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.InterfacesSection')  
&#8627; [MethodOverloadsSection](../MethodOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection')  
&#8627; [MethodsSection](../MethodsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection')  
&#8627; [NamespacesSection](../NamespacesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.NamespacesSection')  
&#8627; [OperatorsSection](../OperatorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection')  
&#8627; [ParametersSection](../ParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ParametersSection')  
&#8627; [PropertiesSection](../PropertiesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.PropertiesSection')  
&#8627; [StructsSection](../StructsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.StructsSection')  
&#8627; [TypeParametersSection](../TypeParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection')

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
