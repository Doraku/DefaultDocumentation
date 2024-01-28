using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    /// <summary>
    /// <see cref="Api.IFileNameFactory"/> implementation using <see cref="DocItem.Name"/> as file name.
    /// </summary>
    public sealed class NameFactory : BaseMarkdownFileNameFactory
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "Name";

        /// <inheritdoc/>
        public override string Name => ConfigName;

        /// <inheritdoc/>
        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item) => item.GetLongName();
    }
}
