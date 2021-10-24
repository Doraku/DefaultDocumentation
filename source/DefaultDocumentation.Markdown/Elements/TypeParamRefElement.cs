using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElement : IElementWriter
    {
        public string Name => "typeparamref";

        public void Write(IWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.GetCurrentItem().TryGetTypeParameterDocItem(name, out TypeParameterDocItem typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(name);
        }
    }
}
