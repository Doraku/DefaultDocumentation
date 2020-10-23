using System;
using System.Collections.Generic;
using System.IO;
using DefaultDocumentation.Helper;

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
            FileNameMode fileNameMode = FileNameMode.FullName;
            NestedTypeVisibility nestedTypeVisibility = NestedTypeVisibility.Namespace;
            string invalidCharReplacement = null;
            string baseLink = null;
            FileInfo linksFile = null;
            string externalLinks = null;
            bool wikiLinks = false;

            try
            {
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
                    else if (TryGetArgValue(arg, nameof(fileNameMode), out argValue))
                    {
                        fileNameMode = (FileNameMode)Enum.Parse(typeof(FileNameMode), argValue);
                    }
                    else if (TryGetArgValue(arg, nameof(nestedTypeVisibility), out argValue))
                    {
                        nestedTypeVisibility = (NestedTypeVisibility)Enum.Parse(typeof(NestedTypeVisibility), argValue);
                    }
                    else if (TryGetArgValue(arg, nameof(invalidCharReplacement), out argValue))
                    {
                        invalidCharReplacement = argValue;
                    }
                    else if (TryGetArgValue(arg, nameof(baseLink), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                    {
                        baseLink = argValue;
                    }
                    else if (TryGetArgValue(arg, nameof(linksFile), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                    {
                        linksFile = new FileInfo(argValue);
                    }
                    else if (TryGetArgValue(arg, nameof(externalLinks), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                    {
                        externalLinks = argValue;
                    }
                    else if (TryGetArgValue(arg, nameof(wikiLinks), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                    {
                        wikiLinks = bool.Parse(argValue);
                    }
                }
            }
            catch
            {
                PrintHelp();
                throw;
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

            if (output.Exists)
            {
                foreach (FileInfo file in output.GetFiles("*.md"))
                {
                    if (string.Equals(file.Name, "readme.md", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    int i = 3;
                start:
                    try
                    {
                        file.Delete();
                        continue;
                    }
                    catch
                    {
                        if (--i > 0)
                        {
                            goto start;
                        }

                        throw;
                    }
                }
            }
            else
            {
                output.Create();
            }

            if (!string.IsNullOrEmpty(invalidCharReplacement))
            {
                StringExtension.ChangeInvalidReplacement(invalidCharReplacement);
            }

            DocumentationGenerator generator = new DocumentationGenerator(assembly.FullName, xml.FullName, home, fileNameMode, nestedTypeVisibility, wikiLinks, externalLinks);

            generator.WriteDocumentation(output.FullName);

            if (linksFile != null)
            {
                if (linksFile.Exists)
                {
                    linksFile.Delete();
                }

                generator.WriteLinks(baseLink, linksFile.FullName, wikiLinks);
            }

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
                Console.WriteLine($"\t/{nameof(fileNameMode)}:{{{string.Join(" | ", (IEnumerable<FileNameMode>)Enum.GetValues(typeof(FileNameMode)))}}}");
                Console.WriteLine($"\t/{nameof(nestedTypeVisibility)}:{{{string.Join(" | ", (IEnumerable<NestedTypeVisibility>)Enum.GetValues(typeof(NestedTypeVisibility)))}}}");
                Console.WriteLine($"\t/{nameof(invalidCharReplacement)}:{{the string used to replace invalid char for file names}}");
                Console.WriteLine($"\t/{nameof(baseLink)}:{{base link path used if generating a links file}}");
                Console.WriteLine($"\t/{nameof(linksFile)}:{{links file path}}");
                Console.WriteLine($"\t/{nameof(externalLinks)}:{{links files for element outside of this assembly, separated by '|'}}");
                Console.WriteLine($"\t/{nameof(wikiLinks)}:{{uses github wiki link format (no relativity or file type suffix}}");
            }
        }
    }
}
