namespace MGU.Core.Tests.ChainableConditions
{
    using System;
    using Core.Extensions.If;
    using Xunit;

    public class ChainableGuidConditionTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Empty()
        {
            Assert.True(GetEmpty().If().Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Empty()
        {
            Assert.False(GetNotEmpty().If().Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Empty()
        {
            Assert.True(GetNotEmpty().If().Not.Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Empty()
        {
            Assert.False(GetEmpty().If().Not.Empty.Result);
        }

        private Guid GetEmpty()
            => Guid.Empty;

        private Guid GetNotEmpty()
            => Guid.NewGuid();
    }
}