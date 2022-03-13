#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api')

## IWriterExtension Class

Provides extension methods on the [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter') type.

```csharp
public static class IWriterExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IWriterExtension

| Methods | |
| :--- | :--- |
| [Append(this IWriter, XElement)](IWriterExtension.Append(thisIWriter,XElement).md 'DefaultDocumentation.Api.IWriterExtension.Append(this DefaultDocumentation.Api.IWriter, System.Xml.Linq.XElement)') | Appends an [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') to a [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter') by using the [Elements](IGeneralContext.Elements.md 'DefaultDocumentation.IGeneralContext.Elements') of [Context](IWriter.Context.md 'DefaultDocumentation.Api.IWriter.Context').<br/>If no [IElement](IElement.md 'DefaultDocumentation.Api.IElement') is found, the [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') is appended as text directly. |
| [AppendLine(this IWriter, string)](IWriterExtension.AppendLine(thisIWriter,string).md 'DefaultDocumentation.Api.IWriterExtension.AppendLine(this DefaultDocumentation.Api.IWriter, string)') | Appends a line after writing the provided [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String'). |
| [TrimEnd(this IWriter, string[])](IWriterExtension.TrimEnd(thisIWriter,string[]).md 'DefaultDocumentation.Api.IWriterExtension.TrimEnd(this DefaultDocumentation.Api.IWriter, string[])') | Trims from the end of a [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter') all the provided values. |
