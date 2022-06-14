using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write the types inherited by the <see cref="TypeDocItem"/>.
    /// </summary>
    public sealed class InheritanceSection : ISection
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "Inheritance";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is TypeDocItem typeItem && typeItem.Type.Kind == TypeKind.Class)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .Append("Inheritance ");

                foreach (IType t in typeItem.Type.GetNonInterfaceBaseTypes().Where(t => t != typeItem.Type))
                {
                    writer
                        .AppendLink(typeItem, t)
                        .Append(" &#129106; ");
                }

                writer.Append(typeItem.Name);
            }
        }
    }
}
