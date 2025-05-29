#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## ISettings Interface

Exposes all the settings of the documentation generation process\.

```csharp
public interface ISettings
```

| Properties | |
| :--- | :--- |
| [AssemblyFile](AssemblyFile.md 'DefaultDocumentation\.ISettings\.AssemblyFile') | Gets the assembly file for which the documentation is being generated\. |
| [AssemblyPageName](AssemblyPageName.md 'DefaultDocumentation\.ISettings\.AssemblyPageName') | Gets the name of the assembly page name\. |
| [DocumentationFile](DocumentationFile.md 'DefaultDocumentation\.ISettings\.DocumentationFile') | Gets the xml documentation file of the [AssemblyFile](AssemblyFile.md 'DefaultDocumentation\.ISettings\.AssemblyFile')\. |
| [ExternLinksFiles](ExternLinksFiles.md 'DefaultDocumentation\.ISettings\.ExternLinksFiles') | Gets the links files of external items which are not part of the dotnet api\. |
| [GeneratedAccessModifiers](GeneratedAccessModifiers.md 'DefaultDocumentation\.ISettings\.GeneratedAccessModifiers') | Gets the [GeneratedAccessModifiers](../GeneratedAccessModifiers/index.md 'DefaultDocumentation\.GeneratedAccessModifiers') flags stating which access modifiers should have their documentation generated\. |
| [GeneratedPages](GeneratedPages.md 'DefaultDocumentation\.ISettings\.GeneratedPages') | Gets the [GeneratedPages](../GeneratedPages/index.md 'DefaultDocumentation\.GeneratedPages') flags stating which kind should have their own page and which should be inlined\. |
| [IncludeUndocumentedItems](IncludeUndocumentedItems.md 'DefaultDocumentation\.ISettings\.IncludeUndocumentedItems') | Gets wether item with no xml documentation should have their documentation generated or not\. |
| [LinksBaseUrl](LinksBaseUrl.md 'DefaultDocumentation\.ISettings\.LinksBaseUrl') | Gets the base url to prefix item url with when generating the links output file\. |
| [LinksOutputFile](LinksOutputFile.md 'DefaultDocumentation\.ISettings\.LinksOutputFile') | Gets the file name where all the url of the generated documentation should be writen to, to be used for referencing documentation generation\. |
| [Logger](Logger.md 'DefaultDocumentation\.ISettings\.Logger') | Gets the [Microsoft\.Extensions\.Logging\.ILogger](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.ILogger 'Microsoft\.Extensions\.Logging\.ILogger') of the process\. |
| [OutputDirectory](OutputDirectory.md 'DefaultDocumentation\.ISettings\.OutputDirectory') | Gets the output directory where the documentation is being generated\. |
| [ProjectDirectory](ProjectDirectory.md 'DefaultDocumentation\.ISettings\.ProjectDirectory') | Gets the root project directory where the sources of the [AssemblyFile](AssemblyFile.md 'DefaultDocumentation\.ISettings\.AssemblyFile') are\. |
