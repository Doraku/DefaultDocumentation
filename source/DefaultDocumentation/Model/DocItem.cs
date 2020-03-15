using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class DocItem
    {
        private static readonly CSharpAmbience FullNameAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.UseFullyQualifiedEntityNames
        };

        private static readonly CSharpAmbience TypeNameAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        private static readonly CSharpAmbience NameAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public DocItem Parent { get; }
        public string Id { get; }
        public XElement Documentation { get; }
        public string FullName { get; }
        public string Name { get; }
        public string Link { get; }

        public virtual bool GeneratePage => true;

        protected DocItem(DocItem parent, string id, string fullName, string name, XElement documentation)
        {
            Parent = parent;
            Id = id;
            Documentation = documentation;
            FullName = fullName.Replace("<", "&lt;").Replace(">", "&gt;").Replace("this ", string.Empty);
            Name = name.Replace("<", "&lt;").Replace(">", "&gt;").Replace("this ", string.Empty);
            Link = FullName.Clean();
        }

        protected DocItem(DocItem parent, IEntity entity, XElement documentation)
            : this(parent, entity.GetIdString(), GetFullName(entity), (entity is ITypeDefinition ? TypeNameAmbience : NameAmbience).ConvertSymbol(entity), documentation)
        { }

        private static string GetFullName(IEntity entity)
        {
            string fullName = FullNameAmbience.ConvertSymbol(entity);

            if (entity.SymbolKind == SymbolKind.Operator)
            {
                int index = fullName.IndexOf(".operator ") + 1;
                if (index <= 0)
                {
                    index = fullName.IndexOf(".implicit operator ") + 1;
                    int offset = 17;
                    if (index <= 0)
                    {
                        index = fullName.IndexOf(".explicit operator ") + 1;
                        offset = 17;
                    }

                    fullName = fullName.Substring(0, index) + entity.Name + fullName.Substring(index + offset);
                }
                else
                {
                    fullName = fullName.Substring(0, index) + entity.Name + fullName.Substring(fullName.IndexOf('('));
                }
            }

            return fullName;
        }

        public abstract void WriteDocumentation(DocumentationWriter writer);
    }
}
