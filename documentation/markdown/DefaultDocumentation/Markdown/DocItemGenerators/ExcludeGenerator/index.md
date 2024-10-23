#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.DocItemGenerators](../../../../index.md#DefaultDocumentation.Markdown.DocItemGenerators 'DefaultDocumentation\.Markdown\.DocItemGenerators')

## ExcludeGenerator Class

Implementation of the [IDocItemGenerator](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IDocItemGenerator/index.md 'DefaultDocumentation\.Api\.IDocItemGenerator') to remove [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') from the documentation generation based on [Markdown\.Exclude](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_Exclude 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_Exclude')\.

```csharp
public sealed class ExcludeGenerator : DefaultDocumentation.Api.IDocItemGenerator
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; ExcludeGenerator

Implements [IDocItemGenerator](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IDocItemGenerator/index.md 'DefaultDocumentation\.Api\.IDocItemGenerator')

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.DocItemGenerators\.ExcludeGenerator\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.DocItemGenerators\.ExcludeGenerator\.Name') | Gets the name of the generator, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [Generate\(IDocItemsContext\)](Generate(IDocItemsContext).md 'DefaultDocumentation\.Markdown\.DocItemGenerators\.ExcludeGenerator\.Generate\(DefaultDocumentation\.IDocItemsContext\)') | Modified the known [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') of the [IDocItemsContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IDocItemsContext/index.md 'DefaultDocumentation\.IDocItemsContext')\. |
