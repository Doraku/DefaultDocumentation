﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldDocItem : DocItem
    {
        public IField Field { get; }

        public FieldDocItem(TypeDocItem parent, IField field, XElement documentation)
            : base(parent, field, documentation)
        {
            Field = field;
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Parent.Name}{Name} Field");

            writer.Write(Documentation.GetSummary(), this, items);

            // code
            // attributes

            writer.WriteLine("#### Field Value");
            IType itype = Field.Type.RemoveReference();
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

                writer.WriteLine(typeParameter.GetLinkTarget(writer.IsForThis(typeParameter.Parent)));
            }
            else
            {
                writer.WriteLine(items.TryGetValue(itype.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : itype.FullName); // dotnetapi link
            }

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}