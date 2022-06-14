using System;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    /// <summary>
    /// <see cref="Api.IFileNameFactory"/> implementation using an md5 on the <see cref="DocItem.FullName"/> as file name.
    /// </summary>
    public sealed class Md5Factory : AMarkdownFactory
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "Md5";

        /// <inheritdoc/>
        public override string Name => ConfigName;

        /// <inheritdoc/>
        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
        {
            using MD5 md5 = MD5.Create();

            return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(item.FullName))).Replace('\\', '?').Replace('/', '?');
        }
    }
}
