using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefElement : IElement
    {
        public string Name => "paramref";

        public void Write(IWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.GetCurrentItem().TryGetParameterDocItem(name, out ParameterDocItem parameter) ? writer.AppendLink(parameter) : writer.Append(name);
        }
    }
}
