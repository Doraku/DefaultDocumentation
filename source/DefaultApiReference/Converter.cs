using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultApiReference.Model;

namespace DefaultApiReference
{
    internal class Converter
    {
        private readonly StringBuilder _markdown;
        private readonly Dictionary<string, ADocItem> _items;
        private readonly string _outputPath;

        private Converter(XDocument document, string outputPath)
        {
            _markdown = new StringBuilder();
            _items = Parse(document);
            _outputPath = outputPath;
        }

        private static Dictionary<string, ADocItem> Parse(XDocument document)
        {
            Dictionary<string, ADocItem> items = new Dictionary<string, ADocItem>();

            foreach (XElement element in document.GetMembers().Where(e => e.GetFullName().StartsWith(TypeItem.Id)))
            {
                items.Add(element.GetFullName(), new TypeItem(element));
            }

            foreach (XElement element in document.GetMembers().Where(e => !e.GetFullName().StartsWith(TypeItem.Id)))
            {
                ADocItem parent = items[$"{TypeItem.Id}{element.GetNamespace()}"];
                ADocItem newItem;

                string fullName = element.GetFullName();
                if (fullName.StartsWith(FieldItem.Id))
                {
                    newItem = new FieldItem(parent, element);
                }
                else if (fullName.StartsWith(PropertyItem.Id))
                {
                    newItem = new PropertyItem(parent, element);
                }
                else if (fullName.StartsWith(MethodItem.Id))
                {
                    newItem = new MethodItem(parent, element);
                    if (newItem.Name.StartsWith('#'))
                    {
                        newItem = new ConstructorItem(newItem as MethodItem, element);
                    }
                }
                else
                {
                    throw new Exception($"unhandled doc item {fullName}");
                }

                items.Add(fullName, newItem);
            }

            return items;
        }

        private void WriteGenerics(AGenericDocItem item)
        {
            if (item?.Generics.Length > 0)
            {
                _markdown.AppendLine("### Type parameters");

                foreach (GenericItem generic in item.Generics)
                {
                    _markdown.AppendLine();
                    _markdown.AppendLine(generic.FullName().AsLinkTarget());
                    _markdown.AppendLine($"`{generic.Name}`");
                    _markdown.AppendLine();
                    _markdown.AppendLine($"{WriteSummary(generic)}");
                }
            }
        }

        private void WriteParameters(IParameterDocItem item)
        {
            if (item?.Parameters.Length > 0)
            {
                _markdown.AppendLine("### Parameters");

                foreach (ParameterItem parameter in item.Parameters)
                {
                    _markdown.AppendLine();
                    _markdown.AppendLine(parameter.FullName().AsLinkTarget());
                    _markdown.AppendLine($"`{parameter.Name}`");
                    _markdown.AppendLine();
                    _markdown.AppendLine($"{WriteSummary(parameter)}");
                }
            }
        }

        private void WriteExceptions(ADocItem item)
        {
            if (item.Exceptions.Length > 0)
            {
                _markdown.AppendLine("### Exceptions");

                foreach (ExceptionItem exception in item.Exceptions)
                {
                    _markdown.AppendLine();
                    _markdown.AppendLine(
                        _items.TryGetValue(exception.Reference, out ADocItem reference)
                        ? reference.FullName().AsLink()
                        : exception.Reference.Substring(2).AsDotNetApiLink());
                    _markdown.AppendLine();
                    _markdown.AppendLine(WriteSummary(exception));
                }
            }
        }

        private void WriteReturns(MethodItem item)
        {
            if (item?.Return != null)
            {
                _markdown.AppendLine("### Returns");
                _markdown.AppendLine(WriteSummary(item.Return));
            }
        }

