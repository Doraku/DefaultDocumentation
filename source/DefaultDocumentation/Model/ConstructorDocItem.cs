using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorDocItem : DocItem, IParameterizedDocItem
    {
        public IMethod Method { get; }
        public ParameterDocItem[] Parameters { get; }

        public ConstructorDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Name} Constructor");

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

            writer.WriteExceptions(this, items);

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}
