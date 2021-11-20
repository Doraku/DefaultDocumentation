using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class NameAndMd5MixFactory : AMarkdownFactory
    {
        public override string Name => "NameAndMd5Mix";

        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
        {
            using MD5 md5 = MD5.Create();

            return item is EntityDocItem entity && item is IParameterizedDocItem parameterized && parameterized.Parameters.Any()
                ? $"{item.Parent.GetLongName()}.{entity.Entity.Name}.{Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(item.FullName)))}"
                : item.GetLongName();
        }
    }
}
