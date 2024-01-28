﻿using System;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation
{
    public sealed class IGeneralContextExtensionsTest
    {
        [Fact]
        public void GetContext_Should_return_GetContext_Type()
        {
            IGeneralContext generalContext = Substitute.For<IGeneralContext>();

            generalContext.GetContext(AssemblyInfo.AssemblyDocItem.GetType()).Returns(generalContext);

            Check.That(generalContext.GetContext(AssemblyInfo.AssemblyDocItem)).IsEqualTo(generalContext);
        }

        [Fact]
        public void GetSetting_Should_return_from_specific_context_When_not_null()
        {
            IGeneralContext generalContext = Substitute.For<IGeneralContext>();
            IContext context = Substitute.For<IContext>();

            generalContext.GetSetting<string>("test").Returns("general");
            context.GetSetting<string>("test").Returns("specific");
            generalContext.GetContext(null).Returns(context);

            Check.That(generalContext.GetSetting(default(Type), c => c.GetSetting<string>("test"))).IsEqualTo("specific");
        }

        [Fact]
        public void GetSetting_Should_return_from_general_context_When_null()
        {
            IGeneralContext generalContext = Substitute.For<IGeneralContext>();
            IContext context = Substitute.For<IContext>();

            generalContext.GetSetting<string>("test").Returns("general");
            context.GetSetting<string>("test").Returns(default(string));
            generalContext.GetContext(null).Returns(context);

            Check.That(generalContext.GetSetting(default(Type), c => c.GetSetting<string>("test"))).IsEqualTo("general");
        }
    }
}
