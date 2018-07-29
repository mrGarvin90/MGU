namespace MGU.Core.Tests.ChainableConditions
{
    using Core.Exceptions;
    using Core.Extensions.If.Base;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.ChainableConditions.Struct;
    using TestObjects;
    using Xunit;

    public class ChainableComparableConditionTests
    {
        private const int IntSource = 5;

        private const int IntEqualToSource = 5;

        private const int IntLessThanSource = 3;

        private const int IntGreaterThanSource = 7;

        private const int IntNotEqualToSource = 42;

        private static readonly int? NullableIntSource = 5;

        private static readonly int? NullableIntEqualToSource = 5;

        private static readonly int? NullableIntLessThanSource = 3;

        private static readonly int? NullableIntGreaterThanSource = 7;

        private static readonly int? NullableIntNotEqualToSource = 42;

        private static readonly ComparableTestObject ComparableTestObjectSource = ComparableTestObject.New(5);

        private static readonly ComparableTestObject ComparableTestObjectEqualToSource = ComparableTestObject.New(5);

        private static readonly ComparableTestObject ComparableTestObjectLessThanSource = ComparableTestObject.New(3);

        private static readonly ComparableTestObject ComparableTestObjectGreaterThanSource = ComparableTestObject.New(7);

        private static readonly ComparableTestObject ComparableTestObjectNotEqualToSource = ComparableTestObject.New(42);

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Equal_To_Other()
        {
            Assert.True(ComparableStructCondition().EqualTo(IntEqualToSource).Result);

            Assert.True(ComparableNullableStructCondition().EqualTo(NullableIntEqualToSource).Result);
            Assert.True(ComparableNullableStructCondition(true).EqualTo(null).Result);

            Assert.True(ComparableClassCondition().EqualTo(ComparableTestObjectSource).Result);
            Assert.True(ComparableClassCondition().EqualTo(ComparableTestObjectEqualToSource).Result);
            Assert.True(ComparableClassCondition(true).EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().EqualTo(IntNotEqualToSource).Result);

            Assert.False(ComparableNullableStructCondition().EqualTo(NullableIntNotEqualToSource).Result);
            Assert.False(ComparableNullableStructCondition().EqualTo(null).Result);

            Assert.False(ComparableClassCondition().EqualTo(ComparableTestObjectNotEqualToSource).Result);
            Assert.False(ComparableClassCondition().EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().Not.EqualTo(IntNotEqualToSource).Result);

            Assert.True(ComparableNullableStructCondition().Not.EqualTo(NullableIntNotEqualToSource).Result);
            Assert.True(ComparableNullableStructCondition().Not.EqualTo(null).Result);

            Assert.True(ComparableClassCondition().Not.EqualTo(ComparableTestObjectNotEqualToSource).Result);
            Assert.True(ComparableClassCondition().Not.EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().Not.EqualTo(IntEqualToSource).Result);

            Assert.False(ComparableNullableStructCondition().Not.EqualTo(NullableIntEqualToSource).Result);
            Assert.False(ComparableNullableStructCondition(true).Not.EqualTo(null).Result);

            Assert.False(ComparableClassCondition().Not.EqualTo(ComparableTestObjectSource).Result);
            Assert.False(ComparableClassCondition().Not.EqualTo(ComparableTestObjectEqualToSource).Result);
            Assert.False(ComparableClassCondition(true).Not.EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Less_Than_Value()
        {
            Assert.True(ComparableStructCondition().LessThan(IntGreaterThanSource).Result);

            Assert.True(ComparableNullableStructCondition().LessThan(NullableIntGreaterThanSource).Result);

            Assert.True(ComparableClassCondition().LessThan(ComparableTestObjectGreaterThanSource).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().LessThan(IntLessThanSource).Result);
            Assert.False(ComparableStructCondition().LessThan(IntEqualToSource).Result);

            Assert.False(ComparableNullableStructCondition().LessThan(NullableIntLessThanSource).Result);
            Assert.False(ComparableNullableStructCondition().LessThan(NullableIntEqualToSource).Result);
            Assert.False(ComparableNullableStructCondition(true).LessThan(null).Result);

            Assert.False(ComparableClassCondition().LessThan(ComparableTestObjectLessThanSource).Result);
            Assert.False(ComparableClassCondition().LessThan(ComparableTestObjectEqualToSource).Result);
            Assert.False(ComparableClassCondition(true).LessThan(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().LessThanEqualTo(IntGreaterThanSource).Result);
            Assert.True(ComparableStructCondition().LessThanEqualTo(IntEqualToSource).Result);

            Assert.True(ComparableNullableStructCondition().LessThanEqualTo(NullableIntGreaterThanSource).Result);
            Assert.True(ComparableNullableStructCondition().LessThanEqualTo(NullableIntEqualToSource).Result);
            Assert.True(ComparableNullableStructCondition(true).LessThanEqualTo(null).Result);

            Assert.True(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectGreaterThanSource).Result);
            Assert.True(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectEqualToSource).Result);
            Assert.True(ComparableClassCondition(true).LessThanEqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Greater_Than_Value()
        {
            Assert.False(ComparableStructCondition().LessThanEqualTo(IntLessThanSource).Result);

            Assert.False(ComparableNullableStructCondition().LessThanEqualTo(NullableIntLessThanSource).Result);

            Assert.False(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectLessThanSource).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Greater_Than_Value()
        {
            Assert.True(ComparableStructCondition().GreaterThan(IntLessThanSource).Result);

            Assert.True(ComparableNullableStructCondition().GreaterThan(NullableIntLessThanSource).Result);

            Assert.True(ComparableClassCondition().GreaterThan(ComparableTestObjectLessThanSource).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().GreaterThan(IntGreaterThanSource).Result);
            Assert.False(ComparableStructCondition().GreaterThan(IntEqualToSource).Result);

            Assert.False(ComparableNullableStructCondition().GreaterThan(NullableIntGreaterThanSource).Result);
            Assert.False(ComparableNullableStructCondition().GreaterThan(NullableIntEqualToSource).Result);
            Assert.False(ComparableNullableStructCondition(true).GreaterThan(null).Result);

            Assert.False(ComparableClassCondition().GreaterThan(ComparableTestObjectGreaterThanSource).Result);
            Assert.False(ComparableClassCondition().GreaterThan(ComparableTestObjectEqualToSource).Result);
            Assert.False(ComparableClassCondition(true).GreaterThan(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().GreaterThanEqualTo(IntLessThanSource).Result);
            Assert.True(ComparableStructCondition().GreaterThanEqualTo(IntEqualToSource).Result);

            Assert.True(ComparableNullableStructCondition().GreaterThanEqualTo(NullableIntLessThanSource).Result);
            Assert.True(ComparableNullableStructCondition().GreaterThanEqualTo(NullableIntEqualToSource).Result);
            Assert.True(ComparableNullableStructCondition(true).GreaterThanEqualTo(null).Result);

            Assert.True(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectLessThanSource).Result);
            Assert.True(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectEqualToSource).Result);
            Assert.True(ComparableClassCondition(true).GreaterThanEqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Less_Than_Value()
        {
            Assert.False(ComparableStructCondition().GreaterThanEqualTo(IntGreaterThanSource).Result);

            Assert.False(ComparableNullableStructCondition().GreaterThanEqualTo(NullableIntGreaterThanSource).Result);

            Assert.False(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectGreaterThanSource).Result);
        }

        [Theory]
        [InlineData(4, 6)]
        [InlineData(5, 7)]
        [InlineData(3, 5)]
        public void Result_Should_Be_True_When_Source_Is_Within_Range(int min, int max)
        {
            Assert.True(ComparableStructCondition().WithinRange(min, max).Result);

            Assert.True(ComparableNullableStructCondition().WithinRange(min, max).Result);

            Assert.True(ComparableClassCondition().WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)).Result);
        }

        [Theory]
        [InlineData(6, 8)]
        [InlineData(2, 4)]
        public void Result_Should_Be_False_When_Source_Is_Not_Within_Range(int min, int max)
        {
            Assert.False(ComparableStructCondition().WithinRange(min, max).Result);

            Assert.False(ComparableNullableStructCondition().WithinRange(min, max).Result);

            Assert.False(ComparableClassCondition().WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)).Result);
        }

        [Theory]
        [InlineData(6, 8)]
        [InlineData(2, 4)]
        public void Result_Should_Be_True_When_Source_Is_Not_Within_Range(int min, int max)
        {
            Assert.True(ComparableStructCondition().Not.WithinRange(min, max).Result);

            Assert.True(ComparableNullableStructCondition().Not.WithinRange(min, max).Result);

            Assert.True(ComparableClassCondition().Not.WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)).Result);
        }

        [Theory]
        [InlineData(4, 6)]
        [InlineData(5, 7)]
        [InlineData(3, 5)]
        public void Result_Should_Be_False_When_Source_Is_Within_Range(int min, int max)
        {
            Assert.False(ComparableStructCondition().Not.WithinRange(min, max).Result);

            Assert.False(ComparableNullableStructCondition().Not.WithinRange(min, max).Result);

            Assert.False(ComparableClassCondition().Not.WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException_When_Min_Or_Max_Is_Null()
        {
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().WithinRange(null, 6).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().WithinRange(4, null).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().WithinRange(null, null).Result);

            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().Not.WithinRange(null, 6).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().Not.WithinRange(4, null).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableNullableStructCondition().Not.WithinRange(null, null).Result);

            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().WithinRange(null, ComparableTestObject.New(6)).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().WithinRange(ComparableTestObject.New(4), null).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().WithinRange(null, null).Result);

            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().Not.WithinRange(null, ComparableTestObject.New(6)).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().Not.WithinRange(ComparableTestObject.New(4), null).Result);
            Assert.Throws<ConditionEvaluationFailedException>(() => ComparableClassCondition().Not.WithinRange(null, null).Result);
        }

        private static IChainableComparableClassCondition<ComparableTestObject> ComparableClassCondition(bool nullSource = false)
        {
            return (nullSource ? null : ComparableTestObjectSource).IfComparableClass();
        }

        private static IChainableComparableStructCondition<int> ComparableStructCondition()
        {
            return IntSource.IfComparableStruct();
        }

        private static IChainableNullableComparableStructCondition<int> ComparableNullableStructCondition(bool nullSource = false)
        {
            return (nullSource ? null : NullableIntSource).IfNullableComparableStruct();
        }
    }
}