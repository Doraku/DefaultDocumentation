#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## ParametersSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation to write [ParameterDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public sealed class ParametersSection : DefaultDocumentation.Markdown.Sections.ChildrenSection<DefaultDocumentation.Models.Parameters.ParameterDocItem>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [DefaultDocumentation.Markdown.Sections.ChildrenSection&lt;](ChildrenSection_T_.md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>')[ParameterDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem')[&gt;](ChildrenSection_T_.md 'DefaultDocumentation.Markdown.Sections.ChildrenSection<T>') &#129106; ParametersSection

| Constructors | |
| :--- | :--- |
| [ParametersSection()](ParametersSection.ParametersSection().md 'DefaultDocumentation.Markdown.Sections.ParametersSection.ParametersSection()') | Initialize a new instance of the [ParametersSection](ParametersSection.md 'DefaultDocumentation.Markdown.Sections.ParametersSection') type. |

| Fields | |
| :--- | :--- |
| [ConfigName](ParametersSection.ConfigName.md 'DefaultDocumentation.Markdown.Sections.ParametersSection.ConfigName') | The name of this implementation used at the configuration level. |

| Methods | |
| :--- | :--- |
| [GetChildren(IGeneralContext, DocItem)](ParametersSection.GetChildren(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.Sections.ParametersSection.GetChildren(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') to write. |
