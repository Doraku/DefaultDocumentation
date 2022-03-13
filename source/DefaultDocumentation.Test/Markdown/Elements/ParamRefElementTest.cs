using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefElementTest : AElementTest<ParamRefElement>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() => AssemblyInfo.MethodWithParameterDocItem.Parameters.AsEnumerable<DocItem>().ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_paramref() => Check.That(Name).IsEqualTo("paramref");

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
            new XElement("paramref", new XAttribute("name", "parameter")),
            "[parameter](M:DefaultDocumentation.AssemblyInfo.MethodWithParameter(System.Int32).parameter 'DefaultDocumentation.AssemblyInfo.MethodWithParameter(int).parameter')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("paramref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
