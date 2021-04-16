using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation.Writer
{
    internal sealed class MarkdownWriter : DocItemWriter
    {
        private readonly ConcurrentDictionary<string, string> _urls;
        private readonly StringBuilder _builder;
        private readonly Func<DocItem, string> _urlFactory;

        public MarkdownWriter(Settings settings)
            : base(settings)
        {
            _urls = new ConcurrentDictionary<string, string>();
            _builder = new StringBuilder();
            _urlFactory = item =>
            {
                if (item is ExternDocItem externItem)
                {
                    return externItem.Url;
                }

                DocItem pagedItem = item;
                while (!HasOwnPage(pagedItem))
                {
                    pagedItem = pagedItem.Parent;
                }

                string url = GetFileName(pagedItem);
                if (!settings.RemoveFileExtensionFromLinks)
                {
                    url += ".md";
                }
                if (item != pagedItem)
                {
                    url += "#" + settings.PathCleaner.Clean(item.FullName);
                }

                return url;
            };
        }

        private static string ToLink(string url, string displayedName = null) => $"[{(displayedName ?? url).Prettify()}]({url} '{url}')";

        private string GetLink(DocItem item, string displayedName = null) => $"[{displayedName ?? item.Name}]({GetUrl(item)} '{item.FullName}')";

        private string GetLink(string id, string displayedName = null) => TryGetDocItem(id, out DocItem item) ? GetLink(item, displayedName) : $"[{(displayedName ?? id.Substring(2)).Prettify()}]({_urls.GetOrAdd(id, i => i.ToDotNetApiUrl())} '{id.Substring(2)}')";

        private string GetLink(DocItem item, INamedElement element)
        {
            string HandleParameterizedType(ParameterizedType genericType)
            {
                string id = genericType.GetDefinition().GetIdString();

                return GetLink(id, genericType.FullName + "&lt;")
                    + string.Join(GetLink(id, ","), genericType.TypeArguments.Select(t => GetLink(item, t)))
                    + GetLink(id, "&gt;");
            }

            string HandleFunctionPointer(FunctionPointerType functionPointerType)
            {
                const string reference = "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers";

                return ToLink(reference, "delegate*<")
                    + string.Join(ToLink(reference, ","), functionPointerType.ParameterTypes.Concat(Enumerable.Repeat(functionPointerType.ReturnType, 1)).Select(t => GetLink(item, t)))
                    + ToLink(reference, ">");
            }

            string HandleTupleType(TupleType tupleType)
            {
                return GetLink("T:" + tupleType.FullName, "&lt;")
                    + string.Join(GetLink("T:" + tupleType.FullName, ","), tupleType.ElementTypes.Select(t => GetLink(item, t)))
                    + GetLink("T:" + tupleType.FullName, "&gt;");
            }

            return element switch
            {
                IType type => type.Kind switch
                {
                    TypeKind.Array when type is TypeWithElementType arrayType => GetLink(item, arrayType.ElementType) + GetLink("T:System.Array", "[]"),
                    TypeKind.FunctionPointer when type is FunctionPointerType functionPointerType => HandleFunctionPointer(functionPointerType),
                    TypeKind.Pointer when type is TypeWithElementType pointerType => GetLink(item, pointerType.ElementType) + "*",
                    TypeKind.ByReference when type is TypeWithElementType innerType => GetLink(item, innerType.ElementType),
                    TypeKind.TypeParameter => item.TryGetTypeParameterDocItem(type.Name, out TypeParameterDocItem typeParameter) ? GetLink(typeParameter) : type.Name,
                    TypeKind.Dynamic => ToLink("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic", "dynamic"),
                    TypeKind.Tuple when type is TupleType tupleType => HandleTupleType(tupleType),
                    TypeKind.Unknown => GetLink("?:" + type.FullName),
                    _ when type is ParameterizedType genericType => HandleParameterizedType(genericType),
                    _ => GetLink(type.GetDefinition().GetIdString())
                },
                IMember member => GetLink(member.MemberDefinition.GetIdString(), DocItem.NameAmbience.ConvertSymbol(member)),
                IEntity entity => GetLink(entity.GetIdString(), DocItem.NameAmbience.ConvertSymbol(entity)),
                _ => element.FullName
            };
        }

        private void WriteText(DocItem item, XElement element, string title = null)
        {
            if (element is null)
            {
                return;
            }

            if (title is not null)
            {
                _builder.AppendLine(title);
            }

            int? startIndex = default;
            bool isNewLine = true;

            StringBuilder WriteText(string text)
            {
                string[] lines = text.Split('\n');
                int currentLine = 0;

                if (startIndex is null && isNewLine)
                {
                    for (currentLine = 0; currentLine <= lines.Length; ++currentLine)
                    {
                        string line = lines[currentLine];
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            startIndex = line.Length - line.TrimStart().Length;
                            break;
                        }
                    }
                }

                for (; currentLine < lines.Length; ++currentLine)
                {
                    string line = lines[currentLine];
                    if (isNewLine)
                    {
                        _builder.Append(line, Math.Min(line.Length, startIndex ?? 0), Math.Max(0, line.Length - (startIndex ?? 0)));
                    }
                    else
                    {
                        _builder.Append(line);
                    }

                    isNewLine = currentLine < lines.Length - 1;
                    if (isNewLine)
                    {
                        _builder.AppendLine("  ");
                    }
                }

                return _builder;
            }

            StringBuilder WriteSee(XElement element)
            {
                string @ref = element.GetCRefAttribute();
                if (@ref is not null)
                {
                    return _builder.Append(GetLink(@ref, element.Value.NullIfEmpty()));
                }

                @ref = element.GetHRefAttribute();
                if (@ref is not null)
                {
                    return _builder.Append(ToLink(@ref, element.Value.NullIfEmpty()));
                }

                @ref = element.GetLangWordAttribute();
                if (@ref is not null)
                {
                    return _builder.Append(ToLink(
                        @ref switch
                        {
                            "await" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await",
                            "false" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                            "true" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                            _ => $"https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/{@ref}"
                        },
                        element.Value.NullIfEmpty() ?? @ref));
                }

                return _builder;
            }

            StringBuilder WritePara(XElement element)
            {
                _builder.AppendLine().AppendLine();
                WriteNodes(element.Nodes());
                return _builder.AppendLine().AppendLine();
            }

            StringBuilder WriteCode(XElement element)
            {
                _builder.Append("```").AppendLine(element.GetLanguageAttribute() ?? "csharp");

                string source = element.GetSourceAttribute();

                if (source is null)
                {
                    WriteText(element.Value);
                }
                else
                {
                    int? previousStartIndex = startIndex;
                    isNewLine = true;
                    startIndex = null;

                    WriteText(GetCode(source, element.GetRegionAttribute()));

                    startIndex = previousStartIndex;
                }

                return _builder.AppendLine("```");
            }

            void WriteNodes(IEnumerable<XNode> nodes)
            {
                foreach (XNode node in nodes)
                {
                    _ = node switch
                    {
                        XText text => WriteText(text.Value),
                        XElement element => element.Name.ToString() switch
                        {
                            "see" => WriteSee(element),
                            "seealso" => _builder,
                            "typeparamref" => _builder.Append(item.TryGetTypeParameterDocItem(element.GetNameAttribute(), out TypeParameterDocItem typeParameter) ? GetLink(typeParameter) : element.GetNameAttribute()),
                            "paramref" => _builder.Append(item.TryGetParameterDocItem(element.GetNameAttribute(), out ParameterDocItem parameter) ? GetLink(parameter) : element.GetNameAttribute()),
                            "c" => _builder.Append('`').Append(element.Value).Append('`'),
                            "code" => WriteCode(element),
                            "para" => WritePara(element),
                            _ => _builder.Append(element.ToString())
                        },
                        _ => throw new Exception($"unhandled node type in summary {node.NodeType}")
                    };

                    if (node is XElement)
                    {
                        isNewLine = false;
                    }
                }
            }

            WriteNodes(element.Nodes());
            _builder.AppendLine();

            int builderLength = -1;
            while (_builder.Length != builderLength && _builder.Length > Environment.NewLine.Length * 2)
            {
                builderLength = _builder.Length;
                _builder.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine, builderLength - (Environment.NewLine.Length * 2), Environment.NewLine.Length * 2);
            }
        }

        private void WriteHeader(DocItem item)
        {
            AssemblyDocItem assembly = Items.OfType<AssemblyDocItem>().Single();
            if (HasOwnPage(assembly))
            {
                _builder.Append("#### ").AppendLine(GetLink(assembly));
            }

            Stack<DocItem> parents = new();
            for (DocItem parent = item?.Parent; parent != assembly && parent != null; parent = parent.Parent)
            {
                parents.Push(parent);
            }

            if (parents.Count > 0)
            {
                _builder.Append("### ").AppendLine(string.Join(".", parents.Select(p => GetLink(p))));
            }
        }

        private void WriteTitle(DocItem item)
        {
            if (!HasOwnPage(item))
            {
                string url = GetUrl(item);
                int startIndex = url.IndexOf('#') + 1;
                _builder.Append("<a name='").Append(url, startIndex, url.Length - startIndex).AppendLine("'></a>");
            }

            string title = item switch
            {
                NamespaceDocItem => $"## {item.Name} Namespace",
                TypeDocItem typeItem => $"## {item.LongName} {typeItem.Type.Kind}",
                ConstructorDocItem => $"## {item.LongName} Constructor",
                EventDocItem => $"## {item.LongName} Event",
                FieldDocItem => $"## {item.LongName} Field",
                MethodDocItem => $"## {item.LongName} Method",
                OperatorDocItem => $"## {item.LongName} Operator",
                PropertyDocItem => $"## {item.LongName} Property",
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IMethod => $"## {item.LongName} Method",
                ExplicitInterfaceImplementationDocItem explicitItem when explicitItem.Member is IProperty => $"## {item.LongName} Property",
                EnumFieldDocItem enumFiedItem => $"`{item.Name}` {enumFiedItem.Field.GetConstantValue()}  ",
                ParameterDocItem parameterItem => $"`{item.Name}` {GetLink(item, parameterItem.Parameter.Type)}  ",
                TypeParameterDocItem typeParameterItem => $"`{typeParameterItem.TypeParameter.Name}`  ",
                _ => null
            };

            if (title is not null)
            {
                _builder.AppendLine(title);
            }
        }

        private void WriteDefinition(DocItem item)
        {
            if (item is IDefinedDocItem definedItem)
            {
                _builder.AppendLine("```csharp");
                definedItem.WriteDefinition(_builder);
                _builder.AppendLine("```");
            }
        }

        private void WriteReturns(DocItem item)
        {
            IType returnType = item switch
            {
                DelegateDocItem delegateItem => delegateItem.InvokeMethod.ReturnType,
                MethodDocItem methodItem => methodItem.Method.ReturnType,
                OperatorDocItem operatorItem => operatorItem.Method.ReturnType,
                _ => null
            };

            if (returnType != null && returnType.Kind != TypeKind.Void)
            {
                _builder.AppendLine("#### Returns");
                _builder.Append(GetLink(item, returnType)).AppendLine("  ");
                WriteText(item, item.Documentation.GetReturns());
            }
        }

        private void WriteEventType(DocItem item)
        {
            if (item is EventDocItem eventItem)
            {
                _builder.AppendLine("#### Event Type");
                _builder.AppendLine(GetLink(item, eventItem.Event.ReturnType));
            }
        }

        private void WriteFieldValue(DocItem item)
        {
            if (item is FieldDocItem fieldItem)
            {
                _builder.AppendLine("#### Field Value");
                _builder.AppendLine(GetLink(item, fieldItem.Field.Type));
            }
        }

        private void WritePropertyValue(DocItem item)
        {
            if (item is PropertyDocItem propertyItem)
            {
                _builder.AppendLine("#### Property Value");
                _builder.AppendLine(GetLink(item, propertyItem.Property.ReturnType));
                WriteText(item, item.Documentation.GetValue());
            }
        }

        private void WriteExceptions(DocItem item)
        {
            bool hasTitle = false;
            foreach (XElement exception in item.Documentation.GetExceptions())
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    _builder.AppendLine("#### Exceptions");
                }

                string cref = exception.GetCRefAttribute();

                _builder.Append(GetLink(cref)).AppendLine("  ");

                WriteText(item, exception);
            }
        }

        private void WriteInheritances(DocItem item)
        {
            if (item is TypeDocItem typeItem)
            {
                if (typeItem.Type.Kind == TypeKind.Class)
                {
                    _builder.AppendLine().Append("Inheritance ");
                    foreach (ITypeDefinition t in typeItem.Type.GetNonInterfaceBaseTypes().Where(t => t != typeItem.Type))
                    {
                        _builder.Append(GetLink(item, t)).Append(" &#129106; ");
                    }
                    _builder.Append(item.Name).AppendLine("  ");
                }

                List<TypeDocItem> derived = Items.OfType<TypeDocItem>().Where(i => i.Type.DirectBaseTypes.Select(t => t is ParameterizedType g ? g.GetDefinition() : t).Contains(typeItem.Type)).OrderBy(i => i.FullName).ToList();
                if (derived.Count > 0)
                {
                    _builder.AppendLine().Append("Derived  ");
                    foreach (TypeDocItem t in derived)
                    {
                        _builder.Append(Environment.NewLine).Append("&#8627; ").Append(GetLink(t));
                    }
                    _builder.AppendLine("  ");
                }
            }
        }

        private void WriteImplements(DocItem item)
        {
            List<INamedElement> implementations = (item switch
            {
                TypeDocItem typeItem => typeItem.Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface && t.GetDefinition().Accessibility == Accessibility.Public).OfType<INamedElement>(),
                PropertyDocItem propertyItem => Enumerable.Empty<INamedElement>(),
                MethodDocItem methodItem => Enumerable.Empty<INamedElement>(),
                ExplicitInterfaceImplementationDocItem explicitItem => explicitItem.Member.ExplicitlyImplementedInterfaceMembers,
                _ => Enumerable.Empty<INamedElement>()
            }).ToList();

            if (implementations.Count > 0)
            {
                _builder.AppendLine().Append("Implements ");
                foreach (INamedElement i in implementations)
                {
                    _builder.Append(GetLink(item, i)).Append(", ");
                }
                _builder.Length -= 2;
                _builder.AppendLine("  ");
            }
        }

        private void WriteSeeAlsos(DocItem item)
        {
            bool hasTitle = false;
            foreach (XElement seeAlso in item.Documentation.GetSeeAlsos())
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    _builder.AppendLine("#### See Also");
                }

                string @ref = seeAlso.GetCRefAttribute();
                if (@ref is not null)
                {
                    _builder.Append("- ").AppendLine(GetLink(@ref, seeAlso.Value.NullIfEmpty()));
                    continue;
                }

                @ref = seeAlso.GetHRefAttribute();
                if (@ref is not null)
                {
                    _builder.Append("- ").AppendLine(ToLink(@ref, seeAlso.Value.NullIfEmpty()));
                }
            }
        }

        private void WriteItems(IEnumerable<DocItem> items, string title = null)
        {
            static IEnumerable<DocItem> GetAllDeclaringTypes(DocItem item)
            {
                while (item is TypeDocItem)
                {
                    yield return item;
                    item = item.Parent;
                }
            }

            foreach (DocItem item in items ?? Enumerable.Empty<DocItem>())
            {
                if (title is not null)
                {
                    _builder.AppendLine(title);
                    title = null;
                }

                if (HasOwnPage(item))
                {
                    _builder
                        .AppendLine()
                        .AppendLine("***")
                        .AppendLine(GetLink(
                            item,
                            item switch
                            {
                                TypeDocItem => string.Join(".", GetAllDeclaringTypes(item).Reverse().Select(i => i.Name)),
                                _ => null
                            }))
                        .AppendLine();

                    WriteText(item, item.Documentation.GetSummary());
                }
                else
                {
                    WriteItem(item);
                    _builder.AppendLine("  ");
                }
            }
        }

        private void WriteItem(DocItem item)
        {
            WriteTitle(item);
            WriteText(
                item,
                item switch
                {
                    TypeParameterDocItem => item.Documentation,
                    ParameterDocItem => item.Documentation,
                    _ => item.Documentation.GetSummary()
                });

            WriteDefinition(item);

            WriteItems((item as ITypeParameterizedDocItem)?.TypeParameters, "#### Type parameters");
            WriteItems((item as IParameterizedDocItem)?.Parameters, "#### Parameters");
            WriteItems(GetChildren<EnumFieldDocItem>(item), "#### Fields");
            WriteEventType(item);
            WriteFieldValue(item);
            WritePropertyValue(item);
            WriteReturns(item);
            WriteExceptions(item);
            WriteInheritances(item);
            // todo: attribute
            WriteImplements(item);

            WriteText(item, item.Documentation.GetExample(), "### Example");
            WriteText(item, item.Documentation.GetRemarks(), "### Remarks");

            WriteItems(GetChildren<ConstructorDocItem>(item), "### Constructors");
            WriteItems(GetChildren<FieldDocItem>(item), "### Fields");
            WriteItems(GetChildren<PropertyDocItem>(item), "### Properties");
            WriteItems(GetChildren<MethodDocItem>(item), "### Methods");
            WriteItems(GetChildren<EventDocItem>(item), "### Events");
            WriteItems(GetChildren<OperatorDocItem>(item), "### Operators");
            WriteItems(GetChildren<ExplicitInterfaceImplementationDocItem>(item), "### Explicit Interface Implementations");

            WriteItems(GetChildren<ClassDocItem>(item), "### Classes");
            WriteItems(GetChildren<StructDocItem>(item), "### Structs");
            WriteItems(GetChildren<InterfaceDocItem>(item), "### Interfaces");
            WriteItems(GetChildren<EnumDocItem>(item), "### Enums");
            WriteItems(GetChildren<DelegateDocItem>(item), "### Delegates");

            WriteItems(GetChildren<NamespaceDocItem>(item), "### Namespaces");

            WriteSeeAlsos(item);
        }

        protected override void Clean(DirectoryInfo directory)
        {
            if (directory.Exists)
            {
                foreach (FileInfo file in directory.GetFiles("*.md"))
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
                            Thread.Sleep(100);
                            goto start;
                        }

                        throw;
                    }
                }
            }
            else
            {
                directory.Create();
            }
        }

        protected override string GetUrl(DocItem item) => _urls.GetOrAdd(item.Id, _ => _urlFactory(item));

        protected override void WritePage(DirectoryInfo directory, DocItem item)
        {
            _builder.Clear();

            WriteHeader(item);

            WriteItem(item);

            File.WriteAllText(Path.Combine(directory.FullName, GetFileName(item) + ".md"), _builder.ToString());
        }
    }
}
