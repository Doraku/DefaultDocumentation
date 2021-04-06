using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;

namespace DefaultDocumentation
{
    public static class CodeRegion
    {
        public static string Get(string fileContent, string region)
        {
            var tree = CSharpSyntaxTree.ParseText(fileContent);

            RegionDirectiveTriviaSyntax start = null;

            var innerRegions = new Stack<RegionDirectiveTriviaSyntax>();
            var root = tree.GetRoot();
            foreach (var trivia in root.DescendantNodes(x => true, true))
            {
                if (trivia is RegionDirectiveTriviaSyntax regionStart)
                {
                    if (start is null)
                    {
                        string regionName = regionStart.EndOfDirectiveToken.LeadingTrivia.ToString();

                        if (region == regionName)
                        {
                            start = regionStart;
                        }
                    }
                    else
                    {
                        innerRegions.Push(regionStart);
                    }
                }

                if (start is null)
                {
                    continue;
                }

                if (trivia is EndRegionDirectiveTriviaSyntax regionEnd)
                {
                    if (innerRegions.Count == 0)
                    {
                        var span = new TextSpan(start.Span.End, regionEnd.Span.Start - start.Span.End);
                        return tree.GetText().GetSubText(span).ToString();
                    }
                    else
                    {
                        innerRegions.Pop();
                    }
                }
            }

            return null;
        }
    }
}
