#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.FileNameFactories](../../../../index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation\.Markdown\.FileNameFactories')

## FullNameFactory Class

[IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory') implementation using [FullName](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/FullName.md 'DefaultDocumentation\.Models\.DocItem\.FullName') as file name\.

```csharp
public sealed class FullNameFactory : DefaultDocumentation.Markdown.FileNameFactories.BaseMarkdownFileNameFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [BaseMarkdownFileNameFactory](../BaseMarkdownFileNameFactory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory') &#129106; FullNameFactory

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.FullNameFactory\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.FullNameFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetMarkdownFileName\(IGeneralContext, DocItem\)](GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.FullNameFactory\.GetMarkdownFileName\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
