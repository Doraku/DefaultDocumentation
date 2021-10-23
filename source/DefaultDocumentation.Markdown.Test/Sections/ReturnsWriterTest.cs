﻿using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ReturnsWriterTest : ASectionWriterTest<ReturnsWriter>
    {
        private delegate void VoidDummyDelegate();

        private delegate int DummyDelegate();

        private static int DummyMethod() => 42;

        [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
        public static int operator +(ReturnsWriterTest _, int __) => 42;

        [Fact]
        public void Name_should_be_returns() => Check.That(Name).IsEqualTo("returns");

        [Fact]
        public void Write_should_not_write_When_not_correct_DocItem() => Test(
            default(DocItem),
            string.Empty);

        [Fact]
        public void Write_should_not_write_When_returns_void() => Test(
            new DelegateDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ReturnsWriterTest).FullName}.{nameof(VoidDummyDelegate)}"), null),
            string.Empty);

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
            new DelegateDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ReturnsWriterTest).FullName}.{nameof(DummyDelegate)}"), null),
@"#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ReturnsWriterTest).FullName}.{nameof(DummyMethod)}"), null),
@"#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            new OperatorDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ReturnsWriterTest).FullName}.op_Addition({typeof(ReturnsWriterTest).FullName},System.Int32)"), null),
@"#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_present() => Test(
            new DelegateDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ReturnsWriterTest).FullName}.{nameof(DummyDelegate)}"), new XElement("doc", new XElement("returns", "test"))),
@"#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new DelegateDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ReturnsWriterTest).FullName}.{nameof(DummyDelegate)}"), null),
            w => w.Append("pouet"),
@"pouet

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");
    }
}
