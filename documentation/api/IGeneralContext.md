#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation')

## IGeneralContext Interface

Exposes settings used to generate documentation.

```csharp
public interface IGeneralContext :
DefaultDocumentation.IContext
```

Implements [IContext](IContext.md 'DefaultDocumentation.IContext')

| Properties | |
| :--- | :--- |
| [Elements](IGeneralContext.Elements.md 'DefaultDocumentation.IGeneralContext.Elements') | Gets the [IElement](IElement.md 'DefaultDocumentation.Api.IElement') used to render specific [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') from the documentation. |
| [Items](IGeneralContext.Items.md 'DefaultDocumentation.IGeneralContext.Items') | Gets all the [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') known by this documentation generation context. |
| [Settings](IGeneralContext.Settings.md 'DefaultDocumentation.IGeneralContext.Settings') | Gets the [ISettings](ISettings.md 'DefaultDocumentation.ISettings') of this documentation generation context. |

| Methods | |
| :--- | :--- |
| [GetContext(Type)](IGeneralContext.GetContext(Type).md 'DefaultDocumentation.IGeneralContext.GetContext(System.Type)') | Gets the specific [IContext](IContext.md 'DefaultDocumentation.IContext') for the given [System.Type](https_//docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type'). |
| [GetFileName(DocItem)](IGeneralContext.GetFileName(DocItem).md 'DefaultDocumentation.IGeneralContext.GetFileName(DefaultDocumentation.Models.DocItem)') | Gets the file name for the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem'). |
| [GetUrl(string)](IGeneralContext.GetUrl(string).md 'DefaultDocumentation.IGeneralContext.GetUrl(string)') | Gets the url of the given id. |
