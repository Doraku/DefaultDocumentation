using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;

namespace DefaultDocumentation
{
    internal sealed class DocumentationWriter : IDisposable
    {
        private static readonly ConcurrentQueue<StringBuilder> _builders = new ConcurrentQueue<StringBuilder>();

        private readonly StringBuilder _builder;
        private readonly DocItem _item;
        private readonly string _filePath;

        private DocumentationWriter(DocItem item, string filePath)
        {
            if (!_builders.TryDequeue(out _builder))
            {
                _builder = new StringBuilder(1024);
            }

            _item = item;
            _filePath = filePath;
        }

        public DocumentationWriter(string path, DocItem item)
            : this(item, Path.Combine(path, $"{item.Link}.md"))
        { }

        public DocumentationWriter(string path, string name)
            : this(default(DocItem), Path.Combine(path, $"{name.Clean()}.md"))
        { }

        public void WriteLine(string line) => _builder.AppendLine(line);

        public void Write(string line) => _builder.Append(line);

        public void Break() => _builder.AppendLine();

        public void Write(string title, XElement element, DocItem item, IReadOnlyDictionary<string, DocItem> items)
        {
            if (element is null)
            {
                return;
            }

            if (title != null)
            {
                WriteLine(title);
            }

            string summary = string.Empty;

            void WriteNodes(IEnumerable<XNode> nodes)
            {
                foreach (XNode node in nodes)
                {
                    switch (node)
                    {
                        case XText text:
                            summary += string.Join("  \n", text.Value.Split('\n'));
                            break;

                        case XElement element:
                            switch (element.Name.LocalName)
                            {
                                case "see":
                                case "seealso":
                                    string referenceName = element.GetReferenceName();
                                    summary +=
                                        items.TryGetValue(referenceName, out DocItem reference)
                                        ? reference.GetLink() // need to handle namespace
                                        : referenceName.Substring(2);//.AsDotNetApiLink();
                                    break;

                                case "typeparamref":
                                    DocItem parent = item;
                                    TypeParameterDocItem typeParameter = null;
                                    while (parent != null && typeParameter == null)
                                    {
                                        if (parent is ITypeParameterizedDocItem typeParameters)
                                        {
                                            typeParameter = Array.Find(typeParameters.TypeParameters, i => i.TypeParameter.Name == element.GetName());
                                        }

                                        parent = parent.Parent;
                                    }

                                    summary += typeParameter?.GetLinkTarget(IsForThis(typeParameter.Parent)) ?? element.GetName();
                                    break;

                                case "paramref":
                                    ParameterDocItem parameter = ((item as IParameterizedDocItem) ?? (item.Parent as IParameterizedDocItem))?.Parameters.FirstOrDefault(i => i.Parameter.Name == element.GetName());

                                    summary += parameter?.GetLinkTarget(IsForThis(parameter.Parent)) ?? element.GetName();
                                    break;

                                case "c":
                                    summary += $"`{element.Value}`";
                                    break;

                                case "code":
                                    summary += $"```{element.Value}```\n";
                                    break;

                                case "para":
                                    summary += "\n\n";
                                    WriteNodes(element.Nodes());
                                    summary += "\n\n";
                                    break;

                                default:
                                    summary += element.ToString();
                                    break;
                            }
                            break;

                        default:
                            throw new Exception($"unhandled node type in summary {node.NodeType}");
                    }
                }
            }

            WriteNodes(element.Nodes());

            string[] lines = summary.Split('\n');
            int startIndex = 0;
            int firstLine = 0;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    startIndex = line.Length - line.TrimStart().Length;
                    break;
                }

                ++firstLine;
            }

            summary = string.Join(Environment.NewLine, lines.Skip(firstLine).Select(l => l.StartsWith(" ") ? l.Substring(startIndex) : l));
            while (summary.EndsWith(Environment.NewLine))
            {
                summary = summary.Substring(0, summary.Length - Environment.NewLine.Length);
            }

            WriteLine(summary.TrimEnd());
        }

        public void Write(XElement element, DocItem item, IReadOnlyDictionary<string, DocItem> items) => Write(null, element, item, items);

        public void WriteHeader(DocItem item, IReadOnlyDictionary<string, DocItem> items)
        {
            HomeDocItem home = items.Values.OfType<HomeDocItem>().Single();
            WriteLine($"#### {home.GetLink()}");

            DocItem parent = item.Parent;
            Stack<DocItem> parents = new Stack<DocItem>();
            while (parent != null)
            {
                parents.Push(parent);
                parent = parent.Parent;
            }
            WriteLine($"### {string.Join(".", parents.Select(i => i.GetLink(i is TypeDocItem)))}");
        }

        public void WriteExceptions(DocItem item, IReadOnlyDictionary<string, DocItem> items)
        {
            bool hasTitle = false;
            foreach (XElement exception in item.Documentation.GetExceptions())
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    WriteLine("#### Exceptions");
                }

                string typeName = exception.GetReferenceName();

                Write(
                    items.TryGetValue(typeName, out DocItem type)
                    ? type.GetLink()
                    : typeName.Substring(2));//.AsDotNetApiLink());
                WriteLine("  ");
                Write(exception, item, items);
                Break();
            }
        }

        public bool IsForThis(DocItem item) => _item == item;

        public void Dispose()
        {
            File.WriteAllText(_filePath, _builder.ToString());

            _builder.Clear();
            _builders.Enqueue(_builder);
        }
    }
}
