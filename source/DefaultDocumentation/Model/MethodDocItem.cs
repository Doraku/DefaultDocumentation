using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class MethodDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        public IMethod Method { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        public ParameterDocItem[] Parameters { get; }

        public MethodDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Parent.Name}{Name} Method");

            writer.Write(Documentation.GetSummary(), this, items);

            // code

            // attributes

            if (TypeParameters.Length > 0)
            {
                writer.WriteLine("#### Type parameters");
                foreach (TypeParameterDocItem item in TypeParameters)
                {
                    item.WriteDocumentation(writer, items);
                    writer.Break();
                }
            }

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
                IType itype = Method.ReturnType.RemoveReference();
                if (itype.Kind == TypeKind.TypeParameter)
                {
                    DocItem parent = Parent;
                    TypeParameterDocItem typeParameter = null;
                    while (parent != null && typeParameter == null)
                    {
                        if (parent is ITypeParameterizedDocItem typeParameters)
                        {
                            typeParameter = Array.Find(typeParameters.TypeParameters, i => i.TypeParameter.Name == itype.Name);
                        }

                        parent = parent.Parent;
                    }

                    writer.WriteLine(typeParameter?.GetLinkTarget(writer.IsForThis(typeParameter.Parent)) ?? itype.Name);
                }
                else
                {
                    writer.WriteLine(items.TryGetValue(itype.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : itype.FullName); // dotnetapi link
                }
                writer.Write(Documentation.GetReturns(), this, items);
            }

            writer.WriteExceptions(this, items);

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}
