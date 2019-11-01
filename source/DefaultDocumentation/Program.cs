using System;
using System.IO;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("parameters:");
            Console.WriteLine("\t/assembly:{assembly file path}");
            Console.WriteLine("\t/xml:{xml documentation file path}");
            Console.WriteLine("\t/output:{DefaultDocumentation output folder}");
        }

        private static void Main(string[] args)
        {
            FileInfo assembly = null;
            FileInfo documentation = null;
            DirectoryInfo directory = null;

            foreach (string arg in args)
            {
                if (arg.StartsWith("/assembly:"))
                {
                    assembly = new FileInfo(arg.Substring(10));
                }
                else if (arg.StartsWith("/xml:"))
                {
                    documentation = new FileInfo(arg.Substring(5));
                }
                else if (arg.StartsWith("/output:") && !string.IsNullOrWhiteSpace(arg.Substring(8)))
                {
                    directory = new DirectoryInfo(arg.Substring(8));
                }
            }

            if (assembly is null || documentation is null)
            {
                PrintHelp();
                return;
            }
            else if (!assembly.Exists)
            {
                Console.WriteLine($"assembly file \"{assembly.FullName}\" not found");
                return;
            }
            else if (!documentation.Exists)
            {
                Console.WriteLine($"documentation file \"{documentation.FullName}\" not found");
                return;
            }

            directory ??= documentation.Directory;

            if (directory.Exists)
            {
                foreach (FileInfo file in directory.GetFiles("*.md"))
                {
                    file.Delete();
                }
            }
            else
            {
                directory.Create();
            }

            new DocumentationGenerator(assembly.FullName, documentation.FullName).WriteDocumentation(directory.FullName);
        }
    }
}
