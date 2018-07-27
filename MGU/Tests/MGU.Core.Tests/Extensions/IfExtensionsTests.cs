namespace MGU.Core.Tests.Extensions
{
    using Core.Extensions.If;
    using Xunit;

    public class IfExtensionsTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Int()
        {
            object source = 5;
            Assert.True(source.If<int>().Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Int()
        {
            var source = new object();
            Assert.False(source.If<int>().Result);
        }
    }
}