using DefaultDocumentation.Api;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Extensions
{
    public sealed class IWriterExtensionTest
    {
        [Fact]
        public void GetFromContext_Should_return_from_specific_context_When_not_null()
        {
            IWriter writer = Substitute.For<IWriter>();
            IGeneralContext generalContext = Substitute.For<IGeneralContext>();
            IContext context = Substitute.For<IContext>();

            writer.Context.Returns(generalContext);
            generalContext.GetSetting<string>("test").Returns("general");
            context.GetSetting<string>("test").Returns("specific");
            generalContext.GetContext(null).Returns(context);

            Check.That(writer.GetFromContext(null, c => c.GetSetting<string>("test"))).IsEqualTo("specific");
        }

        [Fact]
        public void GetFromContext_Should_return_from_general_context_When_null()
        {
            IWriter writer = Substitute.For<IWriter>();
            IGeneralContext generalContext = Substitute.For<IGeneralContext>();
            IContext context = Substitute.For<IContext>();

            writer.Context.Returns(generalContext);
            generalContext.GetSetting<string>("test").Returns("general");
            context.GetSetting<string>("test").Returns(default(string));
            generalContext.GetContext(null).Returns(context);

            Check.That(writer.GetFromContext(null, c => c.GetSetting<string>("test"))).IsEqualTo("general");
        }
    }
}
