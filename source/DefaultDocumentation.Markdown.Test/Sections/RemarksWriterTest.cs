using System;
using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksWriterTest : ASectionWriterTest<RemarksWriter>
    {
        [Fact]
        public void Name_should_be_remarks() => Check.That(Name).IsEqualTo("remarks");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(RemarksWriterTest).FullName}"), null),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(RemarksWriterTest).FullName}"), new XElement("doc", new XElement("remarks", "test"))),
            $"### Remarks{Environment.NewLine}test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(RemarksWriterTest).FullName}"), new XElement("doc", new XElement("remarks", "test"))),
            w => w.Append("pouet"),
            $"pouet{Environment.NewLine}{Environment.NewLine}### Remarks{Environment.NewLine}test");
    }
}
