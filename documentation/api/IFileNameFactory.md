#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api')

## IFileNameFactory Interface

Exposes methods related to the documentation files cleaning and creation.

```csharp
public interface IFileNameFactory
```

| Properties | |
| :--- | :--- |
| [Name](IFileNameFactory.Name.md 'DefaultDocumentation.Api.IFileNameFactory.Name') | Gets the name of the factory, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Clean(IGeneralContext)](IFileNameFactory.Clean(IGeneralContext).md 'DefaultDocumentation.Api.IFileNameFactory.Clean(DefaultDocumentation.IGeneralContext)') | Cleans the [OutputDirectory](ISettings.OutputDirectory.md 'DefaultDocumentation.ISettings.OutputDirectory') of the previously generated documentation files. |
| [GetFileName(IGeneralContext, DocItem)](IFileNameFactory.GetFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the documentation file name for the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem'). |
