namespace MGU.Core.Tests.Conditions
{
    using System;
    using Core.Extensions.Is;
    using Xunit;

    public class NullableGuidConditionTests
    {
        [Fact]
        public void Should_Return_True_When_Source_Is_Empty()
        {
            Assert.True(GetEmpty().Is().Empty);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Empty()
        {
            Assert.False(GetNotEmpty().Is().Empty);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Empty()
        {
            Assert.True(GetNotEmpty().Is().Not.Empty);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Empty()
        {
            Assert.False(GetEmpty().Is().Not.Empty);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Null()
        {
            Assert.False(GetNull().Is().Empty);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Null()
        {
            Assert.True(GetNull().Is().Not.Empty);
        }

        private Guid? GetEmpty()
            => Guid.Empty;

        private Guid? GetNotEmpty()
            => Guid.NewGuid();

        private Guid? GetNull()
            => null;
    }
}