using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    /// <summary>
    /// <see cref="Api.IFileNameFactory"/> implementation using <see cref="DocItem.Name"/> and an md5 on the <see cref="DocItem.FullName"/> as file name.
    /// </summary>
    public sealed class NameAndMd5MixFactory : AMarkdownFactory
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "NameAndMd5Mix";

        /// <inheritdoc/>
        public override string Name => ConfigName;

        /// <inheritdoc/>
        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
        {
            using MD5 md5 = MD5.Create();

            return item is EntityDocItem entity && item is IParameterizedDocItem parameterized && parameterized.Parameters.Any()
                ? $"{item.Parent!.GetLongName()}.{entity.Entity.Name}.{Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(item.FullName)))}"
                : item.GetLongName();
        }
    }
}
