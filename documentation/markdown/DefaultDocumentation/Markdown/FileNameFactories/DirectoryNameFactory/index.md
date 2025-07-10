#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.FileNameFactories](../../../../index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation\.Markdown\.FileNameFactories')

## DirectoryNameFactory Class

[IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory') implementation using [Name](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/Name.md 'DefaultDocumentation\.Models\.DocItem\.Name') as file name in a directory hierarchy\.

```csharp
public sealed class DirectoryNameFactory : DefaultDocumentation.Api.IFileNameFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; DirectoryNameFactory

Implements [IFileNameFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory')

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.DirectoryNameFactory\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.DirectoryNameFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [Clean\(IGeneralContext\)](Clean(IGeneralContext).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.DirectoryNameFactory\.Clean\(DefaultDocumentation\.IGeneralContext\)') | Cleans the [OutputDirectory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/ISettings/OutputDirectory.md 'DefaultDocumentation\.ISettings\.OutputDirectory') of the previously generated documentation files\. |
| [GetFileName\(IGeneralContext, DocItem\)](GetFileName(IGeneralContext,DocItem).md 'DefaultDocumentation\.Markdown\.FileNameFactories\.DirectoryNameFactory\.GetFileName\(DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the documentation file name for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
