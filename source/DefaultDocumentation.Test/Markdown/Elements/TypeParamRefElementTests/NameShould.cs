using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.TypeParamRefElementTests;

public sealed class NameShould : BaseElementTester<TypeParamRefElement>
{
    [Fact]
    public void ReturnTypeparamref() => Check.That(Name).IsEqualTo("typeparamref");
}
