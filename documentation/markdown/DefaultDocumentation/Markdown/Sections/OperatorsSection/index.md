#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## OperatorsSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [OperatorDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/OperatorDocItem/index.md 'DefaultDocumentation\.Models\.Members\.OperatorDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class OperatorsSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Members.OperatorDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[OperatorDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/OperatorDocItem/index.md 'DefaultDocumentation\.Models\.Members\.OperatorDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; OperatorsSection

| Constructors | |
| :--- | :--- |
| [OperatorsSection\(\)](OperatorsSection().md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection\.OperatorsSection\(\)') | Initialize a new instance of the [OperatorsSection](DefaultDocumentation/Markdown/Sections/OperatorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.OperatorsSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
