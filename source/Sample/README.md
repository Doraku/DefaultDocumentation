# [DefaultDocumentation.PluginExample](DefaultDocumentation.PluginExample/DefaultDocumentation.PluginExample.targets)

This is an example of a plugin project to extend DefaultDocumentation features.
The .targets file automatically adds the plugin to the `<DefaultDocumentationPlugins>` property so that referencing this plugin as a `PackageReference` is enough.
- in case of a custom `IFileNameFactory`, you still need to select the one you want with the `<DefaultDocumentationFileNameFactory>` property or `--FileNameFactory` arg
- in case of a custom `IElement`, it will be automatically used
- in case of a custom `ISection`, you still need to use it explicitly in the `<DefaultDocumentationSections>` property or `--FileNameFactory` arg

# [FolderFileNameFactory](DefaultDocumentation.PluginExample/FolderFileNameFactory.cs)

This is an example of a custom `IFileNameFactory` to generate a documentation organized in a folder hierarchy. Usage:
- msbuild task: `<DefaultDocumentationFileNameFactory>Folder</DefaultDocumentationFileNameFactory>`
- dotnet tool: `--FileNameFactory Folder`

# [NewElement](DefaultDocumentation.PluginExample/NewElement.cs)

This is an example of a custom `IElement` to handle a new xml tag.

# [NewSection](DefaultDocumentation.PluginExample/NewSection.cs)

This is an example of a custom `ISection` to add to the generated documentation. Usage:
- msbuild task: `<DefaultDocumentationSections>New|Header|Default</DefaultDocumentationSections>`
- dotnet tool: `--Sections New Header Default`