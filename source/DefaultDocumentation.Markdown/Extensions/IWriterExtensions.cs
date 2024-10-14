using System;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Markdown.Writers;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation.Api;

/// <summary>
/// Provides extension methods on the <see cref="IWriter"/> type.
/// </summary>
public static class IWriterExtensions
{
    private static readonly CSharpAmbience _nameAmbience = new()
    {
        ConversionFlags =
            ConversionFlags.ShowParameterList
            | ConversionFlags.ShowTypeParameterList
    };

    private const string _currentItemKey = "Markdown.CurrentItem";
    private const string _displayAsSingleLineKey = "Markdown.DisplayAsSingleLine";
    private const string _handleLineBreakKey = "Markdown.HandleLineBreak";
    private const string _renderAsRawKey = "Markdown.RenderAsRaw";
    private const string _urlFormatKey = "Markdown.UrlFormat";

    /// <summary>
    /// Gets the current item that is being processed by this <see cref="IWriter"/>.
    /// It can be different from the <see cref="IPageContext.DocItem"/> when inlining child documentation in its parent page.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to get the current item.</param>
    /// <returns>The <see cref="DocItem"/> for which the documentation is being generated.</returns>
    public static DocItem GetCurrentItem(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Context[_currentItemKey] as DocItem ?? writer.Context.DocItem;
    }

    /// <summary>
    /// Sets the current item that is being processed by this <see cref="IWriter"/>.
    /// It can be different from the <see cref="IPageContext.DocItem"/> when inlining child documentation in its parent page.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to set the current item.</param>
    /// <param name="value">The <see cref="DocItem"/> for which the documentation is being generated.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter SetCurrentItem(this IWriter writer, DocItem value)
    {
        writer.ThrowIfNull();
        value.ThrowIfNull();

        writer.Context[_currentItemKey] = value;

        return writer;
    }

    /// <summary>
    /// Gets whether all futur data appended to the given <see cref="IWriter"/> should stay on the same line (usefull for table).
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
    /// <returns>Whether all futur data to happend should stay on the same line.</returns>
    public static bool GetDisplayAsSingleLine(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Context[_displayAsSingleLineKey] as bool? ?? false;
    }

    /// <summary>
    /// Sets whether all futur data appended to the given <see cref="IWriter"/> should stay on the same line (usefull for table).
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
    /// <param name="value">Whether all futur data to happend should stay on the same line.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter SetDisplayAsSingleLine(this IWriter writer, bool? value)
    {
        writer.ThrowIfNull();

        writer.Context[_displayAsSingleLineKey] = value;

        return writer;
    }

    /// <summary>
    /// Gets whether line break in the xml documentation should be handled in the generated markdown.
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
    /// <returns>Whether line break in the xml documentation should be handled in the generated markdown.</returns>
    /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_HandleLineBreak">Markdown.HandleLineBreak</seealso>
    public static bool GetHandleLineBreak(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Context[_handleLineBreakKey] as bool?
            ?? writer.Context.GetSetting(writer.GetCurrentItem(), context => context.GetSetting<bool?>(_handleLineBreakKey)).GetValueOrDefault();
    }

    /// <summary>
    /// Sets whether line break in the xml documentation should be handled in the generated markdown.
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
    /// <param name="value">Whether line break in the xml documentation should be handled in the generated markdown.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_HandleLineBreak">Markdown.HandleLineBreak</seealso>
    public static IWriter SetHandleLineBreak(this IWriter writer, bool? value)
    {
        writer.ThrowIfNull();

        writer.Context[_handleLineBreakKey] = value;

        return writer;
    }

    /// <summary>
    /// Gets whether the writer should append the next strings as is without sanitizing it.
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
    /// <returns>Whether strings should be sanitized.</returns>
    public static bool GetRenderAsRaw(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Context[_renderAsRawKey] as bool? ?? false;
    }

    /// <summary>
    /// Sets whether the writer should append the next strings as is without sanitizing it.
    /// This setting is used by the <see cref="MarkdownWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
    /// <param name="value">Whether strings should be sanitized.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter SetRenderAsRaw(this IWriter writer, bool? value)
    {
        writer.ThrowIfNull();

        writer.Context[_renderAsRawKey] = value;

        return writer;
    }

    /// <summary>
    /// Gets the format that will be used to display urls.<br/>
    /// </summary>
    /// <remarks>
    /// Three arguments will be passed to the format:
    /// <list type="number">
    ///     <item>the displayed text</item>
    ///     <item>the url</item>
    ///     <item>the tooltip to display when overing the link. If null the url will be used</item>
    /// </list>
    /// The default value is <c>[{0}]({1} '{2}')</c>.
    /// </remarks>
    /// <param name="writer">The <see cref="IWriter"/> for which to get this setting.</param>
    /// <returns>Whether line break in the xml documentation should be handled in the generated markdown.</returns>
    /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_UrlFormat">Markdown.UrlFormat</seealso>
    public static string GetUrlFormat(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Context[_urlFormatKey] as string ?? "[{0}]({1} '{2}')";
    }

    /// <summary>
    /// Sets the format that will be used to display url.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> for which to set this setting.</param>
    /// <param name="value">The format to use to display urls.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    /// <seealso href="https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_UrlFormat">Markdown.UrlFormat</seealso>
    public static IWriter SetUrlFormat(this IWriter writer, string? value)
    {
        writer.ThrowIfNull();

        writer.Context[_urlFormatKey] = value;

        return writer;
    }

