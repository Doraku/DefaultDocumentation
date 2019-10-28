using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class MethodItem : AGenericDocItem, IParameterDocItem, IReturnDocItem
    {
        public const string Id = "M:";

        public override string Header => "Methods";
        public override string Title => "method";

        public MethodDefinition Method { get; }

        public ReturnItem Return { get; }

        public ParameterItem[] Parameters { get; }

        public MethodItem(AMemberItem parent, XElement item)
            : base(parent, GetMethodName(item, parent), item)
        {
            TypeDefinition parentType = (parent as TypeItem).Type;
            string methodName =  item.GetFullName().Substring(parent.Element.GetFullName().Length + 1).Replace('#', '.').Replace('@', '&');

            Method = GetMethodDefinition(item, parent, parentType.Methods);

            Return = new ReturnItem(this, item.GetReturns() ?? new XElement("returns"));
            Parameters = item.GetParameters().Select(e => new ParameterItem(this, e)).ToArray();
        }

        private static MethodDefinition GetMethodDefinition(XElement element, AMemberItem parent, IEnumerable<MethodDefinition> methods)
        {
            string methodName = element.GetFullName().Substring(parent.Element.GetFullName().Length + 1)
                .Replace('#', '.')
                .Replace('@', '&')
                .Replace('{', '<')
                .Replace('}', '>');

            int parametersIndex = methodName.IndexOf('(');
            if (parametersIndex < 0)
            {
                parametersIndex = methodName.Length;
                methodName += "()";
            }

            int genericsCount = 0;
            int genericsIndex = methodName.IndexOf('`');
            if (genericsIndex > 0 && genericsIndex < parametersIndex)
            {
                genericsCount = int.Parse(methodName.Substring(genericsIndex, parametersIndex - genericsIndex).Trim('`'));
                methodName = methodName.Substring(0, genericsIndex) + methodName.Substring(parametersIndex);
            }

            string[] methodGenerics = GetGenericNames(element).ToArray();
            for (int i = 0; i < methodGenerics.Length; ++i)
            {
                methodName = methodName.Replace($"``{i}", methodGenerics[i]);
            }

            GenericItem[] typeGenerics = (parent as TypeItem)?.Generics;
            for (int i = 0; i < typeGenerics.Length; ++i)
            {
                methodName = methodName.Replace($"`{i}", typeGenerics[i].Name);
            }

            return methods.First(m => m.GetName() == methodName && m.GenericParameters.Count == genericsCount);
        }

        private static void CleanParameters(string[] generics, GenericItem[] parentGenerics, string[] parameters)
        {
            for (int i = 0; i < parameters.Length; ++i)
            {
                ref string parameter = ref parameters[i];

                bool isArray = parameter.EndsWith("[]");
                parameter = parameter.Trim(']', '[').Replace("@", string.Empty);

                if (parameter.StartsWith("``"))
                {
                    int index = int.Parse(parameter.Substring(2));
                    parameter = index < generics.Length ? generics[index] : $"T{index}";
                }
                else if (parameter.StartsWith("`"))
                {
                    int index = int.Parse(parameter.Substring(1));
                    parameter = index < parentGenerics.Length ? parentGenerics[index].Name : $"T{index}";
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

        public static string GetMethodName(XElement item, AMemberItem parent)
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

                CleanParameters(GetGenericNames(item).ToArray(), (parent as TypeItem)?.Generics, parameters);

                name = $"{name.Substring(0, parametersIndex)}({string.Join(", ", parameters)})";
            }

            return name;
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Method.IsStatic)
            {
                writer.Write("static ");
            }
            writer.Write(Return.IsVoid ? "void" : Return.Type.FullName);
            writer.WriteLine($" {Parent.Name}({string.Join(", ", Parameters.Select(p => p.Signature))});");
            writer.WriteLine("```");

            if (Generics.Length > 0)
            {
                writer.WriteLine($"### {Generics[0].Header}");

                foreach (GenericItem parameter in Generics)
                {
                    parameter.Write(converter, writer);
                    writer.Break();
                }
            }

            if (Parameters.Length > 0)
            {
                writer.WriteLine($"### {Parameters[0].Header}");

                foreach (ParameterItem parameter in Parameters)
                {
                    parameter.Write(converter, writer);
                    writer.Break();
                }
            }

            Return.Write(converter, writer);

            base.Write(converter, writer);
        }
    }
}
