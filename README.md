# DefaultDocumentation
As the name imply, this project lets you easily produce a markdown documentation from the generated assembly and its xml documentation produced by visual studio from comments.

api
[![NuGet api](https://img.shields.io/nuget/v/DefaultDocumentation.Api)](https://www.nuget.org/packages/DefaultDocumentation.Api)
[![preview api](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/pkgs/nuget/DefaultDocumentation.Api)

markdown
[![NuGet markdown](https://img.shields.io/nuget/v/DefaultDocumentation.Markdown)](https://www.nuget.org/packages/DefaultDocumentation.Markdown)
[![preview markdown](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/pkgs/nuget/DefaultDocumentation.Markdown)

msbuild task
[![NuGet msbuild task](https://img.shields.io/nuget/v/DefaultDocumentation)](https://www.nuget.org/packages/DefaultDocumentation)
[![preview msbuild task](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/pkgs/nuget/DefaultDocumentation)

dotnet tool
[![NuGet dotnet tool](https://img.shields.io/nuget/v/DefaultDocumentation.Console)](https://www.nuget.org/packages/DefaultDocumentation.Console)
[![preview dotnet tool](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/pkgs/nuget/DefaultDocumentation.Console)

![continuous integration status](https://github.com/doraku/defaultdocumentation/workflows/continuous%20integration/badge.svg)
[![Coverage Status](https://coveralls.io/repos/github/Doraku/DefaultDocumentation/badge.svg?branch=master)](https://coveralls.io/github/Doraku/DefaultDocumentation?branch=master)

- [Api documentation](./documentation/api/index.md 'Api documentation')
- [Markdown documentation](./documentation/markdown/index.md 'Markdown documentation')
<a/>

- [Requirement](#Requirement)
- [Usage](#Usage)
  - [MSBuild task](#Usage_MSBuildTask)
  - [Dotnet tool](#Usage_DotnetTool)
- [Overview](#Overview)
  - [Exclude documentation](#Overview_Exclude)
  - [Inherit documentation](#Overview_Inherit)
  - [Assembly documentation](#Overview_Assembly)
  - [Namespace documentation](#Overview_Namespace)
  - [Extern links](#Overview_Links)
  - [Plugins](#Overview_Plugins)
- [Configuration](#Configuration)
  - [ConfigurationFilePath](#Configuration_ConfigurationFilePath)
  - [LogLevel](#Configuration_LogLevel)
  - [AssemblyFilePath](#Configuration_AssemblyFilePath)
  - [DocumentationFilePath](#Configuration_DocumentationFilePath)
  - [OutputDirectoryPath](#Configuration_OutputDirectoryPath)
  - [AssemblyPageName](#Configuration_AssemblyPageName)
  - [GeneratedAccessModifiers](#Configuration_GeneratedAccessModifiers)
  - [IncludeUndocumentedItems](#Configuration_IncludeUndocumentedItems)
  - [GeneratedPages](#Configuration_GeneratedPages)
  - [LinksOutputFilePath](#Configuration_LinksOutputFilePath)
  - [LinksBaseUrl](#Configuration_LinksBaseUrl)
  - [ExternLinksFilePaths](#Configuration_ExternLinksFilePaths)
  - [Plugins](#Configuration_Plugins)
  - [DocItemGenerators](#Configuration_DocItemGenerators)
  - [UrlFactories](#Configuration_UrlFactories)
  - [Elements](#Configuration_Elements)
- [DocItem Configuration](#DocItemConfiguration)
  - [FileNameFactory](#DocItemConfiguration_FileNameFactory)
  - [Sections](#DocItemConfiguration_Sections)
- [Markdown Configuration](#MarkdownConfiguration)
  - [NestedTypeVisibilities](#MarkdownConfiguration_NestedTypeVisibilities)
  - [RemoveFileExtensionFromUrl](#MarkdownConfiguration_RemoveFileExtensionFromUrl)
  - [InvalidCharReplacement](#MarkdownConfiguration_InvalidCharReplacement)
  - [HandleLineBreak](#MarkdownConfiguration_HandleLineBreak)
  - [TableOfContentsModes](#MarkdownConfiguration_TableOfContentsModes)
  - [Url format](#MarkdownConfiguration_UrlFormat)
  - [Exclude](#MarkdownConfiguration_Exclude)
  - [UseFullUrl](#MarkdownConfiguration_UseFullUrl)
- [Samples](#Samples)
- [Dependencies](#Dependencies)

<a name='Requirement'></a>
# Requirement
- for the msbuild task: any runtime supporting netstandard2.0
- for the dotnet tool: netcore3.1, net5.0 or net6.0

<a name='Usage'></a>
# Usage
DefaultDocumentation is available in two flavour, an msbuild task automatically integrated in a post build target when referencing the nuget package, using msbuild properties to configure it and a dotnet tool console.

<a name='Usage_MSBuildTask'></a>
## MSBuild task
Simply reference the [DefaultDocumentation](https://www.nuget.org/packages/DefaultDocumentation) package in the projet you want to generate documentation for (don't worry it's only a development dependencies, no dlls will be added to your project). If the property `<DocumentationFile>` or `<GenerateDocumentationFile>` are set, the markdown pages will be produced automatically after a successfull build, that's it!  
You can disable the documentation generation by setting the `<DisableDefaultDocumentation>` to `true` in your csproj.
```xml
...
<Project Sdk="Microsoft.NET.Sdk">
    ...
	<PropertyGroup>
		<GenerateDocumentationFile>true</GenerateDocumentationFile>
	</PropertyGroup>
    ...
    <ItemGroup>
	    <PackageReference Include="DefaultDocumentation" Version="0.8.0" PrivateAssets="all"/>
    </ItemGroup>
    ...
</Project>
```

<a name='Usage_DotnetTool'></a>
## Dotnet tool
DefaultDocumentation is also available as a [dotnet tool](https://www.nuget.org/packages/DefaultDocumentation.Console) if you need to control when to produce the documentation. The tool command is simply `defaultdocumentation`.
To install the tool simply use this command:
```
dotnet tool install DefaultDocumentation.Console -g
```

<a name='Overview'></a>
# Overview
List of supported balises and attributes taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags) with some additions.

List of supported members taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/#id-strings)

<a name='Overview_Exclude'></a>
## Exclude documentation
It is possible to exclude a type/member from the generated documentation by adding a `<exclude/>` element to its xml documentation.

<a name='Overview_Inherit'></a>
## Inherit documentation
The [`<inheritdoc>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#inheritdoc) element is supported to reused existing documentations if available.
Note that this is a full import of the inherited documentation, any additional xml documentation will be ignored.

<a name='Overview_Assembly'></a>
## Assembly documentation
It is possible to declare xml documentation for your assembly by adding a special class named `AssemblyDoc` in a namespace with the name of the assembly.
```csharp
namespace YourAssemblyName
{
    /// <summary>
    /// your assembly documentation, used on the assembly page
    /// </summary>
    internal static class AssemblyDoc { } // internal so it is not visible outside the assembly
}
```

<a name='Overview_Namespace'></a>
## Namespace documentation
It is possible to declare xml documentation for a namespace by adding a special class named `NamespaceDoc` in the desired namespace.
```csharp
namespace YourNamespace
{
    /// <summary>
    /// your namespace documentation
    /// </summary>
    internal static class NamespaceDoc { } // internal so it is not visible outside the assembly
}
```

<a name='Overview_Links'></a>
## Extern links
When using `cref` attributes, you may refer items from other assemblies which DefaultDocumentation has no knowledge of their documentation location. By default, it will use the provided [UrlFactories](#Configuration_UrlFactories) that may produce incorrect links.  
To remedy this, DefaultDocumentation use files for explicit links with the following simple format:
```
http://extern/assembly/documentation/base/url/
T:ExternAssembly.ExternType|extern_type.html|ExternType
M:ExternAssembly.ExternType.ExternMethod|extern_type_extern_method.html|ExternType
```
The first element is the base url that will be put before each following documentation page.  
After that, you can have as many items with the following format: `entity id`|`base url relative link to the documentation page`|`display name to use (optional)`.  
You can change the base url in the same file for the following items.
```
http://extern/assembly/documentation/base/url/
T:ExternAssembly.ExternType|extern_type.html|ExternType
M:ExternAssembly.ExternType.ExternMethod|extern_type_extern_method.html|ExternType
http://extern/other/assembly/documentation/base/url/
T:OtherExternAssembly.ExternType|extern_type.html|ExternType
```
DefaultDocumentation can generate this file automatically for your assembly as it generates its documentation so can you easilly reference your own assembly documentation in other project, see [LinksOutputFilePath](#Configuration_LinksOutputFilePath) and [LinksBaseUrl](#Configuration_LinksBaseUrl) settings.

Links files have no defined extension.

<a name='Overview_Plugins'></a>
## Plugins
DefaultDocumentation is completely extensible in the form of plugin. The [api](https://www.nuget.org/packages/DefaultDocumentation.Api) serves as a base for contracts you can use to add features to your own documentation generation.  
See the [api reference](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/index.md#DefaultDocumentation.Api) for the list of interfaces for which you can provide your own implementations.  
See [Plugins](#Configuration_Plugins) setting for how to use a plugin and the [samples](https://github.com/Doraku/DefaultDocumentation/tree/master/source/Sample) for examples of implementations.

<a name='Configuration'></a>
# Configuration
Here is all the available settings to help you build your documentation as you wish.

<a name='Configuration_ConfigurationFilePath'></a>
## ConfigurationFilePath
- csproj property: `<DefaultDocumentationConfigurationFile>...</DefaultDocumentationConfigurationFile>`, default value is `DefaultDocumentation.json` in the project folder
- tool argument: `-j ...` `--ConfigurationFilePath ...`

The path to a json configuration file. If values are also provided by csproj property (msbuild task usage) or argument (tool usage) they will override what is inside the configuration file.  
Note that using a configuration file allow you to provide specific settings per DocItem type. See [DocItem Configuration](#DocItemConfiguration) for more informations.  
All relative path specified in the configuration file are relative to the actual configuration file path.

<a name='Configuration_LogLevel'></a>
## LogLevel
- csproj property: `<DefaultDocumentationLogLevel>...</DefaultDocumentationLogLevel>`
- tool argument: `-h ...` `--LogLevel ...`
- configuration file: `"LogLevel": "..."`

The minimum level of the log you wish to be displayed to help resolve errors, `Info` by default. Available values are:
- `Trace`: Trace log level
- `Debug`: Debug log level
- `Info`: Info log level
- `Warn`: Warn log level
- `Error`: Error log level
- `Fatal`: Fatal log level
- `Off`: no log

<a name='Configuration_AssemblyFilePath'></a>
## AssemblyFilePath
- csproj property: this setting is set automatically for you by the msbuild task
- tool argument: `-a ...` `--AssemblyFilePath ...`
- configuration file: `"AssemblyFilePath": "..."`

The path to the assembly file you wish to create documentation for.

<a name='Configuration_DocumentationFilePath'></a>
## DocumentationFilePath
- csproj property: this setting is set automatically for you by the msbuild task
- tool argument: `-d ...` `--DocumentationFilePath ...`
- configuration file: `"DocumentationFilePath": "..."`

The path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly.

<a name='Configuration_ProjectDirectoryPath'></a>
## ProjectDirectoryPath
- csproj property: this setting is set automatically for you by the msbuild task
- tool argument: `-p ...` `--ProjectDirectoryPath ...`
- configuration file: `"ProjectDirectoryPath": "..."`

the path to the project source folder. This is only used if you reference a file using a `source` attribute in a `<code>` element.

<a name='Configuration_OutputDirectoryPath'></a>
## OutputDirectoryPath
- csproj property: `<DefaultDocumentationFolder>...</DefaultDocumentationFolder>`
- tool argument: `-o ...` `--OutputDirectoryPath ...`
- configuration file: `"OutputDirectoryPath": "..."`

The path to the output folder where the documentation will be generated. If not specified, the pages will be generated in the same folder as the xml documentation file.

<a name='Configuration_AssemblyPageName'></a>
## AssemblyPageName
- csproj property: `<DefaultDocumentationAssemblyPageName>...</DefaultDocumentationAssemblyPageName>`
- tool argument: `-n ...` `--AssemblyPageName ...`
- configuration file: `"AssemblyPageName": "..."`

The name of the page for the assembly documentation.  
Note that this page will not be generated if you do not provide a name for this setting and there is only one namespace in your project and there is no xml documentation for the assembly (see [Assembly documentation](#Overview_Assembly)).  
If you did not provide a name but the page still need to be generated, the default name `index` will be used.

<a name='Configuration_GeneratedAccessModifiers'></a>
## GeneratedAccessModifiers
- csproj property: `<DefaultDocumentationGeneratedAccessModifiers>...,...</DefaultDocumentationGeneratedAccessModifiers>`
- tool argument: `-s ...,...` `--GeneratedAccessModifiers ...,...`
- configuration file: `"GeneratedAccessModifiers": "...,..."`

State elements with which access modifier should be generated. All by default, available values are:
- `Public`: generates documentation for 'public' access modifier
- `Private`: generates documentation for 'private' access modifier
- `Protected`: generates documentation for 'protected' access modifier
- `Internal`: generates documentation for 'internal' access modifier
- `ProtectedInternal`: generates documentation for 'protected internal' access modifier
- `PrivateProtected`: generates documentation for 'private protected' access modifier
- `Api`: generates documentation for 'public', 'protected' and 'protected internal' access modifier.

<a name='Configuration_IncludeUndocumentedItems'></a>
## IncludeUndocumentedItems
- csproj property: `<DefaultDocumentationIncludeUndocumentedItems>...</DefaultDocumentationIncludeUndocumentedItems>`
- tool argument: `-u` `--IncludeUndocumentedItems`
- configuration file: `"IncludeUndocumentedItems": "..."`

If `true` items with no documentation will also be included in the generated documentation. `false` by default.

<a name='Configuration_GeneratedPages'></a>
## GeneratedPages
- csproj property: `<DefaultDocumentationGeneratedPages>...,...</DefaultDocumentationGeneratedPages>`
- tool argument: `-g ...,...` `--GeneratedPages ...,...`
- configuration file: `"GeneratedPages": "...,..."`

States which item should have their own pages, if not their documentation will be inlined in their parent's one, `Namespaces,Types,Members` by default. Available values are:
- `Assembly`: the assembly should have its own page, see [AssemblyPageName](#Configuration_AssemblyPageName) for case when the assembly will have its page generated regardless of this flag being present
- `Namespaces`: namespaces should have their own pages
- `Classes`: classes should have their own pages
- `Delegates`: delegates should have their own pages
- `Enums`: enums should have their own pages
- `Structs`: structs should have their own pages
- `Interfaces`: interfaces should have their own pages
- `Types`: equivalent to `Classes, Delegates, Enums, Structs, Interfaces`
- `Constructors`: constructors should have their own pages
- `Events`: events should have their own pages
- `Fields`: fields should have their own pages
- `Methods`: methods should have their own pages
- `Operators`: operators should have their own pages
- `Properties`: properties should have their own pages
- `ExplicitInterfaceImplementations`: property and method explicit interface implementations should have their own pages
- `Members`: equivalent to `Constructors, Events, Fields, Methods, Operators, Properties, ExplicitInterfaceImplementations`

<a name='Configuration_LinksOutputFilePath'></a>
## LinksOutputFilePath
- csproj property: `<
sOutputFile>...</DefaultDocumentationLinksOutputFile>`
- tool argument: `-l ...` `--LinksOutputFilePath ...`
- configuration file: `"LinksOutputFilePath": "..."`

Where to generate the links file, see [Extern links](#Overview_Links) for more information, empty by default and does not generate the links file.

<a name='Configuration_LinksBaseUrl'></a>
## LinksBaseUrl
- csproj property: `<DefaultDocumentationLinksBaseUrl>...</DefaultDocumentationLinksBaseUrl>`
- tool argument: `-b ...` `--LinksBaseUrl ...`
- configuration file: `"LinksBaseUrl": "..."`

The base url to use for the links file, see [Extern links](#Overview_Links) for more information.

<a name='Configuration_ExternLinksFilePaths'></a>
## ExternLinksFilePaths
- csproj property: `<DefaultDocumentationExternLinksFiles>...|...</DefaultDocumentationExternLinksFiles>`
- tool argument: `-e ...|...` `--ExternLinksFilePaths ...|...`
- configuration file: `"ExternLinksFilePaths": [ "...", "..." ]`

The list of links files to use when generating the documentation, see [Extern links](#Overview_Links) for more information.  
You can use pattern, ex: `.\myfolder\*.txt`.

<a name='Configuration_Plugins'></a>
## Plugins
- csproj property: `<DefaultDocumentationPlugins>...|...</DefaultDocumentationPlugins>`
- tool argument: `--Plugins ...|...`
- configuration file: `"Plugins": [ "...", "..." ]`

The list of plugin files to load to create the documentation. See [Plugins](#Overview_Plugins) for more information.

<a name='Configuration_DocItemGenerators'></a>
## DocItemGenerators
- csproj property: `<DefaultDocumentationDocItemGenerators>...|...</DefaultDocumentationDocItemGenerators>`
- tool argument: `--DocItemGenerators ...|...`
- configuration file: `"DocItemGenerators": [ "...", "..." ]`

`Name` or `Type Assembly` of the `IDocItemGenerator` implementations to use to generate the `DocItem` of the documentation.
The default implementations provided are:
- `Exclude` or `DefaultDocumentation.Markdown.DocItemGenerators.ExcludeGenerator DefaultDocumentation.Markdown` remove `DocItem` from the documentation generation based on [MarkdownConfiguration.Exclude](#MarkdownConfiguration_Exclude).
- `Overloads` or `DefaultDocumentation.Markdown.DocItemGenerators.OverloadsGenerator DefaultDocumentation.Markdown` adds pages to group constructor and method overloads the same way microsoft documentation do it.
The default value is `Exclude|Overloads`.

<a name='Configuration_UrlFactories'></a>
## UrlFactories
- csproj property: `<DefaultDocumentationUrlFactories>...|...</DefaultDocumentationUrlFactories>`
- tool argument: `--UrlFactories ...|...`
- configuration file: `"UrlFactories": [ "...", "..." ]`

`Name` or `Type Assembly` of the `IUrlFactory` implementations to use to create documentation url. The element id is passed to each successive implementations and the first non null returned url is used.
The default implementations provided are:
- `DocItem` or `DefaultDocumentation.Markdown.UrlFactories.DocItemFactory DefaultDocumentation.Markdown` returns an url for known `DocItem`.
- `DotnetApi` or `DefaultDocumentation.Markdown.UrlFactories.DotnetApiFactory DefaultDocumentation.Markdown` returns an url formated from the id to its possible dotnet api documentation.
The default value is `DocItem|DotnetApi`.

<a name='Configuration_Elements'></a>
## Elements
- csproj property: `<DefaultDocumentationElements>...|...</DefaultDocumentationElements>`
- tool argument: `--Elements ...|...`
- configuration file: `"Elements": [ "...", "..." ]`

`Type Assembly` of the explicit `IElement` implementations to use to create the documentation.  
By default all implementations are used but if multiple ones have the same name, the one from the latest plugin loaded is used. In case you may want to use a plugin that contains an `IElement` implementation but still use one from an other plugin, you can force its usage by stating its `Type Assembly` explicitely.
The default implementations provided are:
- `DefaultDocumentation.Markdown.Elements.CElement DefaultDocumentation.Markdown` handle the rendering of [`<c>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#c) element
- `DefaultDocumentation.Markdown.Elements.CodeElement DefaultDocumentation.Markdown` handle the rendering of [`<code>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#code) element. Attributes handled are:
  - `language` attribute used to declare the languge of the code
  - `source` attribute used to reference code from a specific file
  - `region` attribute used to reference a specific `#region` from the source
- `DefaultDocumentation.Markdown.Elements.ListElement DefaultDocumentation.Markdown` handle the rendering of [`<list>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#list) element
- `DefaultDocumentation.Markdown.Elements.NoteElement DefaultDocumentation.Markdown` handle the rendering of [`<note>`](https://ewsoftware.github.io/XMLCommentsGuide/html/4302a60f-e4f4-4b8d-a451-5f453c4ebd46.htm) element
- `DefaultDocumentation.Markdown.Elements.ParaElement DefaultDocumentation.Markdown` handle the rendering of [`<para>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#para) element. Attributes handled are:
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `DefaultDocumentation.Markdown.Elements.ParamRefElement DefaultDocumentation.Markdown` handle the rendering of [`<paramref>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#paramref) element
- `DefaultDocumentation.Markdown.Elements.SeeElement DefaultDocumentation.Markdown` handle the rendering of [`<see>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#see). Attributes handled are:
  - [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#cref-attribute) attribute
  - `href` attribute
  - `langword` attribute
- `DefaultDocumentation.Markdown.Elements.TypeParamRefElement DefaultDocumentation.Markdown` handle the rendering of [`<typeparamref>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#typeparamref) element

<a name='DocItemConfiguration'></a>
# DocItem Configuration
Those next settings can be overrided for each `DocItem` type when using a configuration file, allowing you to have different settings for each type. If no specific setting is defined for a given type, the root setting will be used.
```
{
    "Sections": [
        "Header",
        "Default",
    ]
    "NamespaceDocItem": {
        "Sections": [
            "Title",
            "summary",
            "TableOfContents"
        ]
    }
}
```
The different `DocItem` types are:
- `AssemblyDocItem`
- `NamespaceDocItem`
- `ClassDocItem`
- `StructDocItem`
- `InterfaceDocItem`
- `EnumDocItem`
- `DelegateDocItem`
- `ConstructorDocItem`
- `EnumFieldDocItem`
- `EventDocItem`
- `ExplicitInterfaceImplementationDocItem`
- `FieldDocItem`
- `MethodDocItem`
- `OperatorDocItem`
- `PropertyDocItem`
- `TypeParameterDocItem`
- `ParameterDocItem`

<a name='DocItemConfiguration_FileNameFactory'></a>
## FileNameFactory
- csproj property: `<DefaultDocumentationFileNameFactory>...</DefaultDocumentationFileNameFactory>`
- tool argument: `--FileNameFactory ...`
- configuration file: `"FileNameFactory": "..."`

`Name` or `Type Assembly` of the `IFileNameFactory` implementation to use to generate the name of pages. Available implementations are:
- `FullName` or `DefaultDocumentation.Markdown.FileNameFactories.FullNameFactory DefaultDocumentation.Markdown` uses the fully qualified name of each member
- `Name` or `DefaultDocumentation.Markdown.FileNameFactories.NameFactory DefaultDocumentation.Markdown` removes the namespace (collisions can happen if there is multiple types with the same name in different namespaces)
- `Md5` or `DefaultDocumentation.Markdown.FileNameFactories.Md5Factory DefaultDocumentation.Markdown` uses a Md5 of the full name of each member to produce shorter name, collisions can happen
- `NameAndMd5Mix` or `DefaultDocumentation.Markdown.FileNameFactories.NameAndMd5MixFactory DefaultDocumentation.Markdown` removes the namespace and use a Md5 for parameters
- `DirectoryName` or `DefaultDocumentation.Markdown.FileNameFactories.DirectoryNameFactory DefaultDocumentation.Markdown` use a directory hierarchy
The default value is `FullName`. All those implementations *WILL* delete any `.md` file *EXCEPT* a file named `readme.md`.

<a name='DocItemConfiguration_Sections'></a>
## Sections
- csproj property: `<DefaultDocumentationSections>...|...</DefaultDocumentationSections>`
- tool argument: `--Sections ...|...`
- configuration file: `"Sections": [ "...", "..." ]`

`Name` or `Type Assembly` of the `ISection` implementations to use in order for the generation of the documentation. The available implentations are:
- `Header` or `DefaultDocumentation.Markdown.Sections.HeaderSection DefaultDocumentation.Markdown` to write links to parents and top pages
- `Footer` or `DefaultDocumentation.Markdown.Sections.FooterSection DefaultDocumentation.Markdown` to write a reference to this project
- `TypeParameters` or `DefaultDocumentation.Markdown.Sections.TypeParametersSection DefaultDocumentation.Markdown` to write the `TypeParameterDocItem` children links or inlined documentation
- `Parameters` or `DefaultDocumentation.Markdown.Sections.ParametersSection DefaultDocumentation.Markdown` to write the `ParameterDocItem` children links or inlined documentation
- `EnumFields` or `DefaultDocumentation.Markdown.Sections.EnumFieldsSection DefaultDocumentation.Markdown` to write the `EnumFieldDocItem` children links or inlined documentation
- `Constructors` or `DefaultDocumentation.Markdown.Sections.ConstructorsSection DefaultDocumentation.Markdown` to write the `ConstructorDocItem` children links or inlined documentation
- `Fields` or `DefaultDocumentation.Markdown.Sections.FieldsSection DefaultDocumentation.Markdown` to write the `FieldDocItem` children links or inlined documentation
- `Properties` or `DefaultDocumentation.Markdown.Sections.PropertiesSection DefaultDocumentation.Markdown` to write the `PropertyDocItem` children links or inlined documentation
- `Methods` or `DefaultDocumentation.Markdown.Sections.MethodsSection DefaultDocumentation.Markdown` to write the `MethodDocItem` children links or inlined documentation
- `Events` or `DefaultDocumentation.Markdown.Sections.EventsSection DefaultDocumentation.Markdown` to write the `EventDocItem` children links or inlined documentation
- `Operators` or `DefaultDocumentation.Markdown.Sections.OperatorsSection DefaultDocumentation.Markdown` to write the `OperatorDocItem` children links or inlined documentation
- `ExplicitInterfaceImplementations` or `DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSection DefaultDocumentation.Markdown` to write the `ExplicitInterfaceImplementationDocItem` children links or inlined documentation
- `Classes` or `DefaultDocumentation.Markdown.Sections.ClassesSection DefaultDocumentation.Markdown` to write the `ClassDocItem` children links or inlined documentation
- `Structs` or `DefaultDocumentation.Markdown.Sections.StructsSection DefaultDocumentation.Markdown` to write the `StructDocItem` children links or inlined documentation
- `Interfaces` or `DefaultDocumentation.Markdown.Sections.InterfacesSection DefaultDocumentation.Markdown` to write the `InterfaceDocItem` children links or inlined documentation
- `Enums` or `DefaultDocumentation.Markdown.Sections.EnumsSection DefaultDocumentation.Markdown` to write the `EnumDocItem` children links or inlined documentation
- `Delegates` or `DefaultDocumentation.Markdown.Sections.DelegatesSection DefaultDocumentation.Markdown` to write the `DelegateDocItem` children links or inlined documentation
- `Namespaces` or `DefaultDocumentation.Markdown.Sections.NamespacesSection DefaultDocumentation.Markdown` to write the `NamespaceDocItem` children links or inlined documentation
- `Definition` or `DefaultDocumentation.Markdown.Sections.DefinitionSection DefaultDocumentation.Markdown` to write the code definition
- `Derived` or `DefaultDocumentation.Markdown.Sections.DerivedSection DefaultDocumentation.Markdown` to write links to derived types
- `EventType` or `DefaultDocumentation.Markdown.Sections.EventTypeSection DefaultDocumentation.Markdown` to write the event type for `EventDocItem`
- `FieldValue` or `DefaultDocumentation.Markdown.Sections.FieldValueSection DefaultDocumentation.Markdown` to write the field value for `FieldDocItem`
- `Implement` or `DefaultDocumentation.Markdown.Sections.ImplementSection DefaultDocumentation.Markdown` to write links to implementations
- `Inheritance` or `DefaultDocumentation.Markdown.Sections.InheritanceSection DefaultDocumentation.Markdown` to write links to the inherited types
- `TableOfContents` or `DefaultDocumentation.Markdown.Sections.TableOfContentsSection DefaultDocumentation.Markdown` to write a table of content links to all children, see [TableOfContentsModes](#MarkdownConfiguration_TableOfContentsModes) setting
- `Title` or `DefaultDocumentation.Markdown.Sections.TitleSection DefaultDocumentation.Markdown` to write the title and link target of a `DocItem`
- `Definition` or `DefaultDocumentation.Markdown.Sections.DefinitionSection DefaultDocumentation.Markdown` to write the code definition
- `Default` or `DefaultDocumentation.Markdown.Sections.DefaultSection DefaultDocumentation.Markdown` is a grouping of those `ISection` implementations in this order:
  - `DefaultDocumentation.Markdown.Sections.TitleSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.SummarySection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.DefinitionSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.TypeParametersSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ParametersSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.EnumFieldsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.InheritanceSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.DerivedSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ImplementSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.EventTypeSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.FieldValueSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ValueSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ReturnsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ExceptionSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ExampleSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.RemarksSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.SeeAlsoSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.NamespacesSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ClassesSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.StructsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.InterfacesSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.EnumsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.DelegatesSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ConstructorsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.FieldsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.PropertiesSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.MethodsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.EventsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.OperatorsSection DefaultDocumentation.Markdown`
  - `DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSection DefaultDocumentation.Markdown`
- `example` or `DefaultDocumentation.Markdown.Sections.ExampleSection DefaultDocumentation.Markdown` to write the [`<example>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#example) element
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `exception` or `DefaultDocumentation.Markdown.Sections.ExceptionSection DefaultDocumentation.Markdown` to write the [`<exception>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#exception) elements
  - [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#cref-attribute) attribute
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `remarks` or `DefaultDocumentation.Markdown.Sections.RemarksSection DefaultDocumentation.Markdown` to write the [`<remarks>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#remarks) element
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `returns` or `DefaultDocumentation.Markdown.Sections.ReturnsSection DefaultDocumentation.Markdown` to write the [`<returns>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#returns) element
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `seealso` or `DefaultDocumentation.Markdown.Sections.SeeAlsoSection DefaultDocumentation.Markdown` to write the [`<seealso>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#seealso) elements
  - [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#cref-attribute) attribute
  - `href` attribute
- `summary` or `DefaultDocumentation.Markdown.Sections.SummarySection DefaultDocumentation.Markdown` to write the [`<summary>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#summary) element
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element
- `value` or `DefaultDocumentation.Markdown.Sections.ValueSection DefaultDocumentation.Markdown` to write the [`<value>`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags#value) element
  - `ignorelinebreak` attribute used to change the default setting of [IgnoreLineBreak](#MarkdownConfiguration_IgnoreLineBreak) for the content of this element

The default value is `Header|Default`.

<a name='MarkdownConfiguration'></a>
# Markdown Configuration
The default implementations to generate markdown documentation also comes with its own specific settings. Those can only be set in the configuration file and may or may not be overridable by specific `DocItem` types.

<a name='MarkdownConfiguration_NestedTypeVisibilities'></a>
## NestedTypeVisibilities
- configuration file: `"Markdown.NestedTypeVisibilities": "...,..."`

States where nested types should be visible. Available values are:
- `Namespace`: nested types will be displayed in their parent namespace
- `DeclaringType`: nested types will be displayed in their parent type

Default value is `Namespace`.  
This setting can be overriden by specific `DocItem` types.

<a name='MarkdownConfiguration_RemoveFileExtensionFromUrl'></a>
## RemoveFileExtensionFromUrl
- configuration file: `"Markdown.RemoveFileExtensionFromUrl": "..."`

`true` to remove the extension `.md` from links in the generated documentation, some wikies don't like those. `false` by default.  

<a name='MarkdownConfiguration_InvalidCharReplacement'></a>
## InvalidCharReplacement
- configuration file: `"Markdown.InvalidCharReplacement": "..."`

Provides the value to use to replace invalid char for file names, `_` by default.

<a name='MarkdownConfiguration_HandleLineBreak'></a>
## HandleLineBreak
- configuration file: `"Markdown.HandleLineBreak": "..."`

`true` if line break in the documentation should be transformed as markdown line break (two space at the end of a line) or not, `false` by default.  
This setting can be overriden by specific `DocItem` types.

<a name='MarkdownConfiguration_TableOfContentsModes'></a>
## TableOfContentsModes
- configuration file: `"Markdown.TableOfContentsModes": "...,..."`

States how the table of contents should be rendered. Available values are:
- `Grouped`: each `DocItem` kind should be grouped in their own section
- `IncludeKind`: display the kind of each `DocItem` explicitely
- `IncludeSummary`: the `<summary>` element of the `DocItem` should be displayed
- `IncludeNewLine`: their should be a newline between the `DocItem` name and its `<summary>` if displayed
- `IncludeSummaryWithNewLine`: same as `IncludeSummary,IncludeNewLine`

This setting can be overriden by specific `DocItem` types.

<a name='MarkdownConfiguration_UrlFormat'></a>
## Url format
- configuration file: `"Markdown.UrlFormat": ""`

State the format that will be used to display urls.

Three arguments will be passed to the format:
- the displayed text
- the url
- the tooltip to display when overing the link. If null the url will be used

The default value is `[{0}]({1} '{2}')`.

<a name='MarkdownConfiguration_Exclude'></a>
## Exclude
- configuration file: `"Markdown.Exclude": [ "", ... ]`

Contains a collection of regex used by the `DefaultDocumentation.Markdown.DocItemGenerators.ExcludeGenerator DefaultDocumentation.Markdown` [DocItemGenerator](#Configuration_DocItemGenerators),
any `DocItem` whose id will match one of them will be excluded from the documentation generation.

The default value is `null`.

<a name='MarkdownConfiguration_UseFullUrl'></a>
## UseFullUrl
- configuration file: `"Markdown.UseFullUrl": bool`

States if the url written should be absolute if a [LinksBaseUrl](#Configuration_LinksBaseUrl) is provided.

The default value is `false`.

<a name='Samples'></a>
# Samples
- [DefaultDocumentation api](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/index.md)
- [DefaultEcs api](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs.md)
- [DefaultUnDo api](https://github.com/Doraku/DefaultUnDo/blob/master/documentation/api/DefaultUnDo.md)

<a name='Dependencies'></a>
# Dependencies
DefaultDocumentation is only made possible thanks to those awesome projects:
- [CommandLineParser](https://github.com/commandlineparser/commandline)
- [ICSharpCode.Decompiler](https://github.com/icsharpcode/ILSpy)

CI, tests and code quality rely on those awesome projects:
- [Coverlet](https://github.com/coverlet-coverage/coverlet)
- [NFulent](https://github.com/tpierrain/NFluent)
- [NSubstitute](https://github.com/nsubstitute/NSubstitute)
- [Roslynator](https://github.com/JosefPihrt/Roslynator)
- [XUnit](https://github.com/xunit/xunit)
