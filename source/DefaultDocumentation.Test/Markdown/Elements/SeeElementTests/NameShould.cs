using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.SeeElementTests;

public sealed class NameShould : BaseElementTester<SeeElement>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[] { AssemblyInfo.NamespaceDocItem }.ToDictionary(item => item.Id);

    [Fact]
    public void ReturnSee() => Check.That(Name).IsEqualTo("see");
}
