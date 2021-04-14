using System.Xml.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class DocItem
    {
        private static readonly CSharpAmbience FullNameAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.UseFullyQualifiedEntityNames
        };

        private static readonly CSharpAmbience NameAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
        };

        public DocItem Parent { get; }

        public string Id { get; }

        public XElement Documentation { get; }

        public string FullName { get; }

        public string LongName { get; }

        public string Name { get; }

        protected DocItem(DocItem parent, string id, string fullName, string name, XElement documentation)
        {
            Parent = parent;
            Id = id;
            Documentation = documentation;
            FullName = fullName.Replace("<", "&lt;").Replace(">", "&gt;").Replace("this ", string.Empty);
            Name = name.Replace("<", "&lt;").Replace(">", "&gt;").Replace("this ", string.Empty);
            LongName = (parent != null && parent is not AssemblyDocItem && parent is not NamespaceDocItem ? $"{parent.LongName}." : string.Empty) + Name;
        }

        protected DocItem(DocItem parent, IEntity entity, XElement documentation)
            : this(parent, entity.GetIdString(), GetFullName(entity), NameAmbience.ConvertSymbol(entity), documentation)
        { }

        private static string GetFullName(IEntity entity)
        {
            string fullName = FullNameAmbience.ConvertSymbol(entity);

            if (entity.SymbolKind == SymbolKind.Operator)
            {
                int offset = 17;
                int index = fullName.IndexOf("implicit operator ");
                if (index < 0)
                {
                    index = fullName.IndexOf("explicit operator ");

                    if (index < 0)
                    {
                        index = fullName.IndexOf("operator ");
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
