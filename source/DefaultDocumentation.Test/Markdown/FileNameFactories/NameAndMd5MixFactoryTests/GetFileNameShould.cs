using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.NameAndMd5MixFactoryTests;

public sealed class GetFileNameShould : BaseFileNameFactoryTester<NameAndMd5MixFactory>
{
    [Fact]
    public void ReturnLongNameWhenNotEntityDocItem() => Test(AssemblyInfo.NamespaceDocItem, $"{AssemblyInfo.NamespaceDocItem.GetLongName()}.md");

    [Fact]
    public void ReturnLongNameWhenNoParameterized() => Test(AssemblyInfo.FieldDocItem, $"{AssemblyInfo.FieldDocItem.GetLongName()}.md");

    [Fact]
    public void ReturnLongNameWhenNoParameter() => Test(AssemblyInfo.PropertyDocItem, $"{AssemblyInfo.PropertyDocItem.GetLongName()}.md");

    [Fact]
    public void ReturnLongNameAndMd5WhenParameters() => Test(AssemblyInfo.MethodWithParameterDocItem, "AssemblyInfo.MethodWithParameter.5EBN351WOG79CZJJQ2Y6P5UP3.md");
}
