using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation
{
    internal sealed class DocumentationWriter : IDisposable
    {
        private static readonly ConcurrentQueue<StringBuilder> _builders = new ConcurrentQueue<StringBuilder>();

        private readonly StringBuilder _builder;
        private readonly IReadOnlyDictionary<string, DocItem> _items;
        private readonly DocItem _mainItem;
        private readonly string _filePath;

        public DocumentationWriter(IReadOnlyDictionary<string, DocItem> items, string folderPath, DocItem item)
        {
            if (!_builders.TryDequeue(out _builder))
            {
                _builder = new StringBuilder(1024);
            }

            _items = items;
            _mainItem = item;
            _filePath = Path.Combine(folderPath, $"{item.Link}.md");
        }

        public static string GetLink(DocItem item, string displayedName = null) => $"[{displayedName ?? item.Name}](./{item.Link}.md '{item.FullName}')";

        public string GetLinkTarget(DocItem item) => $"<a name='{item.Link}'></a>";

        public string GetInnerLink(DocItem item)
        {
            DocItem pagedDocItem = item.GetPagedDocItem();

            return $"[{item.Name}]({(_mainItem == pagedDocItem ? string.Empty : $"./{pagedDocItem.Link}.md")}#{item.Link} '{item.FullName}')";
        }

        public string GetTypeLink(DocItem item, IType type)
        {
            string HandleParameterizedType(ParameterizedType genericType)
            {
                if (_items.TryGetValue(genericType.GetDefinition().GetIdString(), out DocItem docItem) && docItem is TypeDocItem typeDocItem)
                {
                    return GetLink(docItem, typeDocItem.Type.FullName + "&lt;")
                        + string.Join(GetLink(docItem, ","), genericType.TypeArguments.Select(t => GetTypeLink(item, t)))
                        + GetLink(docItem, "&gt;");
                }

                return genericType.GenericType.ReflectionName.AsDotNetApiLink(genericType.FullName + "&lt;")
                    + string.Join(genericType.GenericType.ReflectionName.AsDotNetApiLink(","), genericType.TypeArguments.Select(t => GetTypeLink(item, t)))
                    + genericType.GenericType.ReflectionName.AsDotNetApiLink("&gt;");
            }

            return type.Kind switch
            {
                TypeKind.Array when type is TypeWithElementType arrayType => GetTypeLink(item, arrayType.ElementType) + "System.Array".AsDotNetApiLink("[]"),
                TypeKind.ByReference when type is TypeWithElementType innerType => GetTypeLink(item, innerType.ElementType),
                TypeKind.TypeParameter => item.TryGetTypeParameterDocItem(type.Name, out TypeParameterDocItem typeParameter) ? GetInnerLink(typeParameter) : type.Name,
                _ when type is ParameterizedType genericType => HandleParameterizedType(genericType),
                _ => _items.TryGetValue(type.GetDefinition().GetIdString(), out DocItem typeDocItem) ? GetLink(typeDocItem) : type.FullName.AsDotNetApiLink()
            };
        }

        public string GetLink(string id) => _items.TryGetValue(id, out DocItem reference) ? GetLink(reference) : id.Substring(2).AsDotNetApiLink();

        public void WriteLine(string line) => _builder.AppendLine(line);

        public void Write(string line) => _builder.Append(line);

        public void Break() => _builder.AppendLine();

        public void WriteHeader()
        {
            HomeDocItem home = _items.Values.OfType<HomeDocItem>().Single();
            WriteLine($"#### {GetLink(home)}");

            Stack<DocItem> parents = new Stack<DocItem>();
            for (DocItem parent = _mainItem?.Parent; parent != home && parent != null; parent = parent.Parent)
            {
                parents.Push(parent);
            }

            if (parents.Count > 0)
            {
                WriteLine($"### {string.Join(".", parents.Select(p => GetLink(p)))}");
            }
        }

        public void WritePageTitle(string name, string title) => WriteLine($"## {name} {title}");

        public void WriteChildrenLink<T>(string title)
            where T : DocItem
        {
            bool WriteChildrenLink(DocItem parent, string title)
            {
                bool hasTitle = title is null;
                foreach (DocItem child in _items.Values.Where(i => i.Parent == parent).OrderBy(i => i.Id))
                {
                    if (child is T)
                    {
                        if (!hasTitle)
                        {
                            hasTitle = true;
                            WriteLine($"### {title}");
                        }

                        WriteLine($"- {GetLink(child)}");
                    }

                    hasTitle = WriteChildrenLink(child, hasTitle ? null : title);
                }

                return hasTitle;
            }

            WriteChildrenLink(_mainItem, title);
        }

        public void WriteDocItems(IEnumerable<DocItem> items, string title)
        {
            bool hasTitle = false;
            foreach (DocItem item in items)
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    WriteLine(title);
                }

                item.WriteDocumentation(this, _items);
                WriteLine("  ");
            }
        }

        public void WriteLinkTarget(DocItem item) => WriteLine($"<a name='{item.Link}'></a>");

        public void Write(DocItem item, XElement element) => Write(null, element, item);

        public void Write(string title, XElement element, DocItem item)
        {
            string WriteNodes(IEnumerable<XNode> nodes)
            {
                return string.Concat(nodes.Select(node => node switch
                {
                    XText text => string.Join("  \n", text.Value.Split('\n')),
                    XElement element => element.Name.ToString() switch
                    {
                        "see" => GetLink(element.GetReferenceName()),
                        "seealso" => GetLink(element.GetReferenceName()),
                        "typeparamref" => item.TryGetTypeParameterDocItem(element.GetName(), out TypeParameterDocItem typeParameter) ? GetInnerLink(typeParameter) : element.GetName(),
                        "paramref" => item.TryGetParameterDocItem(element.GetName(), out ParameterDocItem parameter) ? GetInnerLink(parameter) : element.GetName(),
                        "c" => $"`{element.Value}`",
                        "code" => $"```\n{element.Value}\n```\n",
                        "para" => $"\n\n{WriteNodes(element.Nodes())}\n\n",
                        _ => element.ToString()
                    },
                    _ => throw new Exception($"unhandled node type in summary {node.NodeType}")
                }));
            }

            if (element is null)
            {
                return;
            }

            if (title != null)
            {
                WriteLine(title);
            }

            string summary = WriteNodes(element.Nodes());

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

            WriteLine(summary.TrimEnd() + "  ");
        }

        public void WriteExceptions(DocItem item)
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
                    _items.TryGetValue(typeName, out DocItem type)
                    ? GetLink(type)
                    : typeName.Substring(2).AsDotNetApiLink());
                WriteLine("  ");
                Write(item, exception);
            }
        }

        public void Dispose()
        {
            File.WriteAllText(_filePath, _builder.ToString());

            _builder.Clear();
            _builders.Enqueue(_builder);
        }
    }
}
