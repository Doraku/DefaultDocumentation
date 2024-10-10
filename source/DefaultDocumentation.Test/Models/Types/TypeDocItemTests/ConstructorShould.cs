using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Types.TypeDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new ClassDocItem(null!, null!, null)).Throws<ArgumentException>();
    }

    [Fact]
    public void ThrowWhenTypeIsNull()
    {
        Check.ThatCode(() => new ClassDocItem(AssemblyInfo.NamespaceDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
