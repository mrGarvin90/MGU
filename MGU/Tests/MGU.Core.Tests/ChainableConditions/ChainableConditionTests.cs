namespace MGU.Core.Tests.ChainableConditions
{
    using System;
    using System.Collections.Generic;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.Options;
    using MGU.Core.Tests.Helpers;
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
        public void Result_Should_Be_True_When_Source_Is_Type()
        {
            Assert.True(GetTypeOption<object, int>(5).Result);
            Assert.True(GetTypeOption<int?, int?>(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Type()
        {
            Assert.False(GetTypeOption<object, int>("Text").Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Type()
        {
            Assert.True(GetNotTypeOption<object, int>("Text").Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Type()
        {
            Assert.False(GetNotTypeOption<object, int>(5).Result);
            Assert.False(GetNotTypeOption<int?, int?>(null).Result);
        }

        [Fact]
        public void Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Type()
        {
            Assert.True(GetTypeOption<object, int>(true, LogicalOperator.And, 5).Result);
            Assert.True(GetTypeOption<object, int>(true, LogicalOperator.Or, 5).Result);

            Assert.True(GetTypeOption<int?, int?>(true, LogicalOperator.And, null).Result);
            Assert.True(GetTypeOption<int?, int?>(true, LogicalOperator.Or, null).Result);

            Assert.True(GetTypeOption<object, int>(false, LogicalOperator.Or, 5).Result);
            Assert.True(GetTypeOption<int?, int?>(false, LogicalOperator.Or, null).Result);

            Assert.False(GetTypeOption<object, int>(false, LogicalOperator.And, 5).Result);
            Assert.False(GetTypeOption<int?, int?>(false, LogicalOperator.And, null).Result);
        }

        [Fact]
        public void Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Not_Type()
        {
            Assert.True(GetTypeOption<object, int>(true, LogicalOperator.Or, "Text").Result);

            Assert.False(GetTypeOption<object, int>(true, LogicalOperator.And, "Text").Result);
            Assert.False(GetTypeOption<object, int>(false, LogicalOperator.And, "Text").Result);
            Assert.False(GetTypeOption<object, int>(false, LogicalOperator.Or, "Text").Result);
        }

        [Fact]
        public void Not_Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Type()
        {
            Assert.False(GetNotTypeOption<object, int>(true, LogicalOperator.And, 5).Result);

            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.Or, 5).Result);

            Assert.False(GetNotTypeOption<int?, int?>(true, LogicalOperator.And, null).Result);
            Assert.True(GetNotTypeOption<int?, int?>(true, LogicalOperator.Or, null).Result);

            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.Or, 5).Result);
            Assert.False(GetNotTypeOption<int?, int?>(false, LogicalOperator.Or, null).Result);

            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.And, 5).Result);
            Assert.False(GetNotTypeOption<int?, int?>(false, LogicalOperator.And, null).Result);
        }

        [Fact]
        public void Not_Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Not_Type()
        {
            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.Or, "Text").Result);

            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.And, "Text").Result);
            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.And, "Text").Result);
            Assert.True(GetNotTypeOption<object, int>(false, LogicalOperator.Or, "Text").Result);
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
        public void Result_Should_Be_True_When_Source_Fulfills_Condition()
        {
            var source = TestObject.New(string.Empty, 42);
            Assert.True(source.If().Fulfills(s => s.IntValue == 42).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Do_Not_Fulfill_Condition()
        {
            var source = TestObject.New(string.Empty, 5);
            Assert.False(source.If().Fulfills(s => s.IntValue == 42).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Do_Not_Fulfill_Condition()
        {
            var source = TestObject.New(string.Empty, 5);
            Assert.True(source.If().DoesNot.Fulfill(s => s.IntValue == 42).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Fulfills_Condition()
        {
            var source = TestObject.New(string.Empty, 42);
            Assert.False(source.If().DoesNot.Fulfill(s => s.IntValue == 42).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException_When_Condition_Is_Not_Valid()
        {
            var exception = Assert.Throws<ConditionEvaluationFailedException>(() => SourceTestObjectCondition().Fulfills(null));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => SourceTestObjectCondition().DoesNot.Fulfill(null));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullSourceTestObjectCondition().Fulfills(s => s.IntValue == 1));
            Assert.NotNull(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullSourceTestObjectCondition().DoesNot.Fulfill(s => s.IntValue == 1));
            Assert.NotNull(exception.InnerException);
        }

        private static ITypeConditionResultOption<TTarget> GetTypeOption<TSource, TTarget>(TSource source)
            => source.If().Type<TTarget>();

        private static ITypeConditionResultOption<TTarget> GetTypeOption<TSource, TTarget>(bool previousConditionResult, LogicalOperator logicalOperator, TSource source)
        {
            switch (logicalOperator)
            {
                case LogicalOperator.And:
                    return source.If().Fulfills(s => previousConditionResult).And.Type<TTarget>();
                case LogicalOperator.Or:
                    return source.If().Fulfills(s => previousConditionResult).Or.Type<TTarget>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicalOperator), logicalOperator, null);
            }
        }

        private static INotTypeConditionResultOption<TSource> GetNotTypeOption<TSource, TTarget>(TSource source)
            => source.If().Not.Type<TTarget>();

        private static INotTypeConditionResultOption<TSource> GetNotTypeOption<TSource, TTarget>(bool previousConditionResult, LogicalOperator logicalOperator, TSource source)
        {
            switch (logicalOperator)
            {
                case LogicalOperator.And:
                    return source.If().Fulfills(s => previousConditionResult).And.Not.Type<TTarget>();
                case LogicalOperator.Or:
                    return source.If().Fulfills(s => previousConditionResult).Or.Not.Type<TTarget>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicalOperator), logicalOperator, null);
            }
        }

        private static IChainableCondition<object> SourceObjectCondition()
            => SourceObject.If();

        private static IChainableCondition<object> NullSourceObjectCondition()
            => ((object)null).If();

        private static IChainableCondition<TestObject> SourceTestObjectCondition()
            => SourceTestObject.If();

        private static IChainableCondition<TestObject> NullSourceTestObjectCondition()
            => ((TestObject)null).If();

        private static IChainableCondition<EqualityTestObject> EqualityTestObjectInCollectionCondition()
            => EqualityTestObject.Default().If();

        private static IChainableCondition<EqualityTestObject> EqualityTestObjectNotInCollectionCondition()
            => EqualityTestObjectNotInCollection.If();

        private static IChainableCondition<EqualityTestObject> NullEqualityTestObjectInCollectionCondition()
            => ((EqualityTestObject)null).If();

        private static IChainableCondition<TestObject> TestObjectInCollectionCondition()
            => TestObject.Default().If();

        private static IChainableCondition<TestObject> TestObjectNotInCollectionCondition()
            => TestObjectNotInCollection.If();

        private static IChainableCondition<TestObject> NullTestObjectInCollectionCondition()
            => ((TestObject)null).If();
    }
}