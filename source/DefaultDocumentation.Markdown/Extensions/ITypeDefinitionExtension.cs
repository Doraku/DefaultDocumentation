using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.TypeSystem
{
    public static class ITypeDefinitionExtension
    {
        public static IEnumerable<ITypeDefinition> GetBaseTypeDefinitions(this ITypeDefinition type) => type.GetAllBaseTypeDefinitions().Reverse().Skip(1);
    }
}
