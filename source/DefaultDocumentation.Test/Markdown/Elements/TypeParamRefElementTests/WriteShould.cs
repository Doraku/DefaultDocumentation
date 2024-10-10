using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.TypeParamRefElementTests;

public sealed class WriteShould : BaseElementTester<TypeParamRefElement>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters.AsEnumerable<DocItem>().ToDictionary(i => i.Id);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.ClassWithTypeParameterDocItem,
        new XElement("typeparamref", new XAttribute("name", "T")),
        "[T](T:DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter`1.T 'DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter<T>.T')");

    [Fact]
    public void WriteNameWhenNotFound() => Test(
        new XElement("typeparamref", new XAttribute("name", "unknown")),
        "unknown");
}
