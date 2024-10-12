using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.SeeElementTests;

public sealed class WriteShould : BaseElementTester<SeeElement>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[] { AssemblyInfo.NamespaceDocItem }.ToDictionary(item => item.Id);

    [Fact]
    public void WriteWhenCref() => Test(
        new XElement("see", new XAttribute("cref", AssemblyInfo.NamespaceDocItem.Id)),
        "[DefaultDocumentation](N:DefaultDocumentation 'DefaultDocumentation')");

    [Fact]
    public void WriteWhenCrefWithValue() => Test(
        new XElement("see", new XAttribute("cref", AssemblyInfo.NamespaceDocItem.Id), "dummy"),
        "[dummy](N:DefaultDocumentation 'DefaultDocumentation')");

    [Fact]
    public void WriteWhenHref() => Test(
        new XElement("see", new XAttribute("href", "dummyurl")),
        "[dummyurl](dummyurl 'dummyurl')");

    [Fact]
    public void WriteWhenHrefWithValue() => Test(
        new XElement("see", new XAttribute("href", "dummyurl"), "dummy"),
        "[dummy](dummyurl 'dummyurl')");

    [Fact]
    public void WriteWhenLangword() => Test(
        new XElement("see", new XAttribute("langword", "class")),
        @"[class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/class')");

    [Fact]
    public void WriteWhenLangwordWithValue() => Test(
        new XElement("see", new XAttribute("langword", "class"), "dummy"),
        @"[dummy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/class')");

    [Fact]
    public void WriteWhenLangwordIsAwait() => Test(
        new XElement("see", new XAttribute("langword", "await")),
        @"[await](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/operators/await')");

    [Fact]
    public void WriteWhenLangwordIsTrue() => Test(
        new XElement("see", new XAttribute("langword", "true")),
        @"[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')");

    [Fact]
    public void WriteWhenLangwordIsFalse() => Test(
        new XElement("see", new XAttribute("langword", "false")),
        @"[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')");
}
