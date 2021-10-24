using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefElement : IElementWriter
    {
        public string Name => "paramref";

        public void Write(IWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.GetCurrentItem().TryGetParameterDocItem(name, out ParameterDocItem parameter) ? writer.AppendLink(parameter) : writer.Append(name);
        }
    }
}
