using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.ConstructorDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new ConstructorDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenMethodIsNull()
    {
        Check.ThatCode(() => new ConstructorDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
