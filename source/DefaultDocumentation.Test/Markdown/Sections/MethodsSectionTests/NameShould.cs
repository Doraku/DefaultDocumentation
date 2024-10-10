using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.MethodsSectionTests;

public sealed class NameShould : BaseSectionTester<MethodsSection>
{
    [Fact]
    public void ReturnMethods() => Check.That(Name).IsEqualTo("Methods");
}
