using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DefaultApiReference
{
    internal static class StringBuilderExtension
    {
        public static void FlushTo(this StringBuilder builder, string path, string name)
        {
            File.WriteAllText(Path.Combine(path, $"{name.CleanForLink()}.md"), builder.ToString());
            builder.Clear();
        }
    }
}
