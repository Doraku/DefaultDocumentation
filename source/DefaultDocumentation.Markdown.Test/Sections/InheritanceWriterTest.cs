using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class InheritanceWriterTest : ASectionWriterTest<InheritanceWriter>
    {
        private struct Struct
        { }

        private class Class
        { }

        [Fact]
        public void Name_should_be_Inheritance() => Check.That(Name).IsEqualTo("Inheritance");

        [Fact]
        public void Write_should_not_write_When_not_TypeDocItem() => Test(
            new AssemblyDocItem("dummy", "dummy", null),
            string.Empty);

        [Fact]
        public void Write_should_not_write_When_StructDocItem() => Test(
            new StructDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(InheritanceWriterTest).FullName}.Struct"), null),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(InheritanceWriterTest).FullName}.Class"), null),
            "Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Class");


        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(InheritanceWriterTest).FullName}.Class"), null),
            w => w.Append("pouet"),
@"pouet

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Class");
    }
}
