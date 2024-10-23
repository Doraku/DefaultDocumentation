#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## ExplicitInterfaceImplementationsSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [ExplicitInterfaceImplementationDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/ExplicitInterfaceImplementationDocItem/index.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class ExplicitInterfaceImplementationsSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[ExplicitInterfaceImplementationDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/ExplicitInterfaceImplementationDocItem/index.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; ExplicitInterfaceImplementationsSection

| Constructors | |
| :--- | :--- |
| [ExplicitInterfaceImplementationsSection\(\)](ExplicitInterfaceImplementationsSection().md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection\.ExplicitInterfaceImplementationsSection\(\)') | Initialize a new instance of the [ExplicitInterfaceImplementationsSection](DefaultDocumentation/Markdown/Sections/ExplicitInterfaceImplementationsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.ExplicitInterfaceImplementationsSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
