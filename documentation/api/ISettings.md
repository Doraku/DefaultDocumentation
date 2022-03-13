#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation')

## ISettings Interface

Exposes all the settings of the documentation generation process.

```csharp
public interface ISettings
```

| Properties | |
| :--- | :--- |
| [AssemblyFile](ISettings.AssemblyFile.md 'DefaultDocumentation.ISettings.AssemblyFile') | Gets the assembly file for which the documentation is being generated. |
| [AssemblyPageName](ISettings.AssemblyPageName.md 'DefaultDocumentation.ISettings.AssemblyPageName') | Gets the name of the assembly page name. |
| [DocumentationFile](ISettings.DocumentationFile.md 'DefaultDocumentation.ISettings.DocumentationFile') | Gets the xml documentation file of the [AssemblyFile](ISettings.AssemblyFile.md 'DefaultDocumentation.ISettings.AssemblyFile'). |
| [ExternLinksFiles](ISettings.ExternLinksFiles.md 'DefaultDocumentation.ISettings.ExternLinksFiles') | Gets the links files of external items which are not part of the dotnet api. |
| [GeneratedAccessModifiers](ISettings.GeneratedAccessModifiers.md 'DefaultDocumentation.ISettings.GeneratedAccessModifiers') | Gets the [GeneratedAccessModifiers](GeneratedAccessModifiers.md 'DefaultDocumentation.GeneratedAccessModifiers') flags stating which access modifiers should have their documentation generated. |
| [GeneratedPages](ISettings.GeneratedPages.md 'DefaultDocumentation.ISettings.GeneratedPages') | Gets the [GeneratedPages](GeneratedPages.md 'DefaultDocumentation.GeneratedPages') flags stating which kind should have their own page and which should be inlined. |
| [IncludeUndocumentedItems](ISettings.IncludeUndocumentedItems.md 'DefaultDocumentation.ISettings.IncludeUndocumentedItems') | Gets wether item with no xml documentation should have their documentation generated or not. |
| [InvalidCharReplacement](ISettings.InvalidCharReplacement.md 'DefaultDocumentation.ISettings.InvalidCharReplacement') | Gets the [System.String](https_//docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') used to replace characters that are invalid for a path or a file name. |
| [LinksBaseUrl](ISettings.LinksBaseUrl.md 'DefaultDocumentation.ISettings.LinksBaseUrl') | Gets the base url to prefix item url with when generating the links output file. |
| [LinksOutputFile](ISettings.LinksOutputFile.md 'DefaultDocumentation.ISettings.LinksOutputFile') | Gets the file name where all the url of the generated documentation should be writen to, to be used for referencing documentation generation. |
| [Logger](ISettings.Logger.md 'DefaultDocumentation.ISettings.Logger') | Gets the [NLog.ILogger](https_//docs.microsoft.com/en-us/dotnet/api/NLog.ILogger 'NLog.ILogger') of the process. |
| [OutputDirectory](ISettings.OutputDirectory.md 'DefaultDocumentation.ISettings.OutputDirectory') | Gets the output directory where the documentation is being generated. |
| [ProjectDirectory](ISettings.ProjectDirectory.md 'DefaultDocumentation.ISettings.ProjectDirectory') | Gets the root project directory where the sources of the [AssemblyFile](ISettings.AssemblyFile.md 'DefaultDocumentation.ISettings.AssemblyFile') are. |
