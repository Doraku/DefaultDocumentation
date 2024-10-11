using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ParamRefElementTests;

public sealed class WriteShould : BaseElementTester<ParamRefElement>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => AssemblyInfo.MethodWithParameterDocItem.Parameters.AsEnumerable<DocItem>().ToDictionary(item => item.Id);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.MethodWithParameterDocItem,
        new XElement("paramref", new XAttribute("name", "parameter")),
        "[parameter](M:DefaultDocumentation.AssemblyInfo.MethodWithParameter(System.Int32).parameter 'DefaultDocumentation.AssemblyInfo.MethodWithParameter(int).parameter')");

    [Fact]
    public void WriteNameWhenNotFound() => Test(
        new XElement("paramref", new XAttribute("name", "unknown")),
        "unknown");
}
