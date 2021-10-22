using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefWriterTest : AElementWriterTest<ParamRefWriter>
    {
        [SuppressMessage("Redundancy", "RCS1163:Unused parameter.")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
        private static void Dummy(int param1)
        { }

        private readonly DocItem _item;

        public ParamRefWriterTest()
        {
            _item = new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ParamRefWriterTest).FullName}.{nameof(Dummy)}({typeof(int).FullName})"), null);
        }

        [Fact]
        public void Name_should_be_paramref() => Check.That(Name).IsEqualTo("paramref");

        [Fact]
        public void Write_should_write() => Test(
            _item,
            new XElement("paramref", new XAttribute("name", "param1")),
            $"[param1](DefaultDocumentation_Markdown_Elements_ParamRefWriterTest_Dummy(int).md#DefaultDocumentation_Markdown_Elements_ParamRefWriterTest_Dummy(int)_param1 '{_item.FullName}.param1')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("paramref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
