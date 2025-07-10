#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.FileNameFactories](../../../../index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation\.Markdown\.FileNameFactories')

## NameAndMd5MixFactory Class

[IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory') implementation using [Name](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/Name.md 'DefaultDocumentation\.Models\.DocItem\.Name') and an md5 on the [FullName](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/FullName.md 'DefaultDocumentation\.Models\.DocItem\.FullName') as file name\.

```csharp
public sealed class NameAndMd5MixFactory : DefaultDocumentation.Markdown.FileNameFactories.BaseMarkdownFileNameFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [BaseMarkdownFileNameFactory](../BaseMarkdownFileNameFactory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory') &#129106; NameAndMd5MixFactory

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.NameAndMd5MixFactory\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.NameAndMd5MixFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetMarkdownFileName\(IGeneralContext, DocItem\)](GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.NameAndMd5MixFactory\.GetMarkdownFileName\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
