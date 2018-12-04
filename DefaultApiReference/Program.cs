using System.IO;
using System.Xml.Linq;

namespace DefaultApiReference
{
    internal static class Program
    {
        private static void Main()
        {
            foreach (FileInfo file in new DirectoryInfo(@"D:\Projects\DefaultEcs.wiki").GetFiles("*.md"))
            {
                file.Delete();
            }

            Converter.Convert(
                XDocument.Parse(File.ReadAllText(@"D:\Projects\DefaultEcs\documentation\DefaultEcs.xml")),
                @"D:\Projects\DefaultEcs.wiki");
        }
    }
}
