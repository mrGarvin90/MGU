namespace MGU.Core.Tests.Conditions
{
    using Core.Extensions.Is;
    using Xunit;

    public class NullableBoolConditionTests
    {
        [Fact]
        public void Should_Return_True_When_Source_Is_True()
        {
            bool? source = true;
            Assert.True(source.Is().True);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_False()
        {
            bool? source = false;
            Assert.False(source.Is().True);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_False()
        {
            bool? source = false;
            Assert.True(source.Is().False);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_True()
        {
            bool? source = true;
            Assert.False(source.Is().False);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Null()
        {
            bool? source = null;
            Assert.False(source.Is().True);
            Assert.False(source.Is().False);
        }
    }
}