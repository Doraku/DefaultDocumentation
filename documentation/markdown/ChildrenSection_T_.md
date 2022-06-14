#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## ChildrenSection<T> Class

Base [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation to write children of a given type of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public abstract class ChildrenSection<T> :
DefaultDocumentation.Api.ISection
    where T : DefaultDocumentation.Models.DocItem
```
#### Type parameters

<a name='DefaultDocumentation.Markdown.Sections.ChildrenSection_T_.T'></a>

`T`

The of [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') to write.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ChildrenSection<T>

Derived  
&#8627; [ClassesSection](ClassesSection.md 'DefaultDocumentation.Markdown.Sections.ClassesSection')  
&#8627; [ConstructorsSection](ConstructorsSection.md 'DefaultDocumentation.Markdown.Sections.ConstructorsSection')  
&#8627; [DelegatesSection](DelegatesSection.md 'DefaultDocumentation.Markdown.Sections.DelegatesSection')  
&#8627; [EnumFieldsSection](EnumFieldsSection.md 'DefaultDocumentation.Markdown.Sections.EnumFieldsSection')  
&#8627; [EnumsSection](EnumsSection.md 'DefaultDocumentation.Markdown.Sections.EnumsSection')  
&#8627; [EventsSection](EventsSection.md 'DefaultDocumentation.Markdown.Sections.EventsSection')  
&#8627; [ExplicitInterfaceImplementationsSection](ExplicitInterfaceImplementationsSection.md 'DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSection')  
&#8627; [FieldsSection](FieldsSection.md 'DefaultDocumentation.Markdown.Sections.FieldsSection')  
&#8627; [InterfacesSection](InterfacesSection.md 'DefaultDocumentation.Markdown.Sections.InterfacesSection')  
&#8627; [MethodsSection](MethodsSection.md 'DefaultDocumentation.Markdown.Sections.MethodsSection')  
&#8627; [NamespacesSection](NamespacesSection.md 'DefaultDocumentation.Markdown.Sections.NamespacesSection')  
&#8627; [OperatorsSection](OperatorsSection.md 'DefaultDocumentation.Markdown.Sections.OperatorsSection')  
&#8627; [ParametersSection](ParametersSection.md 'DefaultDocumentation.Markdown.Sections.ParametersSection')  
&#8627; [PropertiesSection](PropertiesSection.md 'DefaultDocumentation.Markdown.Sections.PropertiesSection')  
&#8627; [StructsSection](StructsSection.md 'DefaultDocumentation.Markdown.Sections.StructsSection')  
&#8627; [TypeParametersSection](TypeParametersSection.md 'DefaultDocumentation.Markdown.Sections.TypeParametersSection')

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection')

| Constructors | |
| :--- | :--- |
| [ChildrenSection(string, string)](ChildrenSection_T_.ChildrenSection(string,string).md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>.ChildrenSection(string, string)') | Base constructor of the [ChildrenSection&lt;T&gt;](ChildrenSection_T_.md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>') type. |

| Properties | |
| :--- | :--- |
| [Name](ChildrenSection_T_.Name.md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>.Name') | Gets the name of the section, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [GetChildren(IGeneralContext, DocItem)](ChildrenSection_T_.GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>.GetChildren(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') to write. |
| [Write(IWriter)](ChildrenSection_T_.Write(IWriter).md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>.Write(DefaultDocumentation.Api.IWriter)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter'). |
