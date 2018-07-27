namespace MGU.Core.Tests.Conditions
{
    using Core.Extensions.Is;
    using Xunit;

    public class StringConditionTests
    {
        [Fact]
        public void Should_Return_True_When_Source_Is_Null_Or_Empty_Or_Whitespace()
        {
            string source = null;
            Assert.True(source.Is().NullOrWhitespace);

            source = string.Empty;
            Assert.True(source.Is().NullOrWhitespace);

            source = "   ";
            Assert.True(source.Is().NullOrWhitespace);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Null_Or_Empty_Or_Whitespace()
        {
            const string source = "5";
            Assert.True(source.Is().Not.NullOrWhitespace);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Null_Or_Empty_Or_Whitespace()
        {
            const string source = "5";
            Assert.False(source.Is().NullOrWhitespace);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Null_Or_Empty_Or_Whitespace()
        {
            string source = null;
            Assert.False(source.Is().Not.NullOrWhitespace);

            source = string.Empty;
            Assert.False(source.Is().Not.NullOrWhitespace);

            source = "   ";
            Assert.False(source.Is().Not.NullOrWhitespace);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_In_Other()
        {
            const string other = "This string SOURCE contains.";

            var source = "SOURCE";
            Assert.True(source.Is().In(other));

            source = "source";
            Assert.True(source.Is().In(other, true));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_In_Other()
        {
            const string other = "This string SOURCE contains.";

            var source = "BANANAS";
            Assert.True(source.Is().Not.In(other));

            source = "bananas";
            Assert.True(source.Is().Not.In(other, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_In_Other()
        {
            const string other = "This string SOURCE contains.";

            var source = "BANANAS";
            Assert.False(source.Is().In(other));

            source = "bananas";
            Assert.False(source.Is().In(other, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_In_Other()
        {
            const string other = "This string SOURCE contains.";

            var source = "SOURCE";
            Assert.False(source.Is().Not.In(other));

            source = "source";
            Assert.False(source.Is().Not.In(other, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Null()
        {
            const string other = "Other";

            string source = null;
            Assert.False(source.Is().In(other));
            Assert.False(source.Is().In(other, true));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Null()
        {
            const string other = "Other";

            string source = null;
            Assert.True(source.Is().Not.In(other));
            Assert.True(source.Is().Not.In(other, true));
        }

        [Fact]
        public void Should_Return_False_When_Other_Is_Null()
        {
            const string other = null;

            var source = "SOURCE";
            Assert.False(source.Is().In(other));

            source = "source";
            Assert.False(source.Is().In(other, true));
        }

        [Fact]
        public void Should_Return_True_When_Other_Is_Null()
        {
            const string other = null;

            var source = "SOURCE";
            Assert.True(source.Is().Not.In(other));

            source = "source";
            Assert.True(source.Is().Not.In(other, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_And_Other_Is_Null()
        {
            const string other = null;

            string source = null;
            Assert.False(source.Is().In(other));
            Assert.False(source.Is().In(other, true));
        }

        [Fact]
        public void Should_Return_True_When_Source_And_Other_Is_Null()
        {
            const string other = null;

            string source = null;
            Assert.True(source.Is().Not.In(other));
            Assert.True(source.Is().Not.In(other, true));
        }
    }
}