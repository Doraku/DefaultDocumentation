using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefaultSectionTest : ASectionTest<DefaultSection>
    {
        [Fact]
        public void Name_should_be_Default() => Check.That(Name).IsEqualTo("Default");

        [Fact]
        public void Write_should_write() => Test("<a name='test'></a>");
    }
}
