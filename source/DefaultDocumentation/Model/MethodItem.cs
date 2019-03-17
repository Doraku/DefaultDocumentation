using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class MethodItem : AGenericDocItem, IParameterDocItem, IReturnDocItem
    {
        public const string Id = "M:";

        public override string Header => "Methods";
        public override string Title => "method";

        public ReturnItem Return { get; }

        public ParameterItem[] Parameters { get; }

        public MethodItem(AMemberItem parent, XElement item)
            : base(parent, GetMethodName(item, parent), item)
        {
            XElement returnElement = item.GetReturns();
            Return = returnElement != null ? new ReturnItem(this, returnElement) : null;
            Parameters = item.GetParameters().Select(e => new ParameterItem(this, e)).ToArray();
        }

        private static void CleanParameters(string[] generics, GenericItem[] parentGenerics, string[] parameters)
        {
            for (int i = 0; i < parameters.Length; ++i)
            {
                ref string parameter = ref parameters[i];

                parameter = parameter.Trim('@');

                bool isArray = parameter.EndsWith("[]");
                parameter = parameter.Trim(']', '[');

                if (parameter.StartsWith("``"))
                {
                    parameter = generics[int.Parse(parameter.Substring(2))];
                }
                else if (parameter.StartsWith('`'))
                {
                    parameter = parentGenerics[int.Parse(parameter.Substring(1))].Name;
                }
                else if (parameter.IndexOf('{') >= 0)
                {
                    int genericIndex = parameter.IndexOf('{');

                    string[] innerParameters = ReadParameter(parameter.Substring(genericIndex).Trim('{', '}')).ToArray();

                    CleanParameters(generics, parentGenerics, innerParameters);
                    parameter = $"{parameter.Substring(0, genericIndex)}&lt;{string.Join(", ", innerParameters)}&gt;";
                }

                if (isArray)
                {
                    parameter += "[]";
                }
            }
        }

        private static IEnumerable<string> ReadParameter(string value)
        {
            int startIndex = 0;
            int braceCount = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                switch (value[i])
                {
                    case '{':
                        ++braceCount;
                        break;

                    case '}':
                        --braceCount;
                        break;

                    case ',':
                        if (braceCount == 0)
                        {
                            yield return value.Substring(startIndex, i - startIndex);
                            startIndex = i + 1;
                        }
                        break;
                }
            }

            yield return value.Substring(startIndex);
        }

        private static string GetMethodName(XElement item, AMemberItem parent)
        {
            string name = item.GetFullName();

            name = name.Substring(item.GetNamespace().Length + 3);

            int parametersIndex = name.IndexOf('(');
            if (parametersIndex < 0)
            {
                name += "()";
            }
            else
            {
                string[] parameters = ReadParameter(name.Substring(parametersIndex).Trim('(', ')')).ToArray();

                try
                {
                    CleanParameters(GetGenericNames(item).ToArray(), (parent as TypeItem).Generics, parameters);
                }
                catch
                {
                    throw new Exception($"Error encountered on method {item.GetFullName()}, are you missing comment documentation on some generic types?");
                }

                name = $"{name.Substring(0, parametersIndex)}({string.Join(", ", parameters)})";
            }

            return name;
        }
    }
}
