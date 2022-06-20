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

namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Provides extension methods on the <see cref="IWriter"/> type.
    /// </summary>
    public static class IWriterExtension
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
        private const string AppendLinkOverride = "Markdown.AppendLink(DocItem,string)";
        private const string AppendUrlOverride = "Markdown.AppendUrl(string,string,string)";

        /// <summary>
        /// Gets the current item that is being processed by this <see cref="IWriter"/>.
        /// It can be different from the <see cref="IWriter.DocItem"/> when inlining child documentation in its parent page.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to get the current item.</param>
        /// <returns>The <see cref="DocItem"/> for which the documentation is being generated.</returns>
        public static DocItem GetCurrentItem(this IWriter writer) => writer[CurrentItemKey] as DocItem ?? writer.DocItem;

        /// <summary>
        /// Sets the current item that is being processed by this <see cref="IWriter"/>.
        /// It can be different from the <see cref="IWriter.DocItem"/> when inlining child documentation in its parent page.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to set the current item.</param>
        /// <param name="value">The <see cref="DocItem"/> for which the documentation is being generated.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter SetCurrentItem(this IWriter writer, DocItem value)
        {
            writer[CurrentItemKey] = value;

            return writer;
        }

        /// <summary>
        /// Gets whether all futur data appended to the given <see cref="IWriter"/> should stay on the same line (usefull for table).
        /// This setting is used by the <see cref="MarkdownWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
        /// <returns>Whether all futur data to happend should stay on the same line.</returns>
        public static bool GetDisplayAsSingleLine(this IWriter writer) => writer[DisplayAsSingleLineKey] as bool? ?? false;

        /// <summary>
        /// Sets whether all futur data appended to the given <see cref="IWriter"/> should stay on the same line (usefull for table).
        /// This setting is used by the <see cref="MarkdownWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
        /// <param name="value">Whether all futur data to happend should stay on the same line.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter SetDisplayAsSingleLine(this IWriter writer, bool? value)
        {
            writer[DisplayAsSingleLineKey] = value;

            return writer;
        }

        /// <summary>
        /// Gets whether line break in the xml documentation should be ignored in the generated markdown.
        /// This setting is used by the <see cref="MarkdownWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
        /// <returns>Whether line break in the xml documentation should be ignored in the generated markdown.</returns>
        /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak">Markdown.IgnoreLineBreak</seealso>
        public static bool GetIgnoreLineBreak(this IWriter writer) =>
            writer[IgnoreLineBreakLineKey] as bool?
            ?? writer.Context.GetSetting(writer.GetCurrentItem(), c => c.GetSetting<bool?>(IgnoreLineBreakLineKey)).GetValueOrDefault();

        /// <summary>
        /// Sets whether line break in the xml documentation should be ignored in the generated markdown.
        /// This setting is used by the <see cref="MarkdownWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
        /// <param name="value">Whether line break in the xml documentation should be ignored in the generated markdown.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak">Markdown.IgnoreLineBreak</seealso>
        public static IWriter SetIgnoreLineBreakLine(this IWriter writer, bool? value)
        {
            writer[IgnoreLineBreakLineKey] = value;

            return writer;
        }

        /// <summary>
        /// Sets an override of the default action for <see cref="AppendLink(IWriter, DocItem, string?)"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to set this override.</param>
        /// <param name="value">The action to use.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter SetAppendLinkOverride(this IWriter writer, Action<IWriter, DocItem, string?>? value)
        {
            writer[AppendLinkOverride] = value;

            return writer;
        }

        /// <summary>
        /// Sets an override of the default action for <see cref="AppendUrl(IWriter, string, string?, string?)"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> for which to set this override.</param>
        /// <param name="value">The action to use.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter SetAppendUrlOverride(this IWriter writer, Action<IWriter, string, string?, string?>? value)
        {
            writer[AppendUrlOverride] = value;

            return writer;
        }

        /// <summary>
        /// Append an url in the markdown format.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to use.</param>
        /// <param name="url">The url of the link.</param>
        /// <param name="displayedName">The displayed name of the link.</param>
        /// <param name="tooltip">The tooltip of the link.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter AppendUrl(this IWriter writer, string url, string? displayedName = null, string? tooltip = null)
        {
            static void Default(IWriter writer, string url, string? displayedName, string? tooltip)
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
            }

            ((writer[AppendUrlOverride] as Action<IWriter, string, string?, string?>) ?? Default)(writer, url, displayedName, tooltip);

            return writer;
        }

        /// <summary>
        /// Append an link to a <see cref="DocItem"/> in the markdown format.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to use.</param>
        /// <param name="item">The <see cref="DocItem"/> to link to.</param>
        /// <param name="displayedName">The displayed name of the link.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter AppendLink(this IWriter writer, DocItem item, string? displayedName = null)
        {
            static void Default(IWriter writer, DocItem item, string? displayedName) => writer.AppendUrl(writer.Context.GetUrl(item), displayedName ?? item.Name, item.FullName);

            ((writer[AppendLinkOverride] as Action<IWriter, DocItem, string?>) ?? Default)(writer, item, displayedName);

            return writer;
        }

        /// <summary>
        /// Append an link to an id using <see cref="IGeneralContext.GetUrl(string)"/> to resolve the url in the markdown format.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to use.</param>
        /// <param name="id">The id to link to.</param>
        /// <param name="displayedName">The displayed name of the link.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter AppendLink(this IWriter writer, string id, string? displayedName = null) =>
            writer.Context.Items.TryGetValue(id, out DocItem item)
            ? writer.AppendLink(item, displayedName)
            : writer.AppendUrl(writer.Context.GetUrl(id), displayedName ?? id.Substring(2), id.Substring(2));

        /// <summary>
        /// Append an link to an <see cref="INamedElement"/> in the markdown format.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to use.</param>
        /// <param name="item">The <see cref="DocItem"/> parent of the element, to get generic information if needed.</param>
        /// <param name="element">The <see cref="INamedElement"/> to link to.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
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
                    TypeKind.TypeParameter => item.TryGetTypeParameterDocItem(type.Name, out TypeParameterDocItem? typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(type.Name),
                    TypeKind.Dynamic => writer.AppendUrl("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic", "dynamic"),
                    TypeKind.Tuple when type is TupleType tupleType => HandleTupleType(tupleType),
                    TypeKind.Unknown => writer.AppendLink("T:" + type.FullName),
                    _ when type is ParameterizedType genericType => HandleParameterizedType(genericType),
                    _ => writer.AppendLink(type.GetDefinition().GetIdString())
                },
                IMember member => writer.AppendLink(member.MemberDefinition.GetIdString(), _nameAmbience.ConvertSymbol(member).Replace("?", string.Empty)),
                IEntity entity => writer.AppendLink(entity.GetIdString(), _nameAmbience.ConvertSymbol(entity).Replace("?", string.Empty)),
                _ => writer.Append(element.FullName)
            };
        }

        /// <summary>
        /// Ensures that the given <see cref="IWriter"/> ends with a line break and call <see cref="IWriter.AppendLine"/> if it's not the case.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to check.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter EnsureLineStart(this IWriter writer) =>
            writer.Length > 0 && (!writer.EndsWith(Environment.NewLine) || (writer.GetDisplayAsSingleLine() && !writer.EndsWith("<br/>")))
            ? writer.AppendLine()
            : writer;

        /// <summary>
        /// Calls <see cref="EnsureLineStart(IWriter)"/> and <see cref="IWriter.AppendLine"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to write to.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter EnsureLineStartAndAppendLine(this IWriter writer) => writer
            .EnsureLineStart()
            .AppendLine();

        /// <summary>
        /// Appends a <see cref="XElement"/> decorating the <see cref="IWriter"/> with a <see cref="MarkdownWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to use.</param>
        /// <param name="element">The <see cref="XElement"/> to write.</param>
        /// <returns>The given <see cref="IWriter"/>.</returns>
        public static IWriter AppendAsMarkdown(this IWriter writer, XElement? element)
        {
            new MarkdownWriter(writer)
                .SetIgnoreLineBreakLine(element?.GetIgnoreLineBreak())
                .Append(element);

            return writer.TrimEnd(Environment.NewLine, "<br/>", " ");
        }

        /// <summary>
        /// Decorates the given <see cref="IWriter"/> with a <see cref="PrefixedWriter"/> to prefix every new line with the given prefix.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to decorate.</param>
        /// <param name="prefix">The string to prefix every new line with.</param>
        /// <returns>The decorated <see cref="IWriter"/>.</returns>
        public static IWriter ToPrefixedWriter(this IWriter writer, string prefix) => new PrefixedWriter(writer, prefix);

        /// <summary>
        /// Decorates the given <see cref="IWriter"/> with a <see cref="OverrideWriter"/> to override its setting in a given scope.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to decorate.</param>
        /// <returns>The decorated <see cref="IWriter"/>.</returns>
        public static IWriter ToOverrideWriter(this IWriter writer) => new OverrideWriter(writer);
    }
}
