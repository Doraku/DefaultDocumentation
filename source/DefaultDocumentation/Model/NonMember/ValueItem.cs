using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using Mono.Cecil;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ValueItem : AItem
    {
        public override string Header => "Value";

        public TypeReference Type { get; }

        public ValueItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            Type = (parent as PropertyItem).Property.PropertyType;
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"### {Header}");
            string valueTypeName = Type.FullName.Replace('/', '.');
            converter.Items.TryGetValue($"{TypeItem.Id}{valueTypeName}", out AMemberItem valueTypeItem);
            writer.WriteLine(valueTypeItem?.AsLink() ?? valueTypeName.AsDotNetApiLink());

            converter.WriteSummary(writer, this);
        }
    }
}
