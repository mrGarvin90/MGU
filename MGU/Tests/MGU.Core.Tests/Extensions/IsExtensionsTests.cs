namespace MGU.Core.Tests.Extensions
{
    using Core.Extensions.Is;
    using Xunit;

    public class IsExtensionsTests
    {
        [Fact]
        public void Should_Return_True_When_Source_And_Other_Are_Equal()
        {
            var source = new object();
            var other = source;
            Assert.True(source.Is(other));

            Assert.True(5.Is(5));
        }

        [Fact]
        public void Should_Return_False_When_Source_And_Other_Are_Not_Equal()
        {
            var source = new object();
            var other = new object();
            Assert.False(source.Is(other));

            Assert.False(5.Is(42));
        }
    }
}