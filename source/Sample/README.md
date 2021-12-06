# [DefaultDocumentation.PluginExample](DefaultDocumentation.PluginExample/DefaultDocumentation.PluginExample.targets)

This is an example of a plugin project to extend DefaultDocumentation features.
The .targets file automatically adds the plugin to the `<DefaultDocumentationPlugins>` property so that referencing this plugin as a `PackageReference` is enough.
- in case of a custom `IFileNameFactory`, you still need to select the one you want with the `<DefaultDocumentationFileNameFactory>` property
- in case of a custom `IElement`, it will be automatically used
- in case of a custom `ISection`, you still need to add it to the `<DefaultDocumentationSections>` property

# [FolderFileNameFactory](DefaultDocumentation.PluginExample/FolderFileNameFactory.cs)

This is an example of a custom `IFileNameFactory` to generate a documentation organized in a folder hierarchy.