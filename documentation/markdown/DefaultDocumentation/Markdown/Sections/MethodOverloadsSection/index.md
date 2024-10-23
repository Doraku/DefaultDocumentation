#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## MethodOverloadsSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [MethodOverloadsSection](DefaultDocumentation/Markdown/Sections/MethodOverloadsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class MethodOverloadsSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Members.MethodDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[MethodDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Members/MethodDocItem/index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; MethodOverloadsSection

| Constructors | |
| :--- | :--- |
| [MethodOverloadsSection\(\)](MethodOverloadsSection().md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection\.MethodOverloadsSection\(\)') | Initialize a new instance of the [ConstructorsSection](../ConstructorsSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorsSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetChildren\(IGeneralContext, DocItem\)](GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection\.GetChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to write\. |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.MethodOverloadsSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
