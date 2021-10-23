using System;
using System.IO;
using System.Xml.Linq;
using DefaultDocumentation.Writers;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class CodeWriterTest : AElementWriterTest<CodeWriter>
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

        public const string SingleRegion_Foo =
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
        public const string DoubleRegion_The_Bar_Region =
@"public TestClass()
{
}";
        public const string DoubleRegion_Foo =
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

        public const string RegionInComment_Foo =
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
        public void Name_should_be_code() => Check.That(Name).IsEqualTo("code");

        [Fact]
        public void Write_should_not_write_when_DisplayAsSingleLine_is_true() => Test(
            w => w.SetDisplayAsSingleLine(true),
            new XElement("code", "test"),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new XElement("code", "test"),
@"```csharp
test
```");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            w => w.Append("pouet"),
            new XElement("code", "test"),
@"pouet
```csharp
test
```");

        [Fact]
        public void Write_should_not_write_newline_When_not_needed() => Test(
            w => w
                .Append("pouet")
                .AppendLine(),
            new XElement("code", "test\n"),
@"pouet
```csharp
test
```");

        [Fact]
        public void Write_should_write_language_When_attribute_present() => Test(
            new XElement("code", new XAttribute("language", "pouet"), "test"),
@"```pouet
test
```");

        [Fact]
        public void Write_should_throw_When_source_does_not_exist()
        {
            Check
                .ThatCode(() => Test(new XElement("code", new XAttribute("source", "non_existing_file")), null))
                .Throws<FileNotFoundException>();
        }

        [Fact]
        public void Write_should_write_from_source_When_attribute_present()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), "test");

            Test(
                new XElement("code", new XAttribute("source", file.Info.FullName)),
@"```csharp
test
```");
        }

        [Fact]
        public void Write_should_write_from_relative_source_When_attribute_present()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), "test");

            Test(
                new XElement("code", new XAttribute("source", file.Info.Name)),
@"```csharp
test
```");
        }

        [Fact]
        public void Write_should_throw_When_region_does_not_exist()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), SingleRegion);

            Check
                .ThatCode(() => Test(new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "bar")), null))
                .Throws<InvalidOperationException>();
        }

        [Fact]
        public void Write_should_write_region_When_attribute_present()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), SingleRegion);

            Test(
                new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{SingleRegion_Foo}
```");
        }

        [Fact]
        public void Write_should_write_region_When_attribute_present_and_inside_an_other_region()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), DoubleRegion);

            Test(
                new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "The Bar Region")),
$@"```csharp
{DoubleRegion_The_Bar_Region}
```");
        }

        [Fact]
        public void Write_should_write_region_When_attribute_present_and_contains_an_other_region()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), DoubleRegion);

            Test(
                new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{DoubleRegion_Foo}
```");
        }

        [Fact]
        public void Write_should_write_region_When_attribute_present_and_in_comment()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), RegionInComment);

            Test(
                new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")),
$@"```csharp
{RegionInComment_Foo}
```");
        }

        [Fact]
        public void Write_should_throw_When_no_end_region()
        {
            using TempFile file = new(Path.Combine(_settings.Value.ProjectDirectory.FullName, Guid.NewGuid().ToString("N")), NoEndRegion);

            Check
                .ThatCode(() => Test(new XElement("code", new XAttribute("source", file.Info.FullName), new XAttribute("region", "Foo")), null))
                .Throws<InvalidOperationException>();
        }
    }
}
