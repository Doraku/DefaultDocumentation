using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ImplementSection : ISectionWriter
    {
        public string Name => "Implement";

        public void Write(IWriter writer)
        {
            IEnumerable<INamedElement> GetImplementation(IMember member)
            {
                string id = member.GetIdString().Substring(member.DeclaringTypeDefinition.GetIdString().Length);

                return member
                    .DeclaringTypeDefinition
                    .GetBaseTypeDefinitions()
                    .Where(t => t.Kind == TypeKind.Interface && t.GetDefinition().Accessibility == Accessibility.Public)
                    .SelectMany(t => t.Members)
                    .Where(e => e.GetIdString().Substring(e.DeclaringTypeDefinition.GetIdString().Length) == id);
            }

            List<INamedElement> implementations = (writer.GetCurrentItem() switch
            {
                TypeDocItem typeItem => typeItem.Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface && t.GetDefinition().Accessibility == Accessibility.Public).OfType<INamedElement>(),
                PropertyDocItem propertyItem => GetImplementation(propertyItem.Property),
                MethodDocItem methodItem => GetImplementation(methodItem.Method),
                ExplicitInterfaceImplementationDocItem explicitItem => explicitItem.Member.ExplicitlyImplementedInterfaceMembers,
                _ => Enumerable.Empty<INamedElement>()
            }).ToList();

            if (implementations.Count > 0)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .Append("Implements ");

                bool firstWritten = false;
                foreach (INamedElement implementation in implementations)
                {
                    if (!firstWritten)
                    {
                        firstWritten = true;
                    }
                    else
                    {
                        writer.Append(", ");
                    }

                    writer.AppendLink(writer.GetCurrentItem(), implementation);
                }
            }
        }
    }
}
