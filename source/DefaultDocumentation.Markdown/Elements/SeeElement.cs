using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class SeeElement : IElement
    {
        public string Name => "see";

        public void Write(IWriter writer, XElement element)
        {
            string? @ref = element.GetCRefAttribute();
            if (@ref is not null)
            {
                writer.AppendLink(@ref, element.Value.NullIfEmpty());
                return;
            }

            @ref = element.GetHRefAttribute();
            if (@ref is not null)
            {
                writer.AppendUrl(@ref, element.Value.NullIfEmpty());
                return;
            }

            @ref = element.GetLangWordAttribute();
            if (@ref is not null)
            {
                writer.AppendUrl(
                    @ref switch
                    {
                        "await" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await",
                        "false" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                        "true" => "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool",
                        _ => $"https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/{@ref}"
                    },
                    element.Value.NullIfEmpty() ?? @ref);
            }
        }
    }
}
