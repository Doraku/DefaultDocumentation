using NFluent;
using Xunit;

namespace DefaultDocumentation.Helper
{
    public sealed class CodeRegionTest
    {
        public const string SingleRegion = @"
namespace Code
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

        public const string SingleRegion_Foo = @"        public class TestClass
        {
            public TestClass()
            {
            }
        }
";

        public const string DoubleRegion = @"
namespace Code
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
        public const string DoubleRegion_The_Bar_Region = @"            public TestClass()
            {
            }
";
        public const string DoubleRegion_Foo = @"        public class TestClass
        {
    #region The Bar Region
            public TestClass()
            {
            }
    #endregion
        }
";

        public const string RegionInComment = @"
namespace Code
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

        public const string RegionInComment_Foo = @"        public class TestClass
        {
    /*
    #endregion
    */
            public TestClass()
            {
            }
        }
";

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

        //[Fact]
        //public void Extract_Should_return_region()
        //{
        //    string result = CodeRegion.Extract(SingleRegion, "Foo");

        //    Check.That(result).IsNotNull();
        //    Check.That(result).IsEqualTo(SingleRegion_Foo);
        //}

        //[Fact]
        //public void Extract_Should_return_null_When_region_not_found()
        //{
        //    string result = CodeRegion.Extract(SingleRegion, "Foo2");

        //    Check.That(result).IsNull();
        //}

        //[Fact]
        //public void Extract_Should_return_region_When_inside_an_other_region()
        //{
        //    string result = CodeRegion.Extract(DoubleRegion, "The Bar Region");

        //    Check.That(result).IsNotNull();
        //    Check.That(result).IsEqualTo(DoubleRegion_The_Bar_Region);
        //}

        //[Fact]
        //public void Extract_Should_return_region_When_contains_an_other_region()
        //{
        //    string result = CodeRegion.Extract(DoubleRegion, "Foo");

        //    Check.That(result).IsNotNull();
        //    Check.That(result).IsEqualTo(DoubleRegion_Foo);
        //}

        //[Fact]
        //public void Extract_Should_return_region_When_in_comment()
        //{
        //    string result = CodeRegion.Extract(RegionInComment, "Foo");

        //    Check.That(result).IsNotNull();
        //    Check.That(result).IsEqualTo(RegionInComment_Foo);
        //}

        //[Fact]
        //public void Extract_Should_return_null_When_no_endregion()
        //{
        //    string result = CodeRegion.Extract(NoEndRegion, "Foo");

        //    Check.That(result).IsNull();
        //}
    }
}
