# DefaultDocumentation

As the name imply, this project lets you easily produce a "good enough" markdown documentation from the xml documentation produced by visual studio from comments.


[![NuGet](https://img.shields.io/badge/nuget-v0.4.2-brightgreen.svg)](https://www.nuget.org/packages/DefaultDocumentation)

- [Requirement](#Requirement)
- [Usage](#Usage)
- [Overview](#Overview)
- [Sample](#Sample)

<a name='Requirement'></a>
# Requirement
netcoreapp2.1

<a name='Usage'></a>
# Usage
Once referenced in your project, if there is a `<DocumentationFile>`, markdown pages will be produced next to the xml file on compilation.
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
- [ ] `<include>` not yet
- [ ] `<list>` not yet
- [ ] `<para>` not yet
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
- [ ] `<value>` not yet

List of supported members taken from [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/processing-the-xml-file)

Should you need some extra support feel free to ask or even do it yourself in a pull request.

<a name='Sample'></a>
# Sample
You can see the result of DefaultDocumentation applied to a project [here](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs.md).