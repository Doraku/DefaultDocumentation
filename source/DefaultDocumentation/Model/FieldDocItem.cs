using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldDocItem : DocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
        };

        public IField Field { get; }

        public FieldDocItem(TypeDocItem parent, IField field, XElement documentation)
            : base(parent, field, documentation)
        {
            Field = field;
        }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle($"{Parent.Name}.{Name}", "Field");

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```csharp");
            writer.WriteLine($"{CodeAmbience.ConvertSymbol(Field)}{(Field.IsConst ? $" = {Field.GetConstantValue()}" : string.Empty)};");
            writer.WriteLine("```");
            // todo attributes

            writer.WriteLine("#### Field Value");
            writer.WriteLine($"{writer.GetTypeLink(Field.Type)}  ");

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
