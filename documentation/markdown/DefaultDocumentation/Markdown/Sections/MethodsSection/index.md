#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## MethodsSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [MethodDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/MethodDocItem/index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class MethodsSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Members.MethodDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[MethodDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/MethodDocItem/index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; MethodsSection

| Constructors | |
| :--- | :--- |
| [MethodsSection\(\)](MethodsSection().md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection\.MethodsSection\(\)') | Initialize a new instance of the [MethodsSection](DefaultDocumentation/Markdown/Sections/MethodsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetChildren\(IGeneralContext, DocItem\)](GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection\.GetChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to write\. |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
| [ShouldWriteTitle\(IGeneralContext, DocItem\)](ShouldWriteTitle(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.MethodsSection\.ShouldWriteTitle\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the title should be writen or not\. |
