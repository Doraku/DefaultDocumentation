using System;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation.Writer
{
    internal sealed class PageWriter
    {
        private readonly StringBuilder _builder;

        private bool _needPrefix;
        private bool _startingNewLine;
        private int? _textStartIndex;

        public bool? IgnoreLineBreak;
        public bool DisplayAsSingleLine;
        public string LinePrefix;

        public DocumentationContext Context { get; }

        public DocItem PageItem { get; }

        public DocItem CurrentItem { get; }

        public PageWriter(DocumentationContext context, StringBuilder builder, DocItem pageItem, DocItem currentItem)
        {
            _builder = builder;

            _needPrefix = true;
            _startingNewLine = true;

            Context = context;
            PageItem = pageItem;
            CurrentItem = currentItem;

            DisplayAsSingleLine = false;
            LinePrefix = string.Empty;
        }

        public PageWriter(DocumentationContext context, StringBuilder builder, DocItem pageItem)
            : this(context, builder, pageItem, pageItem)
        { }

        public PageWriter EnsureLineStart()
        {
            if (!_needPrefix)
            {
                AppendLine();
            }

            return this;
        }

        public PageWriter Append(string text)
        {
            if (_needPrefix)
            {
                _builder.Append(LinePrefix);
                _needPrefix = false;
            }

            _builder.Append(text);

            return this;
        }

        public PageWriter AppendLine()
        {
            if (_builder.Length != 0)
            {
                if (DisplayAsSingleLine)
                {
                    _builder.Append(IgnoreLineBreak ?? true ? " " : "<br/>");
                }
                else
                {
                    _builder.AppendLine(IgnoreLineBreak ?? true ? string.Empty : "  ");
                    _needPrefix = true;
                }
            }

            return this;
        }

        public PageWriter AppendLine(string text) => Append(text).AppendLine();

        public PageWriter AppendUrl(string url, string displayedName = null, string tooltip = null) => Append($"[{(displayedName ?? url).Prettify()}]({url} '{tooltip ?? url}')");

        public PageWriter AppendLink(DocItem item, string displayedName = null) => AppendUrl(Context.GetUrl(item), displayedName ?? item.Name, item.FullName);

        public PageWriter AppendLink(string id, string displayedName = null) => Context.TryGetDocItem(id, out DocItem item) ? AppendLink(item, displayedName) : AppendUrl(Context.GetUrl(id), displayedName ?? id.Substring(2), id.Substring(2));

        public PageWriter AppendLink(DocItem item, INamedElement element)
        {
            PageWriter HandleParameterizedType(ParameterizedType genericType)
            {
                string id = genericType.GetDefinition().GetIdString();

                AppendLink(id, genericType.FullName + "<");

                bool firstWritten = false;
                foreach (IType typeArgument in genericType.TypeArguments)
                {
                    if (firstWritten)
                    {
                        AppendLink(id, ",");
                    }
                    else
                    {
                        firstWritten = true;
                    }

                    AppendLink(item, typeArgument);
                }

                return AppendLink(id, ">");
            }

            PageWriter HandleFunctionPointer(FunctionPointerType functionPointerType)
            {
                const string reference = "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers";

                AppendUrl(reference, "delegate*<");

                foreach (IType parameterType in functionPointerType.ParameterTypes)
                {
                    AppendLink(item, parameterType);
                    AppendUrl(reference, ",");
                }

                AppendLink(item, functionPointerType.ReturnType);

                return AppendUrl(reference, ">");
            }

            PageWriter HandleTupleType(TupleType tupleType)
            {
                string id = "T:" + tupleType.FullName;

                AppendLink(id, "<");

                foreach (IType elementType in tupleType.ElementTypes)
                {
                    AppendLink(item, elementType);
                    AppendLink(id, ",");
                }

                --_builder.Length;

                return AppendLink(id, ">");
            }

            return element switch
            {
                IType type => type.Kind switch
                {
                    TypeKind.Array when type is TypeWithElementType arrayType => AppendLink(item, arrayType.ElementType).AppendLink("T:System.Array", "[]"),
                    TypeKind.FunctionPointer when type is FunctionPointerType functionPointerType => HandleFunctionPointer(functionPointerType),
                    TypeKind.Pointer when type is TypeWithElementType pointerType => AppendLink(item, pointerType.ElementType).Append("*"),
                    TypeKind.ByReference when type is TypeWithElementType innerType => AppendLink(item, innerType.ElementType),
                    TypeKind.TypeParameter => item.TryGetTypeParameterDocItem(type.Name, out TypeParameterDocItem typeParameter) ? AppendLink(typeParameter) : Append(type.Name),
                    TypeKind.Dynamic => AppendUrl("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic", "dynamic"),
                    TypeKind.Tuple when type is TupleType tupleType => HandleTupleType(tupleType),
                    TypeKind.Unknown => AppendLink("?:" + type.FullName),
                    _ when type is ParameterizedType genericType => HandleParameterizedType(genericType),
                    _ => AppendLink(type.GetDefinition().GetIdString())
                },
                IMember member => AppendLink(member.MemberDefinition.GetIdString(), DocItem.NameAmbience.ConvertSymbol(member)),
                IEntity entity => AppendLink(entity.GetIdString(), DocItem.NameAmbience.ConvertSymbol(entity)),
                _ => Append(element.FullName)
            };
        }

        public PageWriter AppendMultiline(string text)
        {
            string[] lines = text.Split('\n');
            int currentLine = 0;

            if (_textStartIndex is null && _startingNewLine)
            {
                for (currentLine = 0; currentLine <= lines.Length; ++currentLine)
                {
                    string line = lines[currentLine];
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        _textStartIndex = line.Length - line.TrimStart().Length;
                        break;
                    }
                }
            }

            for (; currentLine < lines.Length; ++currentLine)
            {
                string line = lines[currentLine];
                if (_startingNewLine)
                {
                    line = line.Substring(Math.Min(line.Length, _textStartIndex ?? 0), Math.Max(0, line.Length - (_textStartIndex ?? 0)));
                }

                Append(line);

                _startingNewLine = currentLine < lines.Length - 1;
                if (_startingNewLine)
                {
                    AppendLine();
                }
            }

            return this;
        }

        public PageWriter Append(XElement parent)
        {
            if (parent != null)
            {
                using RollbackSetter<bool?> _ = new(() => ref IgnoreLineBreak, parent.GetIgnoreLineBreak() ?? IgnoreLineBreak ?? Context.Settings.IgnoreLineBreak);

                foreach (XNode node in parent.Nodes())
                {
                    switch (node)
                    {
                        case XText text:
                            AppendMultiline(text.Value);
                            break;

                        case XElement element when Context.ElementWriters.TryGetValue(element.Name.ToString(), out ElementWriter writer):
                            writer.Write(this, element);
                            break;

                        case XElement element:
                            AppendMultiline(element.ToString());
                            break;

                        default:
                            throw new Exception($"unhandled node type {node.NodeType}");
                    }

                    if (node is XElement)
                    {
                        _startingNewLine = false;
                    }
                }
            }

            return this;
        }

        public PageWriter With(DocItem currentItem) => new(Context, _builder, PageItem, currentItem);
    }
}
