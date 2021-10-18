using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Writer.Element
{
    internal sealed class TypeParamRefWriter : ElementWriter
    {
        public TypeParamRefWriter()
            : base("typeparamref")
        { }

        public override void Write(PageWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.CurrentItem.TryGetTypeParameterDocItem(name, out TypeParameterDocItem typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(name);
        }
    }
}
