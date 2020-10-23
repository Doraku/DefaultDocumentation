# DefaultDocumentation
As the name imply, this project lets you easily produce a markdown documentation from the generated assembly and its xml documentation produced by visual studio from comments.

[![NuGet](https://buildstats.info/nuget/DefaultDocumentation)](https://www.nuget.org/packages/DefaultDocumentation)

- [Requirement](#Requirement)
- [Usage](#Usage)
- [Overview](#Overview)
- [Sample](#Sample)

<a name='Requirement'></a>
# Requirement
framework4.7.2 or netcoreapp3.0

<a name='Usage'></a>
# Usage
Once referenced in your project, if there is a `<DocumentationFile>` or `<GenerateDocumentationFile>`, markdown pages will be produced next to the xml file on compilation.  
Please be advised that existing `*.md` files in the directory will be deleted.

Should you want the markdown files to be produced in a different directory, you can do so by adding a `<DefaultDocumentationFolder>` element in your csproj with the desired path.  
Default home page name is `index` and can be changed by supplying a `<DefaultDocumentationHome>` element in your csproj with the desired file name.

The name of the documentation page will be generated with the full name of each member but it is possible to change this by setting a `DefaultDocumentationFileNameMode` element in your csproj with one of those values:
- FullName: the default behavior, will use the fully qualified name of each member
- Name: will only use type and member name without the namespace (experimental, you may get collision if you have multiple types with the same name in different namespaces)
- Md5: will do a Md5 of the full name of each member to produce shorter name (experimental, you may get collision)

By default, nested types are all visible on their namespace page. It is possible to change this behavior by setting a `DefaultDocumentationNestedTypeVisibility` element in your csproj with once of those values:
- Namespace: nested type links will be on the namespace page
- DeclaringType: nested type links will be on their declaring type page
- Everywhere: nested type links will be on both the namespace and their declaring type page

By default, nested types are all visible on their namespace page. It is possible to change this behavior by setting a `DefaultDocumentationNestedTypeVisibility` element in your csproj with once of those values:
- Namespace: nested type links will be on the namespace page
- DeclaringType: nested type links will be on their declaring type page
- Everywhere: nested type links will be on both the namespace and their declaring type page

By default, invalid chars for file name are replaced by `-`, you can change this behavior by setting a `DefaultDocumentationInvalidCharReplacement` element in your csproj with the replacement of your choosing.

By default, links are produced with the file extension but this is not compatible with github wiki pages. You can change this behavior by setting a `DefaultDocumentationWikiLinks` element in your csproj with the value `true`.

<a name='Overview'></a>
# Overview
List of supported balise taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments)

- [x] `<c>`
- [x] `<code>`
- [x] `cref attribute` in `<exception>`, `<see>` and `<seealso>` elements
- [x] `<example>`
- [x] `<exception>`
- [x] `<include>` (nothing to do)
- [ ] `<list>` not yet
- [x] `<para>`
- [x] `<param>`
- [x] `<paramref>`
- [ ] `<permission>` not yet
- [x] `<remarks>`
- [x] `<returns>`
- [x] `<see>`
- [x] `<seealso>` handled the same as `<see>`
- [x] `<summary>`
- [x] `<typeparam>`
- [x] `<typeparamref>`
- [x] `<value>`

List of supported members taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/processing-the-xml-file)

Assembly and Namespace documentation are available by adding a special class named `AssemblyDoc` in a namespace with the name of the assembly and `NamespaceDoc` into the namespace. Only `<summary>` and `<remarks>` are supported.  
Empty namespace with no defined types will not appear in the generated documentation.  
It is possible to exclude the documentation generation of a namespace/type/member by adding a `<exclude/>` element in the xml documentation.
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

Only elements with a xml documentation will appear in the generated documentation.

Should you need some extra support feel free to ask or even do it yourself in a pull request.

<a name='Sample'></a>
# Sample
You can see the result of DefaultDocumentation applied to a project [here](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/index.md).