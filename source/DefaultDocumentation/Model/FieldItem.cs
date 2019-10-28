using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldItem : AMemberItem
    {
        public const string Id = "F:";

        public override string Header => "Fields";
        public override string Title => "field";

        public FieldDefinition Field { get; }

        public FieldItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            TypeDefinition parentType = (parent as TypeItem).Type;

            Field = parentType.Fields.First(f => f.Name == Name);
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            TypeReference fieldType = Field.FieldType;
            string fieldTypeName = fieldType.FullName.Replace('/', '.');
            converter.Items.TryGetValue($"{TypeItem.Id}{fieldTypeName}", out AMemberItem parentTypeItem);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Field.IsStatic)
            {
                writer.Write("static ");
            }
            if (Field.IsInitOnly)
            {
                writer.Write("readonly ");
            }
            writer.WriteLine($"{parentTypeItem?.FullName ?? fieldTypeName} {Name};");
            writer.WriteLine("```");

            writer.WriteLine("#### Field Value");
            writer.WriteLine(parentTypeItem?.AsLink() ?? fieldTypeName.AsDotNetApiLink());

            base.Write(converter, writer);
        }
    }
}
