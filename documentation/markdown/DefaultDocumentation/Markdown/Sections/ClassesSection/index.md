#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## ClassesSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [ClassDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Types/ClassDocItem/index.md 'DefaultDocumentation\.Models\.Types\.ClassDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class ClassesSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Types.ClassDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[ClassDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Types/ClassDocItem/index.md 'DefaultDocumentation\.Models\.Types\.ClassDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; ClassesSection

| Constructors | |
| :--- | :--- |
| [ClassesSection\(\)](ClassesSection().md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection\.ClassesSection\(\)') | Initialize a new instance of the [ClassesSection](DefaultDocumentation/Markdown/Sections/ClassesSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.ClassesSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
