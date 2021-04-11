using NFluent;
using Xunit;

namespace DefaultDocumentation.Helper
{
    public sealed class CodeRegionTest
    {
        public const string TestCodeWithRegion = @"
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

        public const string TestCodeInner = @"
        public class TestClass
        {
            public TestClass()
            {
            }
        }
    ";

        public const string TestCodeWithDoubleRegion = @"
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
        public const string TestCodeDoubleInner = @"
            public TestClass()
            {
            }
    ";
        public const string TestCodeWithDoubleOuter = @"
        public class TestClass
        {
    #region The Bar Region
            public TestClass()
            {
            }
    #endregion
        }
    ";

        [Fact]
        public void VerifyRegionCanBeFound()
        {
            string result = CodeRegion.Extract(TestCodeWithRegion, "Foo");

            Check.That(result).IsNotNull();
            Check.That(result).IsEqualTo(TestCodeInner);
        }

        [Fact]
        public void VerifyRegionCannotBeFound()
        {
            string result = CodeRegion.Extract(TestCodeWithRegion, "Foo2");

            Check.That(result).IsNull();
        }

        [Fact]
        public void VerifyRegionCanBeFoundInsideOtherRegion()
        {
            string result = CodeRegion.Extract(TestCodeWithDoubleRegion, "The Bar Region");

            Check.That(result).IsNotNull();
            Check.That(result).IsEqualTo(TestCodeDoubleInner);
        }

        [Fact]
        public void VerifyRegionCanBeFoundContainingOtherRegion()
        {
            string result = CodeRegion.Extract(TestCodeWithDoubleRegion, "Foo");

            Check.That(result).IsNotNull();
            Check.That(result).IsEqualTo(TestCodeWithDoubleOuter);
        }
    }
}
