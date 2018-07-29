namespace MGU.Core.Tests.ChainableConditions
{
    using System.Collections.Generic;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Interfaces.ChainableConditions.Nullable;
    using TestObjects;
    using Xunit;

    public class ChainableConditionTests
    {
        private static object SourceObject { get; } = new object();

        private static object OtherObjectEqualToSourceObject { get; } = SourceObject;

        private static object SourceIntObject { get; } = 5;

        private static TestObject SourceTestObject { get; } = TestObject.Default();

        private static TestObject OtherTestObjectEqualToSourceTestObject { get; } = TestObject.Default();

        private static EqualityTestObject EqualityTestObjectNotInCollection { get; } = EqualityTestObject.New("str", 7);

        private static TestObject TestObjectNotInCollection { get; } = TestObject.New("str", 7);

        private static IEnumerable<EqualityTestObject> EqualityTestObjectCollection => new[] { EqualityTestObject.New(), EqualityTestObject.New("str", 3), EqualityTestObject.Default(), null };

        private static IEnumerable<TestObject> TestObjectCollection => new[] { TestObject.New(), TestObject.New("str", 3), TestObject.Default(), null };

        private static TestObjectEqualityComparer TestObjectEqualityComparer => new TestObjectEqualityComparer();

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Null()
        {
            Assert.True(NullSourceObjectCondition().Null.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Null()
        {
            Assert.False(SourceObjectCondition().Null.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Null()
        {
            Assert.True(SourceObjectCondition().Not.Null.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Null()
        {
            Assert.False(NullSourceObjectCondition().Not.Null.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Are_Equal()
        {
            Assert.True(SourceObjectCondition().EqualTo(OtherObjectEqualToSourceObject).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Are_Not_Equal()
        {
            Assert.False(SourceObjectCondition().EqualTo(SourceIntObject).Result);
            Assert.False(SourceObjectCondition().EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Are_Not_Equal()
        {
            Assert.True(SourceObjectCondition().Not.EqualTo(SourceIntObject).Result);
            Assert.True(SourceObjectCondition().Not.EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Are_Equal()
        {
            Assert.False(SourceObjectCondition().Not.EqualTo(OtherObjectEqualToSourceObject).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Are_Equal_And_No_EqualityComparer_Is_Provided()
        {
            Assert.False(SourceTestObjectCondition().EqualTo(OtherTestObjectEqualToSourceTestObject).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Are_Equal_And_No_EqualityComparer_Is_Provided()
        {
            Assert.True(SourceTestObjectCondition().Not.EqualTo(OtherTestObjectEqualToSourceTestObject).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Int()
        {
            Assert.True(SourceIntObjectCondition().Type<int>().Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Int()
        {
            Assert.False(SourceObjectCondition().Type<int>().Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Int()
        {
            Assert.True(SourceObjectCondition().Not.Type<int>().Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Int()
        {
            Assert.False(SourceIntObjectCondition().Not.Type<int>().Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Collection()
        {
            Assert.True(EqualityTestObjectInCollectionCondition().In(EqualityTestObjectCollection).Result);
            Assert.True(NullEqualityTestObjectInCollectionCondition().In(EqualityTestObjectCollection).Result);

            Assert.True(TestObjectInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer).Result);
            Assert.True(NullTestObjectInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_In_Collection()
        {
            Assert.False(EqualityTestObjectNotInCollectionCondition().In(EqualityTestObjectCollection).Result);

            Assert.False(TestObjectNotInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_In_Collection()
        {
            Assert.True(EqualityTestObjectNotInCollectionCondition().Not.In(EqualityTestObjectCollection).Result);

            Assert.True(TestObjectNotInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Collection()
        {
            Assert.False(EqualityTestObjectInCollectionCondition().Not.In(EqualityTestObjectCollection).Result);
            Assert.False(NullEqualityTestObjectInCollectionCondition().Not.In(EqualityTestObjectCollection).Result);

            Assert.False(TestObjectInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer).Result);
            Assert.False(NullTestObjectInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Collection_And_No_EqualityComparer_Is_Provided()
        {
            Assert.False(TestObjectInCollectionCondition().In(TestObjectCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Collection_And_No_EqualityComparer_Is_Provided()
        {
            Assert.True(TestObjectNotInCollectionCondition().Not.In(TestObjectCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Collection_Is_Null()
        {
            var source = TestObject.Default();
            Assert.False(source.If().In(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Collection_Is_Null()
        {
            var source = TestObject.Default();
            Assert.True(source.If().Not.In(null).Result);
        }

        [Fact]
        public void Result_Should_True_When_Source_Fulfills_Condition()
        {
            Assert.True(NullSourceObjectCondition().Fulfills(s => s == null).Result);
        }

        [Fact]
        public void Result_Should_False_When_Source_Do_Not_Fulfill_Condition()
        {
            Assert.False(NullSourceObjectCondition().Fulfills(s => s != null).Result);
        }

        [Fact]
        public void Result_Should_True_When_Source_Do_Not_Fulfill_Condition()
        {
            Assert.True(NullSourceObjectCondition().DoNot.Fulfill(s => s != null).Result);
        }

        [Fact]
        public void Result_Should_False_When_Source_Fulfills_Condition()
        {
            Assert.False(NullSourceObjectCondition().DoNot.Fulfill(s => s == null).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException_When_Condition_Is_Not_Valid()
        {
            Assert.Throws<ConditionEvaluationFailedException>(() => SourceTestObjectCondition().Fulfills(null));
            Assert.Throws<ConditionEvaluationFailedException>(() => SourceTestObjectCondition().DoNot.Fulfill(null));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullSourceTestObjectCondition().Fulfills(s => s.IntValue == 1));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullSourceTestObjectCondition().DoNot.Fulfill(s => s.IntValue == 1));
        }

        private static IChainableCondition<object> SourceObjectCondition()
        {
            return SourceObject.If();
        }

        private static IChainableCondition<object> NullSourceObjectCondition()
        {
            return ((object)null).If();
        }

        private static IChainableCondition<TestObject> SourceTestObjectCondition()
        {
            return SourceTestObject.If();
        }

        private static IChainableCondition<TestObject> NullSourceTestObjectCondition()
        {
            return ((TestObject)null).If();
        }

        private static IChainableCondition<object> SourceIntObjectCondition()
        {
            return SourceIntObject.If();
        }

        private static IChainableCondition<EqualityTestObject> EqualityTestObjectInCollectionCondition()
        {
            return EqualityTestObject.Default().If();
        }

        private static IChainableCondition<EqualityTestObject> EqualityTestObjectNotInCollectionCondition()
        {
            return EqualityTestObjectNotInCollection.If();
        }

        private static IChainableCondition<EqualityTestObject> NullEqualityTestObjectInCollectionCondition()
        {
            return ((EqualityTestObject)null).If();
        }

        private static IChainableCondition<TestObject> TestObjectInCollectionCondition()
        {
            return TestObject.Default().If();
        }

        private static IChainableCondition<TestObject> TestObjectNotInCollectionCondition()
        {
            return TestObjectNotInCollection.If();
        }

        private static IChainableCondition<TestObject> NullTestObjectInCollectionCondition()
        {
            return ((TestObject)null).If();
        }
    }
}