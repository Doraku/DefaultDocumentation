using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ParameterDocItem : DocItem
    {
        public IParameter Parameter { get; }

        public ParameterDocItem(DocItem parent, IParameter entity, XElement documentation)
            : base(parent, entity.Name, documentation.GetParameters()?.FirstOrDefault(d => d.GetName() == entity.Name))
        {
            Parameter = entity;
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteLine(GetLinkTarget());
            IType itype = Parameter.Type.RemoveReference();
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
                
                writer.WriteLine($"`{Parameter.Name}` {typeParameter.GetLinkTarget(writer.IsForThis(typeParameter.Parent))}  ");
            }
            else
            {
                writer.WriteLine($"`{Parameter.Name}` {(items.TryGetValue(itype.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : itype.FullName)}  ");// dotnetapi link
            }
            writer.Write(Documentation, this, items);
        }
    }
}
