using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.DocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenFullNameIsNull() => Check.ThatCode(() => new AssemblyDocItem(null!, string.Empty, null)).Throws<ArgumentNullException>();
}
