using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.CodeElementTests;

public sealed class NameShould : BaseElementTester<CodeElement>
{
    [Fact]
    public void ReturnCode()
    {
        Check.That(Name).IsEqualTo("code");
    }
}
