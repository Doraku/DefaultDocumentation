using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class OperatorDocItem : DocItem, IParameterizedDocItem
    {
        public IMethod Method { get; }

        public ParameterDocItem[] Parameters { get; }

        public OperatorDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Parent.Name}{Name} Operator");

            writer.Write(Documentation.GetSummary(), this, items);

            // code

            // attributes

            if (Parameters.Length > 0)
            {
                writer.WriteLine("#### Parameters");
                foreach (ParameterDocItem item in Parameters)
                {
                    item.WriteDocumentation(writer, items);
                    writer.Break();
                }
            }

            if (Method.ReturnType.Kind != TypeKind.Void)
            {
                writer.WriteLine("#### Returns");
                writer.WriteLine(items.TryGetValue(Method.ReturnType.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : Method.ReturnType.FullName); // dotnetapi link
                writer.Write(Documentation.GetReturns(), this, items);
            }

            writer.WriteExceptions(this, items);

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}
