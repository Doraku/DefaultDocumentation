using System;
using System.Collections.Generic;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Helper
{
    internal static class DocItemExtension
    {
        public static bool TryGetTypeParameterDocItem(this DocItem item, string name, out TypeParameterDocItem typeParameterDocItem)
        {
            typeParameterDocItem = null;
            while (item != null && typeParameterDocItem == null)
            {
                if (item is ITypeParameterizedDocItem typeParameters)
                {
                    typeParameterDocItem = Array.Find(typeParameters.TypeParameters, i => i.TypeParameter.Name == name);
                }

                item = item.Parent;
            }

            return typeParameterDocItem != null;
        }

        public static bool TryGetParameterDocItem(this DocItem item, string name, out ParameterDocItem parameterDocItem)
        {
            parameterDocItem = null;
            while (item != null && parameterDocItem == null)
            {
                if (item is IParameterizedDocItem typeParameters)
                {
                    parameterDocItem = Array.Find(typeParameters.Parameters, i => i.Parameter.Name == name);
                }

                item = item.Parent;
            }

            return parameterDocItem != null;
        }

        public static IEnumerable<DocItem> GetParents(this DocItem item)
        {
            Stack<DocItem> parents = new();
            for (DocItem parent = item?.Parent; parent != null; parent = parent.Parent)
            {
                parents.Push(parent);
            }

            return parents;
        }
    }
}
