using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models
{
    public sealed class DocItemTest
    {
        [Fact]
        public void DocItem_Should_throw_When_fullName_is_null() => Check.ThatCode(() => new AssemblyDocItem(null, null, null)).Throws<ArgumentNullException>();

        [Fact]
        public void DocItem_Should_throw_When_name_is_null() => Check.ThatCode(() => new AssemblyDocItem(string.Empty, null, null)).Throws<ArgumentNullException>();
    }
}
