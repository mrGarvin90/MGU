namespace MGU.Core.Tests.Conditions
{
    using Core.Extensions.Is;
    using Xunit;

    public class BoolConditionTests
    {
        [Fact]
        public void Should_Return_True_When_Source_Is_True()
        {
            var source = true;
            Assert.True(source.Is().True);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_False()
        {
            var source = false;
            Assert.False(source.Is().True);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_False()
        {
            var source = false;
            Assert.True(source.Is().False);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_True()
        {
            var source = true;
            Assert.False(source.Is().False);
        }
    }
}