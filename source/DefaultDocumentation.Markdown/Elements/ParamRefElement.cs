using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefElement : IElement
    {
        public string Name => "paramref";

        public void Write(IWriter writer, XElement element)
        {
            string? name = element.GetNameAttribute();

            if (name != null)
            {
                _ = writer.GetCurrentItem().TryGetParameterDocItem(name, out ParameterDocItem? parameter) ? writer.AppendLink(parameter) : writer.Append(name);
            }
        }
    }
}
