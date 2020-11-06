using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Helper
{
    internal static class ITypeDefinitionExtension
    {
        public static IEnumerable<ITypeDefinition> GetBaseTypeDefinitions(this ITypeDefinition type) => type.GetAllBaseTypeDefinitions().Reverse().Skip(1);
    }
}
