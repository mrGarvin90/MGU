namespace MGU.Core.Tests.Conditions
{
    using System.Collections.Generic;
    using Core.Extensions.Is;
    using Interfaces.Conditions.Nullable;
    using TestObjects;
    using Xunit;

    public class ConditionTests
    {
        private static EqualityTestObject EqualityTestObjectNotInCollection { get; } = EqualityTestObject.New("str", 7);

        private static TestObject TestObjectNotInCollection { get; } = TestObject.New("str", 7);

        private static IEnumerable<EqualityTestObject> EqualityTestObjectCollection => new[] {EqualityTestObject.New(), EqualityTestObject.New("str", 3), EqualityTestObject.Default(), null};

        private static IEnumerable<TestObject> TestObjectCollection => new[] {TestObject.New(), TestObject.New("str", 3), TestObject.Default(), null};

        private static TestObjectEqualityComparer TestObjectEqualityComparer => new TestObjectEqualityComparer();

        [Fact]
        public void Should_Return_True_When_Source_Is_Null()
        {
            object source = null;
            Assert.True(source.Is().Null);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Null()
        {
            var source = new object();
            Assert.True(source.Is().Not.Null);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Null()
        {
            var source = new object();
            Assert.False(source.Is().Null);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Null()
        {
            object source = null;
            Assert.False(source.Is().Not.Null);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_In_Collection()
        {
            Assert.True(EqualityTestObjectInCollectionCondition().In(EqualityTestObjectCollection));
            Assert.True(NullEqualityTestObjectInCollectionCondition().In(EqualityTestObjectCollection));

            Assert.True(TestObjectInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer));
            Assert.True(NullTestObjectInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_In_Collection()
        {
            Assert.False(EqualityTestObjectNotInCollectionCondition().In(EqualityTestObjectCollection));

            Assert.False(TestObjectNotInCollectionCondition().In(TestObjectCollection, TestObjectEqualityComparer));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_In_Collection()
        {
            Assert.True(EqualityTestObjectNotInCollectionCondition().Not.In(EqualityTestObjectCollection));

            Assert.True(TestObjectNotInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer));
        }
        
        [Fact]
        public void Should_Return_False_When_Source_Is_In_Collection()
        {
            Assert.False(EqualityTestObjectInCollectionCondition().Not.In(EqualityTestObjectCollection));
            Assert.False(NullEqualityTestObjectInCollectionCondition().Not.In(EqualityTestObjectCollection));

            Assert.False(TestObjectInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer));
            Assert.False(NullTestObjectInCollectionCondition().Not.In(TestObjectCollection, TestObjectEqualityComparer));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_In_Collection_And_No_EqualityComparer_Is_Provided()
        {
            Assert.False(TestObjectInCollectionCondition().In(TestObjectCollection));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_In_Collection_And_No_EqualityComparer_Is_Provided()
        {
            Assert.True(TestObjectNotInCollectionCondition().Not.In(TestObjectCollection));
        }

        private static ICondition<EqualityTestObject> EqualityTestObjectInCollectionCondition()
        {
            return EqualityTestObject.Default().Is();
        }

        private static ICondition<EqualityTestObject> EqualityTestObjectNotInCollectionCondition()
        {
            return EqualityTestObjectNotInCollection.Is();
        }

        private static ICondition<EqualityTestObject> NullEqualityTestObjectInCollectionCondition()
        {
            return ((EqualityTestObject) null).Is();
        }

        private static ICondition<TestObject> TestObjectInCollectionCondition()
        {
            return TestObject.Default().Is();
        }

        private static ICondition<TestObject> TestObjectNotInCollectionCondition()
        {
            return TestObjectNotInCollection.Is();
        }

        private static ICondition<TestObject> NullTestObjectInCollectionCondition()
        {
            return ((TestObject) null).Is();
        }
    }
}