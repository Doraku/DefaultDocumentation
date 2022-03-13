using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models
{
    public sealed class DocItemTest
    {
        [Fact]
        public void DocItem_Should_throw_When_fullName_is_null() => Check.ThatCode(() => new AssemblyDocItem(null, string.Empty, null)).Throws<ArgumentNullException>();
    }
}
