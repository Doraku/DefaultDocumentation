using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.FieldDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new FieldDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenFieldIsNull()
    {
        Check.ThatCode(() => new FieldDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
