using System.Text;
using System.Xml.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldDocItem : DocItem, IDefinedDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new()
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

        public void WriteDefinition(StringBuilder builder) => builder.Append(CodeAmbience.ConvertSymbol(Field)).Append(Field.IsConst ? $" = {Field.GetConstantValue()}" : string.Empty).AppendLine(";");
    }
}
