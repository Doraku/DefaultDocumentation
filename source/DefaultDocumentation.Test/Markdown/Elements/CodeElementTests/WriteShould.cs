using System;
using System.IO;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.CodeElementTests;

public sealed class WriteShould : BaseElementTester<CodeElement>
{
    public const string SingleRegion =
@"namespace Code
{
    #region Foo
    public class TestClass
    {
        public TestClass()
        {
        }
    }
    #endregion
}";

    public const string SingleRegionFoo =
@"public class TestClass
{
    public TestClass()
    {
    }
}";

    public const string DoubleRegion =
@"namespace Code
{
    #region Foo
    public class TestClass
    {
        #region The Bar Region
        public TestClass()
        {
        }
        #endregion
    }
    #endregion
}";
    public const string DoubleRegionTheBarRegion =
@"public TestClass()
{
}";
    public const string DoubleRegionFoo =
@"public class TestClass
{
    #region The Bar Region
    public TestClass()
    {
    }
    #endregion
}";

    public const string RegionInComment =
@"namespace Code
{
    /*
    #region Foo
    */

    #region Foo
    public class TestClass
    {
        /*
        #endregion
        */
        public TestClass()
        {
        }
    }
    #endregion
}";

    public const string RegionInCommentFoo =
@"public class TestClass
{
    /*
    #endregion
    */
    public TestClass()
    {
    }
}";

    public const string NoEndRegion = @"
namespace Code
{
    #region Foo
        public class TestClass
        {
            public TestClass()
            {
            }
        }
}";

    [Fact]
    public void NotWriteWhenDisplayAsSingleLineIsTrue() => Test(
        w => w.SetDisplayAsSingleLine(true),
        new XElement("code", "test"),
        string.Empty);

    [Fact]
    public void Write() => Test(
        new XElement("code", "test"),
@"```csharp
test
```");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        w => w.Append("pouet"),
        new XElement("code", "test"),
@"pouet

```csharp
test
```");

    [Fact]
    public void NotWriteNewlineWhenNotNeeded() => Test(
        w => w
            .Append("pouet")
            .AppendLine(),
        new XElement("code", "test\n"),
@"pouet

```csharp
test
```");

    [Fact]
    public void WriteLanguageWhenAttributePresent() => Test(
        new XElement("code", new XAttribute("language", "pouet"), "test"),
@"```pouet
test
```");

    [Fact]
    public void ThrowWhenSourceDoesNotExist()
    {
        Check
            .ThatCode(() => Test(new XElement("code", new XAttribute("source", "non_existing_file")), null))
            .Throws<FileNotFoundException>();
    }

    [Fact]
    public void WriteFromSourceWhenAttributePresent()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), "test");

        Test(
            new XElement("code", new XAttribute("source", file.Info.FullName)),
@"```csharp
test
```");
    }

    [Fact]
    public void WriteFromRelativeSourceWhenAttributePresent()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), "test");

        Test(
            new XElement("code", new XAttribute("source", file.Info.Name)),
@"```csharp
test
```");
    }

    [Fact]
    public void ThrowWhenRegionDoesNotExist()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), SingleRegion);

        Check
            .ThatCode(() => Test(new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "bar")), null))
            .Throws<InvalidOperationException>();
    }

    [Fact]
    public void WriteRegionWhenAttributePresent()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), SingleRegion);

        Test(
            new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{SingleRegionFoo}
```");
    }

    [Fact]
    public void WriteRegionWhenAttributePresentAndInsideAnOtherRegion()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), DoubleRegion);

        Test(
            new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "The Bar Region")),
$@"```csharp
{DoubleRegionTheBarRegion}
```");
    }

    [Fact]
    public void WriteRegionWhenAttributePresentAndContainsAnOtherRegion()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), DoubleRegion);

        Test(
            new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{DoubleRegionFoo}
```");
    }

    [Fact]
    public void WriteRegionWhenAttributePresentAndInComment()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), RegionInComment);

        Test(
            new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{RegionInCommentFoo}
```");
    }

    [Fact]
    public void ThrowWhenNoEndRegion()
    {
        using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory!.FullName, Guid.NewGuid().ToString("N")), NoEndRegion);

        Check
            .ThatCode(() => Test(new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")), null))
            .Throws<InvalidOperationException>();
    }
}
