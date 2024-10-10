using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExceptionSectionTests;

public sealed class NameShould : BaseSectionTester<ExceptionSection>
{
    [Fact]
    public void ReturnException() => Check.That(Name).IsEqualTo("exception");
}
