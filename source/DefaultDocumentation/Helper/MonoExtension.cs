using Mono.Cecil;

namespace DefaultDocumentation.Helper
{
    internal static class MonoExtension
    {
        public static string GetName(this MethodDefinition definition)
        {
            string name = definition.ToString();

            name = name.Substring(name.IndexOf("::") + 2);

            int genericIndex = name.IndexOf('`');
            while (genericIndex >= 0)
            {
                name = name.Replace(name.Substring(genericIndex, name.IndexOf('<', genericIndex) - genericIndex), string.Empty);

                genericIndex = name.IndexOf('`');
            }

            return name.Replace(" modreq(System.Runtime.InteropServices.InAttribute)", string.Empty);
        }
    }
}
