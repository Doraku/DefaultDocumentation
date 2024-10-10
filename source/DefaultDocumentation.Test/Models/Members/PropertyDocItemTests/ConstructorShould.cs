using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.PropertyDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new PropertyDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenEventIsNull()
    {
        Check.ThatCode(() => new PropertyDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
