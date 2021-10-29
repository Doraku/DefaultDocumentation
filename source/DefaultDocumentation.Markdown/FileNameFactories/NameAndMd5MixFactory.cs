using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class NameAndMd5MixFactory : AMarkdownFactory
    {
        public override string Name => "NameAndMd5Mix";

        protected override string GetMarkdownFileName(DocumentationContext context, DocItem item)
        {
            using MD5 md5 = MD5.Create();

            return item is not IParameterizedDocItem parameterizedItem || !parameterizedItem.Parameters.Any()
                ? item.LongName
                : (item.Parent.LongName + '.' + item.Entity.Name + '.' + Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(item.FullName))));
        }
    }
}
