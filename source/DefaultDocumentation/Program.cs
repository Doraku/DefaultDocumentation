using System;
using System.IO;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            FileInfo assembly = null;
            FileInfo xml = null;
            DirectoryInfo output = null;
            string home = null;

            foreach (string arg in args)
            {
                if (TryGetArgValue(arg, nameof(assembly), out string argValue))
                {
                    assembly = new FileInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(xml), out argValue))
                {
                    xml = new FileInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(output), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    output = new DirectoryInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(home), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    home = argValue;
                }
            }

            if (assembly is null || xml is null)
            {
                PrintHelp();
                return;
            }
            else if (!assembly.Exists)
            {
                Console.WriteLine($"assembly file \"{assembly.FullName}\" not found");
                return;
            }
            else if (!xml.Exists)
            {
                Console.WriteLine($"documentation file \"{xml.FullName}\" not found");
                return;
            }

            output ??= xml.Directory;
            home ??= "index";

            if (output.Exists)
            {
                foreach (FileInfo file in output.GetFiles("*.md"))
                {
                    file.Delete();
                }
            }
            else
            {
                output.Create();
            }

            new DocumentationGenerator(assembly.FullName, xml.FullName, home).WriteDocumentation(output.FullName);

            static bool TryGetArgValue(string arg, string argName, out string value)
            {
                value = null;
                if (arg.StartsWith($"/{argName}:"))
                {
                    value = arg.Substring(argName.Length + 2);
                }

                return value != null;
            }

            void PrintHelp()
            {
                Console.WriteLine("parameters:");
                Console.WriteLine($"\t/{nameof(assembly)}:{{assembly file path}}");
                Console.WriteLine($"\t/{nameof(xml)}:{{xml documentation file path}}");
                Console.WriteLine("optional parameters:");
                Console.WriteLine($"\t/{nameof(output)}:{{DefaultDocumentation output folder}}");
                Console.WriteLine($"\t/{nameof(home)}:{{DefaultDocumentation home page name}}");
            }
        }
    }
}
