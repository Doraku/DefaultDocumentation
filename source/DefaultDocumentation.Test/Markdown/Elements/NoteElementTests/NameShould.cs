using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.NoteElementTests;

public sealed class NameShould : BaseElementTester<NoteElement>
{
    [Fact]
    public void ReturnNote() => Check.That(Name).IsEqualTo("note");
}
