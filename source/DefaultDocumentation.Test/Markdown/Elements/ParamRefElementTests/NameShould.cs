using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ParamRefElementTests;

public sealed class NameShould : BaseElementTester<ParamRefElement>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => AssemblyInfo.MethodWithParameterDocItem.Parameters.AsEnumerable<DocItem>().ToDictionary(item => item.Id);

    [Fact]
    public void ReturnParamref() => Check.That(Name).IsEqualTo("paramref");
}
