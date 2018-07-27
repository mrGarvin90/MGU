namespace MGU.Core.Tests.ChainableConditions
{
    using Core.Extensions.If;
    using Xunit;

    public class ChainableBoolConditionTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_True()
        {
            var source = true;
            Assert.True(source.If().True.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_False()
        {
            var source = false;
            Assert.False(source.If().True.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_False()
        {
            var source = false;
            Assert.True(source.If().False.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_True()
        {
            var source = true;
            Assert.False(source.If().False.Result);
        }
    }
}