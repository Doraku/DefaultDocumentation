using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElement : IElement
    {
        public string Name => "typeparamref";

        public void Write(IWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.GetCurrentItem().TryGetTypeParameterDocItem(name, out TypeParameterDocItem typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(name);
        }
    }
}
