using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElement : IElement
    {
        public string Name => "typeparamref";

        public void Write(IWriter writer, XElement element)
        {
            string? name = element.GetNameAttribute();

            if (name != null)
            {
                _ = writer.GetCurrentItem().TryGetTypeParameterDocItem(name, out TypeParameterDocItem? typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(name);
            }
        }
    }
}
