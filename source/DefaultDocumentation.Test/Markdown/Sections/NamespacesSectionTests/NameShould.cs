using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.NamespacesSectionTests;

public sealed class NameShould : BaseSectionTester<NamespacesSection>
{
    [Fact]
    public void ReturnNamespaces() => Check.That(Name).IsEqualTo("Namespaces");
}