        private string WriteSummary(ADocItem item)
        {
            string summary = string.Empty;

            foreach (XNode node in item.Summary.Nodes())
            {
                switch (node)
                {
                    case XText text:
                        summary += text.Value;
                        break;

                    case XElement element:
                        switch (element.Name.LocalName)
                        {
                            case "see":
                                string referenceName = element.GetReferenceName();
                                if (_items.TryGetValue(referenceName, out ADocItem reference))
                                {
                                    summary += reference.FullName().AsLink();
                                }
                                else
                                {
                                    summary += referenceName.Substring(2).AsDotNetApiLink();
                                }
                                break;

                            case "typeparamref":
                                ADocItem parent = item;
                                GenericItem generic = null;
                                while (parent != null && generic == null)
                                {
                                    if (parent is AGenericDocItem genericItem)
                                    {
                                        generic = genericItem.Generics.FirstOrDefault(i => i.Name == element.GetName());
                                    }

                                    parent = parent.Parent;
                                }

                                if (generic == null)
                                {
                                    throw new Exception($"unknown generic type {element.GetName()}");
                                }

                                summary += generic.FullName().AsPageLink(generic.Name);
                                break;

                            case "paramref":
                                IParameterDocItem parameterItem = (item as IParameterDocItem) ?? (item.Parent as IParameterDocItem);
                                ParameterItem parameter = parameterItem.Parameters.First(i => i.Name == element.GetName());

                                summary += parameter.FullName().AsPageLink(parameter.Name);
                                break;

                            default:
                                throw new Exception($"unhandled element in summary {element.Name.LocalName}");
                        }
                        break;

                    default:
                        throw new Exception($"unhandled node type in summary {node.NodeType}");
                }
            }

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

            summary = string.Join("<br/>", lines.Skip(firstLine).Select(l => l.Substring(startIndex)));
            while (summary.EndsWith("<br/>"))
            {
                summary = summary.Substring(0, summary.Length - 5);
            }

            return summary;
        }

        private void WriteDocFor<T>(T item)
            where T : ADocItem, ITitleDocItem
        {
            _markdown.AppendLine($"### {"Home".AsLink("DefaultEcs")}");
            if (item.Parent != null)
            {
                _markdown.AppendLine($"### {item.Parent.FullName().AsLink()}");
                _markdown.AppendLine($"## {item.Name} `{item.Title}`");
            }
            else
            {
                _markdown.AppendLine($"## {item.FullName()} `{item.Title}`");
            }

            _markdown.AppendLine(WriteSummary(item));

            WriteGenerics(item as AGenericDocItem);
            WriteParameters(item as IParameterDocItem);
            WriteReturns(item as MethodItem);
            WriteExceptions(item);
        }

        private void WriteHome()
        {
            _markdown.AppendLine($"### {"Home".AsLink("DefaultEcs")}");

            foreach (IGrouping<string, TypeItem> typesByNamespace in _items.Values.OfType<TypeItem>().GroupBy(i => i.Namespace).OrderBy(i => i.Key))
            {
                _markdown.AppendLine($"## {typesByNamespace.Key}");

                foreach (TypeItem item in typesByNamespace)
                {
                    _markdown.AppendLine($"- {item.FullName().AsLink(item.Name)}");
                }
            }

            _markdown.FlushTo(_outputPath, "Home");
        }

        private void WriteLinkFor<T>(ADocItem parent)
            where T : ADocItem, ITitleDocItem
        {
            bool hasTitle = false;

            foreach (T item in _items.Values.OfType<T>().Where(i => i.Parent == parent).OrderBy(i => i.Name))
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    _markdown.AppendLine($"### {item.Title}");
                }

                _markdown.AppendLine($"- {item.FullName().AsLink(item.Name)}");
            }
        }

        private void WriteTypePages()
        {
            foreach (TypeItem item in _items.Values.OfType<TypeItem>())
            {
                WriteDocFor(item);
                WriteLinkFor<ConstructorItem>(item);
                WriteLinkFor<FieldItem>(item);
                WriteLinkFor<PropertyItem>(item);
                WriteLinkFor<MethodItem>(item);

                _markdown.FlushTo(_outputPath, item.FullName());
            }
        }

        private void WriteDocPages<T>()
            where T : ADocItem, ITitleDocItem
        {
            foreach (T item in _items.Values.OfType<T>())
            {
                WriteDocFor(item);

                _markdown.FlushTo(_outputPath, item.FullName());
            }
        }

        public static void Convert(XDocument document, string outputPath)
        {
            Converter converter = new Converter(document, outputPath);

            converter.WriteHome();
            converter.WriteTypePages();
            converter.WriteDocPages<ConstructorItem>();
            converter.WriteDocPages<FieldItem>();
            converter.WriteDocPages<PropertyItem>();
            converter.WriteDocPages<MethodItem>();
        }
    }
}