    /// <summary>
    /// Append a string without sanitizing it for markdown regardless of the current <see cref="GetRenderAsRaw(IWriter)"/> value.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to use.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IDisposable AppendAsRaw(this IWriter writer)
    {
        writer.ThrowIfNull();

        bool? previousRenderAsRaw = writer.GetRenderAsRaw();

        writer.SetRenderAsRaw(true);

        return new DisposableAction(() => writer.SetRenderAsRaw(previousRenderAsRaw));
    }

    /// <summary>
    /// Append an url in the markdown format.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to use.</param>
    /// <param name="url">The url of the link.</param>
    /// <param name="displayedName">The displayed name of the link.</param>
    /// <param name="tooltip">The tooltip of the link.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter AppendUrl(this IWriter writer, string? url, string? displayedName = null, string? tooltip = null)
    {
        writer.ThrowIfNull();

        using (writer.AppendAsRaw())
        {
            if (string.IsNullOrEmpty(url))
            {
                writer.Append((displayedName ?? "").Prettify().SanitizeForMarkdown());
            }
            else
            {
                writer.AppendFormat(
                    writer.GetUrlFormat(),
                    (displayedName ?? url!).Prettify().SanitizeForMarkdown(),
                    url!,
                    (tooltip ?? url!).SanitizeForMarkdown());
            }
        }

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
        writer.ThrowIfNull();
        item.ThrowIfNull();

        return writer.AppendUrl(writer.Context.GetUrl(item), displayedName ?? item.Name, item.FullName);
    }

    /// <summary>
    /// Append an link to an id using <see cref="IGeneralContext.UrlFactories"/> to resolve the url in the markdown format.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to use.</param>
    /// <param name="id">The id to link to.</param>
    /// <param name="displayedName">The displayed name of the link.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter AppendLink(this IWriter writer, string id, string? displayedName = null)
    {
        writer.ThrowIfNull();
        id.ThrowIfNull();

        return writer.Context.Items.TryGetValue(id, out DocItem item)
            ? writer.AppendLink(item, displayedName)
            : writer.AppendUrl(writer.Context.GetUrl(id), displayedName ?? id[2..], id[2..]);
    }

    /// <summary>
    /// Append an link to an <see cref="INamedElement"/> in the markdown format.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to use.</param>
    /// <param name="item">The <see cref="DocItem"/> parent of the element, to get generic information if needed.</param>
    /// <param name="element">The <see cref="INamedElement"/> to link to.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter AppendLink(this IWriter writer, DocItem item, INamedElement element)
    {
        writer.ThrowIfNull();
        item.ThrowIfNull();
        element.ThrowIfNull();

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
            IMember member => writer.AppendLink(member.MemberDefinition.GetIdString(), member.ToString(_nameAmbience).Replace("?", string.Empty)),
            IEntity entity => writer.AppendLink(entity.GetIdString(), entity.ToString(_nameAmbience).Replace("?", string.Empty)),
            _ => writer.Append(element.FullName)
        };
    }

    /// <summary>
    /// Ensures that the given <see cref="IWriter"/> ends with a line break and call <see cref="IWriter.AppendLine"/> if it's not the case.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to check.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter EnsureLineStart(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer.Length > 0 && (!writer.EndsWith(Environment.NewLine) || (writer.GetDisplayAsSingleLine() && !writer.EndsWith("<br/>")))
            ? writer.AppendLine()
            : writer;
    }

    /// <summary>
    /// Calls <see cref="EnsureLineStart(IWriter)"/> and <see cref="IWriter.AppendLine"/>.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to write to.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter EnsureLineStartAndAppendLine(this IWriter writer)
    {
        writer.ThrowIfNull();

        return writer
            .EnsureLineStart()
            .AppendLine();
    }

    /// <summary>
    /// Appends a <see cref="XElement"/> decorating the <see cref="IWriter"/> with a <see cref="MarkdownWriter"/>.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to use.</param>
    /// <param name="element">The <see cref="XElement"/> to write.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter AppendAsMarkdown(this IWriter writer, XElement? element)
    {
        writer.ThrowIfNull();

        new MarkdownWriter(writer)
            .SetHandleLineBreak(element?.GetHandleLineBreak())
            .Append(element);

        return writer.TrimEnd(Environment.NewLine, "<br/>", " ");
    }

    /// <summary>
    /// Decorates the given <see cref="IWriter"/> with a <see cref="PrefixedWriter"/> to prefix every new line with the given prefix.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to decorate.</param>
    /// <param name="prefix">The string to prefix every new line with.</param>
    /// <returns>The decorated <see cref="IWriter"/>.</returns>
    public static IWriter ToPrefixedWriter(this IWriter writer, string prefix)
    {
        writer.ThrowIfNull();
        prefix.ThrowIfNull();

        return new PrefixedWriter(writer, prefix);
    }

    /// <summary>
    /// Decorates the given <see cref="IWriter"/> with a <see cref="OverrideWriter"/> to override its setting in a given scope.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to decorate.</param>
    /// <returns>The decorated <see cref="IWriter"/>.</returns>
    public static IWriter ToOverrideWriter(this IWriter writer)
    {
        writer.ThrowIfNull();

        return new OverrideWriter(writer);
    }
}
