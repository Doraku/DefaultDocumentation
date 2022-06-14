#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.FileNameFactories](index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation.Markdown.FileNameFactories')

## AMarkdownFactory Class

Base implementation of the [IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory') to generate file with a `.md` extension.  
It will also replace invalid char that may be present with the [Markdown.InvalidCharReplacement](https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement 'https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement') setting.

```csharp
public abstract class AMarkdownFactory :
DefaultDocumentation.Api.IFileNameFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AMarkdownFactory

Derived  
&#8627; [FullNameFactory](FullNameFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.FullNameFactory')  
&#8627; [Md5Factory](Md5Factory.md 'DefaultDocumentation.Markdown.FileNameFactories.Md5Factory')  
&#8627; [NameAndMd5MixFactory](NameAndMd5MixFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.NameAndMd5MixFactory')  
&#8627; [NameFactory](NameFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.NameFactory')

Implements [IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory')

| Properties | |
| :--- | :--- |
| [Name](AMarkdownFactory.Name.md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.Name') | Gets the name of the factory, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Clean(IGeneralContext)](AMarkdownFactory.Clean(IGeneralContext).md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.Clean(DefaultDocumentation.IGeneralContext)') | Cleans the [OutputDirectory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISettings.OutputDirectory.md 'DefaultDocumentation.ISettings.OutputDirectory') of the previously generated documentation files. |
| [GetFileName(IGeneralContext, DocItem)](AMarkdownFactory.GetFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.GetFileName(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the documentation file name for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem'). |
| [GetMarkdownFileName(IGeneralContext, DocItem)](AMarkdownFactory.GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.GetMarkdownFileName(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem'). |
