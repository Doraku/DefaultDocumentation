using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ClassesSectionTests;

public sealed class NameShould : BaseSectionTester<ClassesSection>
{
    [Fact]
    public void ReturnClasses() => Check.That(Name).IsEqualTo("Classes");
}
