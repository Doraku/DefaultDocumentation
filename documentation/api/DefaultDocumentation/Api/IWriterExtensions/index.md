#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api')

## IWriterExtensions Class

Provides extension methods on the [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') type\.

```csharp
public static class IWriterExtensions
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; IWriterExtensions

| Methods | |
| :--- | :--- |
| [Append\(this IWriter, XElement\)](Append(thisIWriter,XElement).md 'DefaultDocumentation\.Api\.IWriterExtensions\.Append\(this DefaultDocumentation\.Api\.IWriter, System\.Xml\.Linq\.XElement\)') | Appends an [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement') to a [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') by using the [Elements](../../IGeneralContext/Elements.md 'DefaultDocumentation\.IGeneralContext\.Elements') of [Context](../IWriter/Context.md 'DefaultDocumentation\.Api\.IWriter\.Context')\. If no [IElement](../IElement/index.md 'DefaultDocumentation\.Api\.IElement') is found, the [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement') is appended as text directly\. |
| [AppendFormat\(this IWriter, string, object\[\]\)](AppendFormat(thisIWriter,string,object[]).md 'DefaultDocumentation\.Api\.IWriterExtensions\.AppendFormat\(this DefaultDocumentation\.Api\.IWriter, string, object\[\]\)') | Appends a formatted string to a [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\. |
| [AppendLine\(this IWriter, string\)](AppendLine(thisIWriter,string).md 'DefaultDocumentation\.Api\.IWriterExtensions\.AppendLine\(this DefaultDocumentation\.Api\.IWriter, string\)') | Appends a line after writing the provided [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')\. |
| [TrimEnd\(this IWriter, string\[\]\)](TrimEnd(thisIWriter,string[]).md 'DefaultDocumentation\.Api\.IWriterExtensions\.TrimEnd\(this DefaultDocumentation\.Api\.IWriter, string\[\]\)') | Trims from the end of a [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') all the provided values\. |
