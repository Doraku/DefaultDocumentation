## DefaultDocumentation 0.6.12
fixed generic api link  

added csharp declaration to code tag  
added DefaultDocumentationInvalidCharReplacement parameters  
added constant field values  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.12)

## DefaultDocumentation 0.6.11
ignores readme.md files on deleting old markdowns  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.11)

## DefaultDocumentation 0.6.10
added Name FileNameMode (experimental, may generate name collission if multiple types have the same name in different namespaces)  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.10)

## DefaultDocumentation 0.6.7
fixed missing types link generation  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.7)

## DefaultDocumentation 0.6.6
fixed pointer member handling  
fixed ValueTuple member handling  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.6)

## DefaultDocumentation 0.6.5
added derived types from the assembly on type pages  

fixed AssemblyResolutionException for dependencies  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.5)

## DefaultDocumentation 0.6.3
added DefaultDocumentationNestedTypeVisibility parameter to set where nested types are displayed (possible value: Namespace, DeclaringType, Everywhere)  

fixed see element with langword attribute usage

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.3)

## DefaultDocumentation 0.6.2
added DefaultDocumentationFileNameMode parameter to change the way documentation pages are named (possible values: FullName, Md5)  

fixed invalid char in file name generation

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.2)

## DefaultDocumentation 0.6.1
fixed documentation generation for dynamic keyword  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.1)

## DefaultDocumentation 0.6.0
breaking change:  
changed netcoreapp to v3.0  
do not generate base homepage if there is only one namespace present and no DefaultDocumentationHome specified nor any AssemblyDoc  

fixed operator documentation page overlapping names  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.6.0)

## DefaultDocumentation 0.5.5
fixed TypeDocItem writing members of nested types  
fixed nested type not showing parent type in name  
fixed NullReferenceException for generic type  
fixed internal interfaces shown in implementation  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.5.5)

## DefaultDocumentation 0.5.2
fixed Property Returns title to Property Value  
fixed enum field link  
fixed leading whitespace in summary throwing an exception  

added assembly documentation for home page through special named type AssemblyDoc  
added DefaultDocumentationHome element to change home file name  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.5.2)

## DefaultDocumentation 0.5.1
added parameters default value in generated code example  
added inheritance and implementation type information  
added namespace documentation through special named class NamespaceDoc  

fixed generic type and array link generation  
fixed dotnet api link for generic and parameterized members  
fixed Property documentation using return element instead of value element  
fixed decorated member documentation not generated if parent type is not decorated  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.5.1)

## DefaultDocumentation 0.5.0
full rework to produce a much more complete documentation using the produced assembly  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.5.0)

## DefaultDocumentation 0.4.3
fixed crash when missing parent types  
fixed crash when missing generic parameter documentation  
changed dotnet path to be linux friendly  
retrograded target to netcore1.0  
added framework4.5 target  
added value support  
added para support  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.4.3)

## DefaultDocumentation 0.4.2
throw a better exception when missing documentation on generic types  
handle line break correctly  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.4.2)

## DefaultDocumentation 0.4.1
throw a better exception when missing documentation on generic types  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.4.1)

## DefaultDocumentation 0.4.0
added M full operator support  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.4.0)

## DefaultDocumentation 0.3.0
added c support  
added code support  
added example support  
added N support  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.3.0)

## DefaultDocumentation 0.2.0
added E event support  
added M operator support  
added P index support  
added T nested type support  
added remarks support  
added seealso support  
changed to use the name of the assembly in the xml instead of the file name as the main markdown page  

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.2.0)

## DefaultDocumentation 0.1.0
First release.

[nuget package](https://www.nuget.org/packages/DefaultDocumentation/0.1.0)