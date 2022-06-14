#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.FileNameFactories](index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation.Markdown.FileNameFactories')

## Md5Factory Class

[IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory') implementation using an md5 on the [FullName](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.FullName.md 'DefaultDocumentation.Models.DocItem.FullName') as file name.

```csharp
public sealed class Md5Factory : DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [AMarkdownFactory](AMarkdownFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory') &#129106; Md5Factory

| Fields | |
| :--- | :--- |
| [ConfigName](Md5Factory.ConfigName.md 'DefaultDocumentation.Markdown.FileNameFactories.Md5Factory.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](Md5Factory.Name.md 'DefaultDocumentation.Markdown.FileNameFactories.Md5Factory.Name') | Gets the name of the factory, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [GetMarkdownFileName(IGeneralContext, DocItem)](Md5Factory.GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.FileNameFactories.Md5Factory.GetMarkdownFileName(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem'). |
