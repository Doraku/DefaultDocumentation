using System;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class Md5Factory : AMarkdownFactory
    {
        public override string Name => "Md5";

        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
        {
            using MD5 md5 = MD5.Create();

            return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(item.FullName)));
        }
    }
}
