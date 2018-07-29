namespace MGU.Core.Tests.Couplers
{
    using System.Collections.Generic;
    using Core.Exceptions;
    using Core.Extensions.If;
    using TestObjects;
    using Xunit;

    public class ConditionCouplerTests
    {
        [Fact]
        public void Result_Should_Be_True_With_And()
        {
            var source = EqualityTestObject.Default();

            Assert.True(source.If().Not.Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.True(source.If().Not.Null.And.In(GetEqualityObjectCollectionWithDefault(true)).And.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_And()
        {
            var source = EqualityTestObject.Default();

            Assert.False(source.If().Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.False(source.If().Null.And.Not.Null.Result);
            Assert.False(source.If().Not.Null.And.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.False(source.If().Not.Null.And.In(GetEqualityObjectCollectionWithDefault(true)).And.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
        }

        [Fact]
        public void Result_Should_Be_True_With_Or()
        {
            var source = EqualityTestObject.Default();

            Assert.True(source.If().Not.Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.True(source.If().Not.Null.Or.Null.Result);
            Assert.True(source.If().Null.Or.Not.Null.Result);

            Assert.True(source.If().Not.Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).Or.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
            Assert.True(source.If().Not.Null.Or.Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.True(source.If().Not.Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).Or.Null.Result);
            Assert.True(source.If().Null.Or.In(GetEqualityObjectCollectionWithDefault(false)).Or.Not.Null.Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_Or()
        {
            var source = EqualityTestObject.Default();

            Assert.False(source.If().Null.Or.In(GetEqualityObjectCollectionWithDefault(false)).Result);

            Assert.False(source.If().Null.Or.In(GetEqualityObjectCollectionWithDefault(false)).Or.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
        }

        [Fact]
        public void Result_Should_Be_True_With_And_Or()
        {
            var source = EqualityTestObject.Default();

            Assert.True(source.If().Not.Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Or.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
            Assert.True(source.If().Not.Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Or.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.True(source.If().Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Or.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_And_Or()
        {
            var source = EqualityTestObject.Default();

            Assert.False(source.If().Null.And.In(GetEqualityObjectCollectionWithDefault(false)).Or.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
            Assert.False(source.If().Null.And.In(GetEqualityObjectCollectionWithDefault(true)).Or.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
        }

        [Fact]
        public void Result_Should_Be_True_With_Or_And()
        {
            var source = EqualityTestObject.Default();

            Assert.True(source.If().Not.Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).And.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
            Assert.True(source.If().Null.Or.In(GetEqualityObjectCollectionWithDefault(true)).And.Not.In(GetEqualityObjectCollectionWithDefault(false)).Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_Or_And()
        {
            var source = EqualityTestObject.Default();

            Assert.False(source.If().Null.Or.In(GetEqualityObjectCollectionWithDefault(false)).And.Not.In(GetEqualityObjectCollectionWithDefault(true)).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException()
        {
            IEnumerable<object> source = null;
            Assert.Throws<ConditionEvaluationFailedException>(() => source.If().Count.Is(5));
        }

        private static IEnumerable<EqualityTestObject> GetEqualityObjectCollectionWithDefault(bool withDefault)
        {
            return new[] { EqualityTestObject.New(), EqualityTestObject.New("str", 5), withDefault ? EqualityTestObject.Default() : null };
        }
    }
}