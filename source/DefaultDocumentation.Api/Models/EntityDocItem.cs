using System;
using System.Xml.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models
{
    public abstract class EntityDocItem : DocItem
    {
        public static readonly CSharpAmbience FullNameAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.UseFullyQualifiedEntityNames
        };

        public static readonly CSharpAmbience NameAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
        };

        public IEntity Entity { get; }

        private protected EntityDocItem(DocItem parent, IEntity entity, XElement documentation)
            : base(parent, entity.GetIdString(), GetFullName(entity), NameAmbience.ConvertSymbol(entity), documentation)
        {
            Entity = entity;
        }

        private static string GetFullName(IEntity entity)
        {
            string fullName = FullNameAmbience.ConvertSymbol(entity);

            if (entity.SymbolKind == SymbolKind.Operator)
            {
                int offset = 17;
                int index = fullName.IndexOf("implicit operator ", StringComparison.Ordinal);
                if (index < 0)
                {
                    index = fullName.IndexOf("explicit operator ", StringComparison.Ordinal);

                    if (index < 0)
                    {
                        index = fullName.IndexOf("operator ", StringComparison.Ordinal);
                        offset = fullName.IndexOf('(') - index;
                    }
                }

                if (index >= 0)
                {
                    fullName = fullName.Substring(0, index) + entity.Name + fullName.Substring(index + offset);
                }
            }

            return fullName;
        }
    }
}
