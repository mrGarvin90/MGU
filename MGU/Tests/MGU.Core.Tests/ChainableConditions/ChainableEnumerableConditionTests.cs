namespace MGU.Core.Tests.ChainableConditions
{
    using System.Collections.Generic;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Core.Extensions.If.Base;
    using Interfaces.ChainableConditions.Enumerable;
    using TestObjects;
    using Xunit;

    public class ChainableEnumerableConditionTests
    {
        private const int IntValueInSource = 3;

        private const int IntValueNotInSource = 7;

        private static TestObject TestObjectInSource { get; } = TestObject.New("str", 3);

        private static TestObject TestObjectNotInSource { get; } = TestObject.New("str", 7);

        private static int[] SourceArray => new[] { 1, 2, IntValueInSource, 4, 4, 5 };

        private static int[] OtherArray => new[] { 6, 7, 8, 9, 10, 11 };

        private static IEnumerable<int> SourceIEnumerable => SourceArray;

        private static IEnumerable<int> OtherIEnumerable => OtherArray;

        private static List<int> SourceList => new List<int>(SourceArray);

        private static List<int> OtherList => new List<int>(OtherArray);

        private static TestObject[] SourceTestObjects => new[] { TestObject.New(), TestObject.New("str", 3), TestObject.Default() };

        private static TestObject[] OtherTestObjects => new[] { TestObject.New("str", 6), TestObject.Default(), TestObject.New() };

        private static TestObjectEqualityComparer TestObjectEqualityComparer => new TestObjectEqualityComparer();

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Empty()
        {
            Assert.True(ArrayCondition(new int[0]).Empty.Result);

            Assert.True(IEnumerableCondition(new int[0]).Empty.Result);

            Assert.True(ListCondition(new List<int>()).Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Not_Empty()
        {
            Assert.False(ArrayCondition().Empty.Result);

            Assert.False(IEnumerableCondition().Empty.Result);

            Assert.False(ListCondition().Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Not_Empty()
        {
            Assert.True(ArrayCondition().Not.Empty.Result);

            Assert.True(IEnumerableCondition().Not.Empty.Result);

            Assert.True(ListCondition().Not.Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Empty()
        {
            Assert.False(ArrayCondition(new int[0]).Not.Empty.Result);

            Assert.False(IEnumerableCondition(new int[0]).Not.Empty.Result);

            Assert.False(ListCondition(new List<int>()).Not.Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Equal_To_Value()
        {
            Assert.True(ArrayCondition().Count.Is(6).Result);

            Assert.True(IEnumerableCondition().Count.Is(6).Result);

            Assert.True(ListCondition().Count.Is(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Not_Equal_To_Value()
        {
            Assert.False(ArrayCondition().Count.Is(2).Result);

            Assert.False(IEnumerableCondition().Count.Is(2).Result);

            Assert.False(ListCondition().Count.Is(2).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Not_Equal_To_Value()
        {
            Assert.True(ArrayCondition().Count.Is.Not(2).Result);

            Assert.True(IEnumerableCondition().Count.Is.Not(2).Result);

            Assert.True(ListCondition().Count.Is.Not(2).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Equal_To_Value()
        {
            Assert.False(ArrayCondition().Count.Is.Not(6).Result);

            Assert.False(IEnumerableCondition().Count.Is.Not(6).Result);

            Assert.False(ListCondition().Count.Is.Not(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Less_Than_Value()
        {
            Assert.True(ArrayCondition().Count.Is.LessThan(7).Result);

            Assert.True(IEnumerableCondition().Count.Is.LessThan(7).Result);

            Assert.True(ListCondition().Count.Is.LessThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.False(ArrayCondition().Count.Is.LessThan(5).Result);
            Assert.False(ArrayCondition().Count.Is.LessThan(6).Result);

            Assert.False(IEnumerableCondition().Count.Is.LessThan(5).Result);
            Assert.False(IEnumerableCondition().Count.Is.LessThan(6).Result);

            Assert.False(ListCondition().Count.Is.LessThan(5).Result);
            Assert.False(ListCondition().Count.Is.LessThan(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.True(ArrayCondition().Count.Is.LessThanEqualTo(7).Result);
            Assert.True(ArrayCondition().Count.Is.LessThanEqualTo(6).Result);

            Assert.True(IEnumerableCondition().Count.Is.LessThanEqualTo(7).Result);
            Assert.True(IEnumerableCondition().Count.Is.LessThanEqualTo(6).Result);

            Assert.True(ListCondition().Count.Is.LessThanEqualTo(7).Result);
            Assert.True(ListCondition().Count.Is.LessThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Greater_Than_Value()
        {
            Assert.False(ArrayCondition().Count.Is.LessThanEqualTo(5).Result);

            Assert.False(IEnumerableCondition().Count.Is.LessThanEqualTo(5).Result);

            Assert.False(ListCondition().Count.Is.LessThanEqualTo(5).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Greater_Than_Value()
        {
            Assert.True(ArrayCondition().Count.Is.GreaterThan(5).Result);

            Assert.True(IEnumerableCondition().Count.Is.GreaterThan(5).Result);

            Assert.True(ListCondition().Count.Is.GreaterThan(5).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.False(ArrayCondition().Count.Is.GreaterThan(6).Result);
            Assert.False(ArrayCondition().Count.Is.GreaterThan(7).Result);

            Assert.False(IEnumerableCondition().Count.Is.GreaterThan(6).Result);
            Assert.False(IEnumerableCondition().Count.Is.GreaterThan(7).Result);

            Assert.False(ListCondition().Count.Is.GreaterThan(6).Result);
            Assert.False(ListCondition().Count.Is.GreaterThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Greater_Or_Equal_To_Than_Value()
        {
            Assert.True(ArrayCondition().Count.Is.GreaterThanEqualTo(5).Result);
            Assert.True(ArrayCondition().Count.Is.GreaterThanEqualTo(6).Result);

            Assert.True(IEnumerableCondition().Count.Is.GreaterThanEqualTo(5).Result);
            Assert.True(IEnumerableCondition().Count.Is.GreaterThanEqualTo(6).Result);

            Assert.True(ListCondition().Count.Is.GreaterThanEqualTo(5).Result);
            Assert.True(ListCondition().Count.Is.GreaterThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Less_Than_To_Value()
        {
            Assert.False(ArrayCondition().Count.Is.GreaterThanEqualTo(7).Result);

            Assert.False(IEnumerableCondition().Count.Is.GreaterThanEqualTo(7).Result);

            Assert.False(ListCondition().Count.Is.GreaterThanEqualTo(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Within_Range()
        {
            Assert.True(ArrayCondition().Count.Is.WithinRange(0, 6).Result);

            Assert.True(IEnumerableCondition().Count.Is.WithinRange(0, 6).Result);

            Assert.True(ListCondition().Count.Is.WithinRange(0, 6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Not_Within_Range()
        {
            Assert.False(ArrayCondition().Count.Is.WithinRange(7, 10).Result);

            Assert.False(IEnumerableCondition().Count.Is.WithinRange(7, 10).Result);

            Assert.False(ListCondition().Count.Is.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Count_Is_Not_Within_Range()
        {
            Assert.True(ArrayCondition().Count.Is.Not.WithinRange(7, 10).Result);

            Assert.True(IEnumerableCondition().Count.Is.Not.WithinRange(7, 10).Result);

            Assert.True(ListCondition().Count.Is.Not.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Count_Is_Within_Range()
        {
            Assert.False(ArrayCondition().Count.Is.Not.WithinRange(0, 6).Result);

            Assert.False(IEnumerableCondition().Count.Is.Not.WithinRange(0, 6).Result);

            Assert.False(ListCondition().Count.Is.Not.WithinRange(0, 6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_All_Elements_In_The_Source_Satisfies_A_Condition()
        {
            Assert.True(ArrayCondition(new[] { 4, 4, 4, 4, 4, 4 }).All(i => i == 4).Result);

            Assert.True(IEnumerableCondition(new[] { 4, 4, 4, 4, 4, 4 }).All(i => i == 4).Result);

            Assert.True(ListCondition(new List<int> { 4, 4, 4, 4, 4, 4 }).All(i => i == 4).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_All_Elements_In_The_Source_Do_Not_Satisfy_A_Condition()
        {
            Assert.False(ArrayCondition().All(i => i == 4).Result);

            Assert.False(IEnumerableCondition().All(i => i == 4).Result);

            Assert.False(ListCondition().All(i => i == 4).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Any_Element_In_The_Source_Satisfy_A_Condition()
        {
            Assert.True(ArrayCondition().Any(i => i == 4).Result);

            Assert.True(IEnumerableCondition().Any(i => i == 4).Result);

            Assert.True(ListCondition().Any(i => i == 4).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Any_Element_In_The_Source_Do_Not_Satisfy_A_Condition()
        {
            Assert.False(ArrayCondition(new[] { 1, 2, 3, 3, 5, 5 }).Any(i => i == 4).Result);

            Assert.False(IEnumerableCondition(new[] { 1, 2, 3, 3, 5, 5 }).Any(i => i == 4).Result);

            Assert.False(ListCondition(new List<int> { 1, 2, 3, 3, 5, 5 }).Any(i => i == 4).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_None_Of_The_Elements_In_The_Source_Satisfy_A_Condition()
        {
            Assert.True(ArrayCondition().None(i => i == 6).Result);

            Assert.True(IEnumerableCondition().None(i => i == 6).Result);

            Assert.True(ListCondition().None(i => i == 6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Any_Element_In_The_Source_Satisfy_A_Condition()
        {
            Assert.False(ArrayCondition().None(i => i == 4).Result);

            Assert.False(IEnumerableCondition().None(i => i == 4).Result);

            Assert.False(ListCondition().None(i => i == 4).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Sequentially_Equal_To_Other()
        {
            Assert.True(ArrayCondition().SequentiallyEqualTo(SourceArray).Result);

            Assert.True(IEnumerableCondition().SequentiallyEqualTo(SourceIEnumerable).Result);

            Assert.True(ListCondition().SequentiallyEqualTo(SourceList).Result);

            Assert.True(TestObjectsCondition().SequentiallyEqualTo(SourceTestObjects, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Not_Sequentially_Equal_To_Other()
        {
            Assert.False(ArrayCondition().SequentiallyEqualTo(OtherArray).Result);
            Assert.False(ArrayCondition().SequentiallyEqualTo(null).Result);

            Assert.False(IEnumerableCondition().SequentiallyEqualTo(OtherIEnumerable).Result);
            Assert.False(IEnumerableCondition().SequentiallyEqualTo(null).Result);

            Assert.False(ListCondition().SequentiallyEqualTo(OtherList).Result);
            Assert.False(ListCondition().SequentiallyEqualTo(null).Result);

            Assert.False(TestObjectsCondition().SequentiallyEqualTo(OtherTestObjects, TestObjectEqualityComparer).Result);
            Assert.False(TestObjectsCondition().SequentiallyEqualTo(null, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Not_Sequentially_Equal_To_Other()
        {
            Assert.True(ArrayCondition().Not.SequentiallyEqualTo(OtherArray).Result);
            Assert.True(ArrayCondition().Not.SequentiallyEqualTo(null).Result);

            Assert.True(IEnumerableCondition().Not.SequentiallyEqualTo(OtherIEnumerable).Result);
            Assert.True(IEnumerableCondition().Not.SequentiallyEqualTo(null).Result);

            Assert.True(ListCondition().Not.SequentiallyEqualTo(OtherList).Result);
            Assert.True(ListCondition().Not.SequentiallyEqualTo(null).Result);

            Assert.True(TestObjectsCondition().Not.SequentiallyEqualTo(OtherTestObjects, TestObjectEqualityComparer).Result);
            Assert.True(TestObjectsCondition().Not.SequentiallyEqualTo(null, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Sequentially_Equal_To_Other()
        {
            Assert.False(ArrayCondition().Not.SequentiallyEqualTo(SourceArray).Result);

            Assert.False(IEnumerableCondition().Not.SequentiallyEqualTo(SourceIEnumerable).Result);

            Assert.False(ListCondition().Not.SequentiallyEqualTo(SourceList).Result);

            Assert.False(TestObjectsCondition().Not.SequentiallyEqualTo(SourceTestObjects, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Contains_Value()
        {
            Assert.True(ArrayCondition().Contains(IntValueInSource).Result);

            Assert.True(IEnumerableCondition().Contains(IntValueInSource).Result);

            Assert.True(ListCondition().Contains(IntValueInSource).Result);

            Assert.True(TestObjectsCondition().Contains(TestObjectInSource, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Do_Not_Contain_Value()
        {
            Assert.False(ArrayCondition().Contains(IntValueNotInSource).Result);

            Assert.False(IEnumerableCondition().Contains(IntValueNotInSource).Result);

            Assert.False(ListCondition().Contains(IntValueNotInSource).Result);

            Assert.False(TestObjectsCondition().Contains(TestObjectNotInSource, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Do_Not_Contain_Value()
        {
            Assert.True(ArrayCondition().DoNot.Contain(IntValueNotInSource).Result);

            Assert.True(IEnumerableCondition().DoNot.Contain(IntValueNotInSource).Result);

            Assert.True(ListCondition().DoNot.Contain(IntValueNotInSource).Result);

            Assert.True(TestObjectsCondition().DoNot.Contain(TestObjectNotInSource, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Contains_Value()
        {
            Assert.False(ArrayCondition().DoNot.Contain(IntValueInSource).Result);

            Assert.False(IEnumerableCondition().DoNot.Contain(IntValueInSource).Result);

            Assert.False(ListCondition().DoNot.Contain(IntValueInSource).Result);

            Assert.False(TestObjectsCondition().DoNot.Contain(TestObjectInSource, TestObjectEqualityComparer).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Contains_Value_But_Value_Do_Not_Implement_IEquality_And_A_EqualityComparer_Was_Not_Supplied()
        {
            Assert.False(TestObjectsCondition().Contains(TestObjectInSource).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Contains_Value_But_Value_Do_Not_Implement_IEquality_And_A_EqualityComparer_Was_Not_Supplied()
        {
            Assert.True(TestObjectsCondition().DoNot.Contain(TestObjectInSource).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException()
        {
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Empty);
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Not.Empty);

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().All(to => to is null));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsWithNullCondition().All(to => to.IntValue == 5));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsCondition().All(null));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Any(to => to is null));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsWithNullCondition().Any(to => to.IntValue == 5));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsCondition().Any(null));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().None(to => to is null));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsWithNullCondition().None(to => to.IntValue == 5));
            Assert.Throws<ConditionEvaluationFailedException>(() => TestObjectsCondition().None(null));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().SequentiallyEqualTo(OtherTestObjects));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Not.SequentiallyEqualTo(OtherTestObjects));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Contains(TestObject.Default()));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().DoNot.Contain(TestObject.Default()));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.LessThan(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.LessThanEqualTo(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.GreaterThan(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.GreaterThanEqualTo(5));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.Not(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullTestObjectsCondition().Count.Is.Not.WithinRange(5, 6));
        }

        private static IChainableEnumerableCondition<int[], int> ArrayCondition(int[] source = null)
        {
            if (source is null)
                source = SourceArray;
            return source.IfEnumerable<int[], int>();
        }

        private static IChainableEnumerableCondition<IEnumerable<int>, int> IEnumerableCondition(IEnumerable<int> source = null)
        {
            if (source is null)
                source = SourceIEnumerable;
            return source.IfEnumerable<IEnumerable<int>, int>();
        }

        private static IChainableEnumerableCondition<List<int>, int> ListCondition(List<int> source = null)
        {
            if (source is null)
                source = SourceList;
            return source.IfEnumerable<List<int>, int>();
        }

        private static IChainableEnumerableCondition<TestObject[], TestObject> TestObjectsCondition(TestObject[] source = null)
        {
            if (source is null)
                source = SourceTestObjects;
            return source.IfEnumerable<TestObject[], TestObject>();
        }

        private static IChainableEnumerableCondition<TestObject[], TestObject> NullTestObjectsCondition()
        {
            return ((TestObject[])null).IfEnumerable<TestObject[], TestObject>();
        }

        private static IChainableEnumerableCondition<TestObject[], TestObject> TestObjectsWithNullCondition()
        {
            return new[] { null, TestObject.New(), TestObject.New("str", 3), TestObject.Default() }.IfEnumerable<TestObject[], TestObject>();
        }
    }
}