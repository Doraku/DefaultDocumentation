#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.FileNameFactories](../../../../index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation\.Markdown\.FileNameFactories')

## BaseMarkdownFileNameFactory Class

Base implementation of the [IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory') to generate file with a `.md` extension\.
It will also replace invalid char that may be present with the [Markdown\.InvalidCharReplacement](https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement 'https://github\.com/Doraku/DefaultDocumentation\#invalidcharreplacement') setting\.

```csharp
public abstract class BaseMarkdownFileNameFactory : DefaultDocumentation.Api.IFileNameFactory
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; BaseMarkdownFileNameFactory

Derived  
&#8627; [FullNameFactory](../FullNameFactory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.FullNameFactory')  
&#8627; [Md5Factory](../Md5Factory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.Md5Factory')  
&#8627; [NameAndMd5MixFactory](../NameAndMd5MixFactory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.NameAndMd5MixFactory')  
&#8627; [NameFactory](../NameFactory/index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.NameFactory')

Implements [IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory')

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [Clean\(IGeneralContext\)](Clean(IGeneralContext).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory\.Clean\(DefaultDocumentation\.IGeneralContext\)') | Cleans the [OutputDirectory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/ISettings/OutputDirectory.md 'DefaultDocumentation\.ISettings\.OutputDirectory') of the previously generated documentation files\. |
| [GetFileName\(IGeneralContext, DocItem\)](GetFileName(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory\.GetFileName\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the documentation file name for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
| [GetMarkdownFileName\(IGeneralContext, DocItem\)](GetMarkdownFileName(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.BaseMarkdownFileNameFactory\.GetMarkdownFileName\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
