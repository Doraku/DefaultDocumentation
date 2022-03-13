using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Writers;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation.Markdown.Extensions
{
    public static class IWriterExtensions
    {
        private static readonly CSharpAmbience _nameAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
        };

        private const string CurrentItemKey = "Markdown.CurrentItem";
        private const string DisplayAsSingleLineKey = "Markdown.DisplayAsSingleLine";
        private const string IgnoreLineBreakLineKey = "Markdown.IgnoreLineBreak";

        public static DocItem GetCurrentItem(this IWriter writer) => writer[CurrentItemKey] as DocItem ?? writer.DocItem;

        public static IWriter SetCurrentItem(this IWriter writer, DocItem value)
        {
            writer[CurrentItemKey] = value;

            return writer;
        }

        public static bool GetDisplayAsSingleLine(this IWriter writer) => writer[DisplayAsSingleLineKey] as bool? ?? false;

        public static IWriter SetDisplayAsSingleLine(this IWriter writer, bool? value)
        {
            writer[DisplayAsSingleLineKey] = value;

            return writer;
        }

        public static bool GetIgnoreLineBreak(this IWriter writer) =>
            writer[IgnoreLineBreakLineKey] as bool?
            ?? writer.Context.GetSetting(writer.GetCurrentItem(), c => c.GetSetting<bool?>(IgnoreLineBreakLineKey)).GetValueOrDefault();

        public static IWriter SetIgnoreLineBreakLine(this IWriter writer, bool? value)
        {
            writer[IgnoreLineBreakLineKey] = value;

            return writer;
        }

        public static IWriter AppendUrl(this IWriter writer, string url, string displayedName = null, string tooltip = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                writer.Append((displayedName ?? "").Prettify());
            }
            else
            {
                writer
                    .Append("[")
                    .Append((displayedName ?? url).Prettify())
                    .Append("](")
                    .Append(url)
                    .Append(" '")
                    .Append(tooltip ?? url)
                    .Append("')");
            }

            return writer;
        }

        public static IWriter AppendLink(this IWriter writer, DocItem item, string displayedName = null) => writer.AppendUrl(writer.Context.GetUrl(item), displayedName ?? item.Name, item.FullName);

        public static IWriter AppendLink(this IWriter writer, string id, string displayedName = null) =>
            writer.Context.Items.TryGetValue(id, out DocItem item)
            ? writer.AppendLink(item, displayedName)
            : writer.AppendUrl(writer.Context.GetUrl(id), displayedName ?? id.Substring(2), id.Substring(2));

        public static IWriter AppendLink(this IWriter writer, DocItem item, INamedElement element)
        {
            IWriter HandleParameterizedType(ParameterizedType genericType)
            {
                string id = genericType.GetDefinition().GetIdString();

                writer.AppendLink(id, genericType.FullName + "<");

                bool firstWritten = false;
                foreach (IType typeArgument in genericType.TypeArguments)
                {
                    if (firstWritten)
                    {
                        writer.AppendLink(id, ",");
                    }
                    else
                    {
                        firstWritten = true;
                    }

                    writer.AppendLink(item, typeArgument);
                }

                return writer.AppendLink(id, ">");
            }

            IWriter HandleFunctionPointer(FunctionPointerType functionPointerType)
            {
                const string reference = "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers";

                writer.AppendUrl(reference, "delegate*<");

                foreach (IType parameterType in functionPointerType.ParameterTypes)
                {
                    writer
                        .AppendLink(item, parameterType)
                        .AppendUrl(reference, ",");
                }

                return writer
                    .AppendLink(item, functionPointerType.ReturnType)
                    .AppendUrl(reference, ">");
            }

            IWriter HandleTupleType(TupleType tupleType)
            {
                string id = "T:" + tupleType.FullName;

                writer.AppendLink(id, "<");

                bool firstWritten = false;
                foreach (IType elementType in tupleType.ElementTypes)
                {
                    if (firstWritten)
                    {
                        writer.AppendLink(id, ",");
                    }
                    else
                    {
                        firstWritten = true;
                    }

                    writer.AppendLink(item, elementType);
                }

                return writer.AppendLink(id, ">");
            }

            return element switch
            {
                IType type => type.Kind switch
                {
                    TypeKind.Array when type is TypeWithElementType arrayType => writer.AppendLink(item, arrayType.ElementType).AppendLink("T:System.Array", "[]"),
                    TypeKind.FunctionPointer when type is FunctionPointerType functionPointerType => HandleFunctionPointer(functionPointerType),
                    TypeKind.Pointer when type is TypeWithElementType pointerType => writer.AppendLink(item, pointerType.ElementType).Append("*"),
                    TypeKind.ByReference when type is TypeWithElementType innerType => writer.AppendLink(item, innerType.ElementType),
                    TypeKind.TypeParameter => item.TryGetTypeParameterDocItem(type.Name, out TypeParameterDocItem typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(type.Name),
                    TypeKind.Dynamic => writer.AppendUrl("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic", "dynamic"),
                    TypeKind.Tuple when type is TupleType tupleType => HandleTupleType(tupleType),
                    TypeKind.Unknown => writer.AppendLink("?:" + type.FullName),
                    _ when type is ParameterizedType genericType => HandleParameterizedType(genericType),
                    _ => writer.AppendLink(type.GetDefinition().GetIdString())
                },
                IMember member => writer.AppendLink(member.MemberDefinition.GetIdString(), _nameAmbience.ConvertSymbol(member).Replace("?", string.Empty)),
                IEntity entity => writer.AppendLink(entity.GetIdString(), _nameAmbience.ConvertSymbol(entity).Replace("?", string.Empty)),
                _ => writer.Append(element.FullName)
            };
        }

        public static IWriter EnsureLineStart(this IWriter writer) =>
            writer.Length > 0 && (!writer.EndsWith(Environment.NewLine) || (writer.GetDisplayAsSingleLine() && !writer.EndsWith("<br/>")))
            ? writer.AppendLine()
            : writer;

        public static IWriter EnsureLineStartAndAppendLine(this IWriter writer) => writer
            .EnsureLineStart()
            .AppendLine();

        public static IWriter AppendAsMarkdown(this IWriter writer, XElement element)
        {
            new MarkdownWriter(writer)
                .SetIgnoreLineBreakLine(element?.GetIgnoreLineBreak())
                .Append(element);

            return writer.TrimEnd(Environment.NewLine, "<br/>", " ");
        }

        public static IWriter ToPrefixedWriter(this IWriter writer, string prefix) => new PrefixedWriter(writer, prefix);

        public static IWriter ToOverrideWriter(this IWriter writer) => new OverrideWriter(writer);
    }
}
