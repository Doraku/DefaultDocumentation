#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## TypeParametersSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write [TypeParameterDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public sealed class TypeParametersSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Parameters.TypeParameterDocItem>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DefaultDocumentation\.Markdown\.Sections\.ChildrenSection&lt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>')[TypeParameterDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem')[&gt;](../ChildrenSection_T_/index.md 'DefaultDocumentation\.Markdown\.Sections\.ChildrenSection\<T\>') &#129106; TypeParametersSection

| Constructors | |
| :--- | :--- |
| [TypeParametersSection\(\)](TypeParametersSection().md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection\.TypeParametersSection\(\)') | Initialize a new instance of the [TypeParametersSection](DefaultDocumentation/Markdown/Sections/TypeParametersSection/index.md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection') type\. |

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetChildren\(IGeneralContext, DocItem\)](GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection\.GetChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to write\. |
| [ShouldInlineChildren\(IGeneralContext, DocItem\)](ShouldInlineChildren(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.Sections\.TypeParametersSection\.ShouldInlineChildren\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets if the children should be inlined or not\. |
