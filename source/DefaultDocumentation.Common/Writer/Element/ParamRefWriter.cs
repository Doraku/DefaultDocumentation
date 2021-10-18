using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Writer.Element
{
    internal sealed class ParamRefWriter : ElementWriter
    {
        public ParamRefWriter()
            : base("paramref")
        { }

        public override void Write(PageWriter writer, XElement element)
        {
            string name = element.GetNameAttribute();

            _ = writer.CurrentItem.TryGetParameterDocItem(name, out ParameterDocItem parameter) ? writer.AppendLink(parameter) : writer.Append(name);
        }
    }
}
