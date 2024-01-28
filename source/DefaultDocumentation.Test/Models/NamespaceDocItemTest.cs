using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models
{
    public sealed class NamespaceDocItemTest
    {
        [Fact]
        public void NamespaceDocItem_Should_throw_When_parent_is_null() => Check.ThatCode(() => new NamespaceDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }
}
