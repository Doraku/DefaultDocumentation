# DefaultDocumentation
As the name imply, this project lets you easily produce a markdown documentation from the generated assembly and its xml documentation produced by visual studio from comments.

[![NuGet](https://buildstats.info/nuget/DefaultDocumentation)](https://www.nuget.org/packages/DefaultDocumentation)

- [Requirement](#Requirement)
- [Usage](#Usage)
- [Overview](#Overview)
- [Sample](#Sample)

<a name='Requirement'></a>
# Requirement
framework4.7.2 or netcoreapp2.0

<a name='Usage'></a>
# Usage
Once referenced in your project, if there is a `<DocumentationFile>` or `<GenerateDocumentationFile>`, markdown pages will be produced next to the xml file on compilation.  
Please be advised that existing `*.md` files in the directory will be deleted.

Should you want the markdown files to be produced in a different directory, you can do so by adding a `<DefaultDocumentationFolder>` element in your csproj with the desired path.

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

Namespace documentation is available by adding a special class named `NamespaceDoc` into the namespace. Only `<summary>` and `<remarks>` are supported.  
Empty namespace with no defined types will not appear in the generated documentation.
```
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