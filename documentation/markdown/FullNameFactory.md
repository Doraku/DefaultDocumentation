#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.FileNameFactories](index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation.Markdown.FileNameFactories')

## FullNameFactory Class

[IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory') implementation using [FullName](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.FullName.md 'DefaultDocumentation.Models.DocItem.FullName') as file name.

```csharp
public sealed class FullNameFactory : DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [AMarkdownFactory](AMarkdownFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory') &#129106; FullNameFactory

| Fields | |
| :--- | :--- |
| [ConfigName](FullNameFactory.ConfigName.md 'DefaultDocumentation.Markdown.FileNameFactories.FullNameFactory.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](FullNameFactory.Name.md 'DefaultDocumentation.Markdown.FileNameFactories.FullNameFactory.Name') | Gets the name of the factory, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [GetMarkdownFileName(IGeneralContext, DocItem)](FullNameFactory.GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.FileNameFactories.FullNameFactory.GetMarkdownFileName(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem'). |
