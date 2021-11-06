using System.Xml.Linq;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefElementTest : AElementTest<ParamRefElement>
    {
        [Fact]
        public void Name_should_be_paramref() => Check.That(Name).IsEqualTo("paramref");

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
            new XElement("paramref", new XAttribute("name", "parameter")),
            "[parameter](parameter 'DefaultDocumentation.Markdown.AssemblyInfo.MethodWithParameter(int).parameter')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("paramref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
