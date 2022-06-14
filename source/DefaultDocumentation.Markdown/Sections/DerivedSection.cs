using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write the derived type of <see cref="TypeDocItem"/>.
    /// </summary>
    public sealed class DerivedSection : ISection
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "Derived";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is TypeDocItem typeItem)
            {
                List<TypeDocItem> derived = writer.Context.Items.Values.OfType<TypeDocItem>().Where(i => i.Type.DirectBaseTypes.Select(t => t.GetDefinition() ?? t).Contains(typeItem.Type)).OrderBy(i => i.FullName).ToList();
                if (derived.Count > 0)
                {
                    writer
                        .EnsureLineStartAndAppendLine()
                        .Append("Derived");

                    foreach (TypeDocItem t in derived)
                    {
                        writer
                            .AppendLine("  ")
                            .Append("&#8627; ")
                            .AppendLink(t);
                    }
                }
            }
        }
    }
}
