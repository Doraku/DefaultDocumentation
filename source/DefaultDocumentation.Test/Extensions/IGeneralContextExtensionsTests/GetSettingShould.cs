using System;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Extensions.IGeneralContextExtensionsTests;

public sealed class GetSettingShould
{
    [Fact]
    public void ReturnFromSpecificContextWhenNotNull()
    {
        IGeneralContext generalContext = Substitute.For<IGeneralContext>();
        IContext context = Substitute.For<IContext>();

        generalContext.GetSetting<string>("test").Returns("general");
        context.GetSetting<string>("test").Returns("specific");
        generalContext.GetContext(null).Returns(context);

        Check.That(generalContext.GetSetting(default(Type), c => c.GetSetting<string>("test"))).IsEqualTo("specific");
    }

    [Fact]
    public void ReturnFromGeneralContextWhenNull()
    {
        IGeneralContext generalContext = Substitute.For<IGeneralContext>();
        IContext context = Substitute.For<IContext>();

        generalContext.GetSetting<string>("test").Returns("general");
        context.GetSetting<string>("test").Returns(default(string));
        generalContext.GetContext(null).Returns(context);

        Check.That(generalContext.GetSetting(default(Type), c => c.GetSetting<string>("test"))).IsEqualTo("general");
    }
}
