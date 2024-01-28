﻿using System.IO;
using DefaultDocumentation;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;

namespace ICSharpCode.Decompiler.TypeSystem
{
    /// <summary>
    /// Provides extension methods on the <see cref="ISymbol"/> type.
    /// </summary>
    public static class ISymbolExtensions
    {
        /// <summary>
        /// Converts a <see cref="ISymbol"/> into its string representation using the provided <see cref="CSharpAmbience"/>.
        /// </summary>
        /// <param name="symbol">The symbol to convert into its string representation.</param>
        /// <param name="ambience">The <see cref="CSharpAmbience"/> to use.</param>
        /// <returns></returns>
        public static string ToString(this ISymbol symbol, CSharpAmbience ambience)
        {
            ArgumentNullException.ThrowIfNull(symbol);
            ArgumentNullException.ThrowIfNull(ambience);

            using StringWriter writer = new();

            ambience.ConvertSymbol(symbol, TokenWriter.InsertRequiredSpaces(new TextWriterTokenWriter(writer)), FormattingOptionsFactory.CreateEmpty());

            return writer.ToString();
        }
    }
}
