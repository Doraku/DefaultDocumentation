using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummaryWriterTest : ASectionWriterTest<SummaryWriter>
    {
        [SuppressMessage("Redundancy", "RCS1163:Unused parameter.")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
        private static void Dummy<T>(T param1)
        { }

        [Fact]
        public void Name_should_be_summary() => Check.That(Name).IsEqualTo("summary");

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SummaryWriter).FullName}"), new XElement("doc", new XElement("summary", "test"))),
            "test");

        [Fact]
        public void Write_should_write_when_TypeParameterDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(SummaryWriterTest).FullName}.{nameof(Dummy)}``1(``0)"), new XElement("doc", new XElement("typeparam", new XAttribute("name", "T"), "test"))).TypeParameters.Single(),
            "test");

        [Fact]
        public void Write_should_write_when_ParameterDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(SummaryWriterTest).FullName}.{nameof(Dummy)}``1(``0)"), new XElement("doc", new XElement("param", new XAttribute("name", "param1"), "test"))).Parameters.Single(),
            "test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SummaryWriter).FullName}"), new XElement("doc", new XElement("summary", "test"))),
            w => w.Append("pouet"),
            $"pouet{Environment.NewLine}{Environment.NewLine}test");
    }
}
