using DefaultDocumentation.Markdown.FileNameFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public sealed class NameAndMd5MixFactoryTest : AFileNameFactoryTest<NameAndMd5MixFactory>
    {
        [Fact]
        public void Name_Should_return_FullName() => Check.That(Name).IsEqualTo("NameAndMd5Mix");

        [Fact]
        public void GetFileName_Should_return_LongName_When_not_EntityDocItem() => Test(AssemblyInfo.NamespaceDocItem, $"{AssemblyInfo.NamespaceDocItem.GetLongName()}.md");

        [Fact]
        public void GetFileName_Should_return_LongName_When_no_parameterized() => Test(AssemblyInfo.FieldDocItem, $"{AssemblyInfo.FieldDocItem.GetLongName()}.md");

        [Fact]
        public void GetFileName_Should_return_LongName_When_no_parameter() => Test(AssemblyInfo.PropertyDocItem, $"{AssemblyInfo.PropertyDocItem.GetLongName()}.md");

        [Fact]
        public void GetFileName_Should_return_LongName_and_Md5_When_parameters() => Test(AssemblyInfo.MethodWithParameterDocItem, "AssemblyInfo.MethodWithParameter.5EBN351WOG79CZJJQ2Y6P5UP3.md");
    }
}
