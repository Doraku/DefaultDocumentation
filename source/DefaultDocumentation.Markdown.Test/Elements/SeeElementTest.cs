using System.Collections.Generic;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class SeeElementTest : AElementTest<SeeElement>
    {
        private readonly DocItem _item;

        public SeeElementTest()
        {
            _item = new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SeeElementTest).FullName}"), null);
        }

        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>
        {
            [_item.Id] = _item
        };

        [Fact]
        public void Name_should_be_see() => Check.That(Name).IsEqualTo("see");

        [Fact]
        public void Write_should_write_When_cref() => Test(
            _item,
            new XElement("see", new XAttribute("cref", _item.Id)),
            $"[{_item.Name}](DefaultDocumentation_Markdown_Elements_SeeElementTest.md '{_item.FullName}')");

        [Fact]
        public void Write_should_write_When_cref_with_value() => Test(
            _item,
            new XElement("see", new XAttribute("cref", _item.Id), "dummy"),
            $"[dummy](DefaultDocumentation_Markdown_Elements_SeeElementTest.md '{_item.FullName}')");
        [Fact]
        public void Write_should_write_When_not_assembly_id() => Test(
            _item,
            new XElement("see", new XAttribute("cref", "T:System.Int32")),
            "[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_href() => Test(
            new XElement("see", new XAttribute("href", "dummyurl")),
            "[dummyurl](dummyurl 'dummyurl')");

        [Fact]
        public void Write_should_write_When_href_with_value() => Test(
            new XElement("see", new XAttribute("href", "dummyurl"), "dummy"),
            "[dummy](dummyurl 'dummyurl')");

        [Fact]
        public void Write_should_write_When_langword() => Test(
            new XElement("see", new XAttribute("langword", "class")),
            "[class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class')");

        [Fact]
        public void Write_should_write_When_langword_with_value() => Test(
            new XElement("see", new XAttribute("langword", "class"), "dummy"),
            "[dummy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class')");

        [Fact]
        public void Write_should_write_When_langword_is_await() => Test(
            new XElement("see", new XAttribute("langword", "await")),
            "[await](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await')");

        [Fact]
        public void Write_should_write_When_langword_is_true() => Test(
            new XElement("see", new XAttribute("langword", "true")),
            "[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool')");

        [Fact]
        public void Write_should_write_When_langword_is_false() => Test(
            new XElement("see", new XAttribute("langword", "false")),
            "[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool')");
    }
}
