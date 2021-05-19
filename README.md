# DefaultDocumentation
As the name imply, this project lets you easily produce a markdown documentation from the generated assembly and its xml documentation produced by visual studio from comments.

![continuous integration status](https://github.com/doraku/defaultdocumentation/workflows/continuous%20integration/badge.svg)  
msbuild task
[![NuGet msbuild task](https://buildstats.info/nuget/DefaultDocumentation)](https://www.nuget.org/packages/DefaultDocumentation)
[![preview msbuild task](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/packages/483535)  
dotnet tool
[![NuGet dotnet tool](https://buildstats.info/nuget/DefaultDocumentation.Console)](https://www.nuget.org/packages/DefaultDocumentation.Console)
[![preview dotnet tool](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultDocumentation/packages/724598)

- [Requirement](#Requirement)
- [Usage](#Usage)
  - [MSBuild task](#Usage_MSBuildTask)
  - [Dotnet tool](#Usage_DotnetTool)
- [Overview](#Overview)
- [Extern links](#Links)
- [Sample](#Sample)
- [Dependencies](#Dependencies)

<a name='Requirement'></a>
# Requirement
- for the msbuild task: any runtime supporting netstandard2.0
- for the dotnet tool: net5.0

<a name='Usage'></a>
# Usage
DefaultDocumentation is available in two flavour, an msbuild task automatically integrated in a post build target when referencing the nuget package, using msbuild properties to configure it and a dotnet tool console.
<a name='Usage_MSBuildTask'></a>
## MSBuild task
Simply reference the [DefaultDocumentation](https://www.nuget.org/packages/DefaultDocumentation) package in the projet you want to generate documentation for (don't worry it's only a development dependencies, no dlls will be added to your project). If the property `<DocumentationFile>` or `<GenerateDocumentationFile>` are set, the markdown pages will be produced automatically after a successfull build, that's it!  
Here are some DefaultDocumentation specific properties you can set to configure the generation:
- `<DisableDefaultDocumentation>`: if set to `true`, disable the DefaultDocumentation generation even if `<DocumentationFile>` or `<GenerateDocumentationFile>` are set.
- `<DefaultDocumentationFolder>`: where the markdown pages should be generated. If not specified, the pages will be generated in the same folder as the xml documentation file. All existing `.md` files except `readme.md` if present will be removed.
- `<DefaultDocumentationInvalidCharReplacement>`: the value to use to replace invalid char for file names, `_` by default.
- `<DefaultDocumentationAssemblyPageName>`: the name of the page for the assembly documentation, `index` by default.
- `<DefaultDocumentationFileNameMode>`: the way to generate file name for each page, `FullName` by default.
  - `FullName`: use the fully qualified name of each member
  - `Name`: remove the namespace (collisions can happen if there is multiple types with the same name in different namespaces)
  - `Md5`: use a Md5 of the full name of each member to produce shorter name, collisions can happen
  - `NameAndMd5Mix`: remove the namespace and use a Md5 for parameters
- `<DefaultDocumentationRemoveFileExtensionFromLinks>`: remove the `.md` extension from the links in the generated documentation, some wikies don't like those.
- `<DefaultDocumentationNestedTypeVisibilities>`: where to show nested types, `Namespace` by default. You can give multiple value separated by a `,`.
  - `Namespace`: nested types will appear on their namespace page
  - `DeclaringType`: nested types will appear on their declaring type page
- `<DefaultDocumentationGeneratedPages>`: which item should have their own pages, if not their documentation will be inlined in their parent's one, `Namespaces, Types, Members` by default. You can give multiple value separated by a `,`.
  - `Assembly`: the assembly should have its own page, note that if you have multiple namespaces, provided a `<DefaultDocumentationAssemblyPageName>` property or a `AssemblyDoc` type documentation, the assembly page will be generated regardless of this flag being present
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
- `<DefaultDocumentationLinksOutputFile>`: where to generate the links file, see [Extern links](#Links), empty by default and does not generate the links file.
- `<DefaultDocumentationLinksBaseUrl>`: the base url to use for the links file, see [Extern links](#Links).
- `<DefaultDocumentationExternLinksFiles>`: the list of links files separated by `|` to use when generating the documentation, see [Extern links](#Links). You can use pattern, ex: `.\myfolder\*.txt`.

<a name='Usage_DotnetTool'></a>
## Dotnet tool
DefaultDocumentation is also available as a [dotnet tool](https://www.nuget.org/packages/DefaultDocumentation.Console) if you need to control when to produce the documentation. The tool command is simply `defaultdocumentation`.  
Here is the tool help, most of the parameters have the same fonctionalities as their equivalent `<DefaultDocumentation...>` property:
```
  -a, --AssemblyFilePath                Required. Path to the assembly file
  -d, --DocumentationFilePath           Path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly
  -p, --ProjectDirectoryPath            Path to the project source folder
  -o, --OutputDirectoryPath             Path to the output folder, if not specified the documentation will be generated in the same folder as the xml documentation file
  -c, --InvalidCharReplacement          Replacement for url invalid char
  -n, --AssemblyPageName                Name of the assembly documentaton file
  -m, --FileNameMode                    Naming convention to use for documentation files
  -x, --RemoveFileExtensionFromLinks    If true skip file extension in generated page links
  -v, --NestedTypeVisibilities          Emplacement of nested types in documentation
  -g, --GeneratedPages                  State which elements should have their own page
  -l, --LinksOutputFilePath             File path where the documentation will generate its links
  -b, --LinksBaseUrl                    Base url of the documentation for the generated links file
  -e, --ExternLinksFilePaths            Links files to use for external documentation
  --help                                Display this help screen.
  --version                             Display version information.
```
To install the tool simply use this command:
```
dotnet tool install DefaultDocumentation.Console -g
```

<a name='Overview'></a>
# Overview
List of supported balises and attributes taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments) with some additions.

- [x] [`<c>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/code-inline)
- [x] [`<code>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/code)
  - [x] `language` attribute used to declare the languge of the code
  - [x] `source` attribute used to reference code from a specific file
  - [x] `region` attribute used to reference a specific `#region` from the source
- [x] [`<example>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/example)
- [x] [`<exception>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/exception)
  - [x] [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/cref-attribute) attribute
- [x] `<exclude>` used to exclude an element and all its members from the documentation
- [x] [`<include>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/include)
- [x] [`<inheritdoc>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/inheritdoc)
  - [x] [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/cref-attribute) attribute
- [ ] [`<list>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/list) not supported yet
- [x] [`<para>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/para)
- [x] [`<param>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/param)
- [x] [`<paramref>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/paramref)
- [ ] [`<permission>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/permission) not supported yet
- [x] [`<remarks>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/remarks)
- [x] [`<returns>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/returns)
- [x] [`<see>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/see)
  - [x] [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/cref-attribute) attribute
  - [x] `href` attribute
  - [x] `langword` attribute
- [x] [`<seealso>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/seealso)
  - [x] [`cref`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/cref-attribute) attribute
  - [x] `href` attribute
- [x] [`<summary>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/summary)
- [x] [`<typeparam>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/typeparam)
- [x] [`<typeparamref>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/typeparamref)
- [x] [`<value>`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/value)

List of supported members taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/processing-the-xml-file)

Only elements with a xml documentation will appear in the generated documentation.

Assembly and Namespace documentation are available by adding a special class named `AssemblyDoc` in a namespace with the name of the assembly and `NamespaceDoc` into the namespace. You should only use `<summary>` and `<remarks>` elements.  
Empty namespace with no defined types will not appear in the generated documentation.  
```
namespace YourAssemblyName
{
    /// <summary>
    /// your assembly documentation, used on the home page
    /// </summary>
    internal static class AssemblyDoc { } // internal so it is not visible outside the assembly
}

namespace YourNamespace
{
    /// <summary>
    /// your namespace documentation
    /// </summary>
    internal static class NamespaceDoc { } // internal so it is not visible outside the assembly
}
```

Should you need some extra support feel free to ask or even do it yourself in a pull request.

<a name='Links'></a>
# Extern links
When using `cref` attributes, you may refer items from other assemblies which DefaultDocumentation has no knowledge of their documentation location. By default, it will try to generate a dotnet api link but you may reference a completely different assembly.  
To remedy this, DefaultDocumentation use links files with the following simple format:
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

DefaultDocumentation can generate this file automatically for your assembly as it generates its documentation so can you easilly reference your own assembly documentation in other project by using the `<DefaultDocumentationLinksOutputFile>` and `<DefaultDocumentationLinksBaseUrl>` properties.

Links files have no defined extension.

<a name='Sample'></a>
# Sample
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