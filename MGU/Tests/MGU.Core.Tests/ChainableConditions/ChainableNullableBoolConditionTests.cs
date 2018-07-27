namespace MGU.Core.Tests.ChainableConditions
{
    using Core.Extensions.If;
    using Xunit;

    public class ChainableNullableBoolConditionTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_True()
        {
            bool? source = true;
            Assert.True(source.If().True.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_False()
        {
            bool? source = false;
            Assert.False(source.If().True.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_False()
        {
            bool? source = false;
            Assert.True(source.If().False.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_True()
        {
            bool? source = true;
            Assert.False(source.If().False.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Null()
        {
            bool? source = null;
            Assert.False(source.If().True.Result);
            Assert.False(source.If().False.Result);
        }
    }
}