using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.NamespaceDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new NamespaceDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }
}
