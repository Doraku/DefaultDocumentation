using System;
using System.Collections;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ImplementSectionTest : ASectionTest<ImplementSection>
    {
        private class Class : IDisposable, IEnumerator
        {
            public object Current { get; }

            public void Dispose()
            {
                throw new NotSupportedException();
            }

            public bool MoveNext()
            {
                throw new NotSupportedException();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
        }

        [Fact]
        public void Name_should_be_Implement() => Check.That(Name).IsEqualTo("Implement");

        [Fact]
        public void Write_should_not_write_When_no_implementation() => Test(
            new AssemblyDocItem("dummy", "dummy", null),
            string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ImplementSectionTest).FullName}.Class"), null),
            "Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ImplementSectionTest).FullName}.Class"), null),
            w => w.Append("pouet"),
@"pouet

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ImplementSectionTest).FullName}.Class.Dispose"), null),
            "Implements [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose')");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            new PropertyDocItem(null, AssemblyInfo.Get<IProperty>($"P:{typeof(ImplementSectionTest).FullName}.Class.Current"), null),
            "Implements [Current](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.Current 'System.Collections.IEnumerator.Current')");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            new ExplicitInterfaceImplementationDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ImplementSectionTest).FullName}.Class.System#Collections#IEnumerator#Reset"), null),
            "Implements [Reset()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.Reset 'System.Collections.IEnumerator.Reset')");
    }
}
