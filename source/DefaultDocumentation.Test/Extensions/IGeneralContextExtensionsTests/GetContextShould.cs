using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Extensions.IGeneralContextExtensionsTests;

public sealed class GetContextShould
{
    [Fact]
    public void ReturnGetContextType()
    {
        IGeneralContext generalContext = Substitute.For<IGeneralContext>();

        generalContext.GetContext(AssemblyInfo.AssemblyDocItem.GetType()).Returns(generalContext);

        Check.That(generalContext.GetContext(AssemblyInfo.AssemblyDocItem)).IsEqualTo(generalContext);
    }
}
