namespace MGU.Core.Tests.Conditions
{
    using System;
    using Core.Extensions.Is.Base;
    using Interfaces.Conditions.Nullable;
    using Interfaces.Conditions.Struct;
    using TestObjects;
    using Xunit;

    public class ComparableConditionTests
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
        public void Should_Return_True_When_Source_Is_Equal_To_Other()
        {
            Assert.True(ComparableStructCondition().EqualTo(IntEqualToSource));

            Assert.True(NullableComparableStructCondition().EqualTo(NullableIntEqualToSource));
            Assert.True(NullableComparableStructCondition(true).EqualTo(null));

            Assert.True(ComparableClassCondition().EqualTo(ComparableTestObjectSource));
            Assert.True(ComparableClassCondition().EqualTo(ComparableTestObjectEqualToSource));
            Assert.True(ComparableClassCondition(true).EqualTo(null));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().EqualTo(IntNotEqualToSource));

            Assert.False(NullableComparableStructCondition().EqualTo(NullableIntNotEqualToSource));
            Assert.False(NullableComparableStructCondition().EqualTo(null));

            Assert.False(ComparableClassCondition().EqualTo(ComparableTestObjectNotEqualToSource));
            Assert.False(ComparableClassCondition().EqualTo(null));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().Not.EqualTo(IntNotEqualToSource));

            Assert.True(NullableComparableStructCondition().Not.EqualTo(NullableIntNotEqualToSource));
            Assert.True(NullableComparableStructCondition().Not.EqualTo(null));

            Assert.True(ComparableClassCondition().Not.EqualTo(ComparableTestObjectNotEqualToSource));
            Assert.True(ComparableClassCondition().Not.EqualTo(null));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().Not.EqualTo(IntEqualToSource));

            Assert.False(NullableComparableStructCondition().Not.EqualTo(NullableIntEqualToSource));
            Assert.False(NullableComparableStructCondition(true).Not.EqualTo(null));

            Assert.False(ComparableClassCondition().Not.EqualTo(ComparableTestObjectSource));
            Assert.False(ComparableClassCondition().Not.EqualTo(ComparableTestObjectEqualToSource));
            Assert.False(ComparableClassCondition(true).Not.EqualTo(null));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Less_Than_Value()
        {
            Assert.True(ComparableStructCondition().LessThan(IntGreaterThanSource));

            Assert.True(NullableComparableStructCondition().LessThan(NullableIntGreaterThanSource));

            Assert.True(ComparableClassCondition().LessThan(ComparableTestObjectGreaterThanSource));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().LessThan(IntLessThanSource));
            Assert.False(ComparableStructCondition().LessThan(IntEqualToSource));

            Assert.False(NullableComparableStructCondition().LessThan(NullableIntLessThanSource));
            Assert.False(NullableComparableStructCondition().LessThan(NullableIntEqualToSource));
            Assert.False(NullableComparableStructCondition(true).LessThan(null));

            Assert.False(ComparableClassCondition().LessThan(ComparableTestObjectLessThanSource));
            Assert.False(ComparableClassCondition().LessThan(ComparableTestObjectEqualToSource));
            Assert.False(ComparableClassCondition(true).LessThan(null));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().LessThanEqualTo(IntGreaterThanSource));
            Assert.True(ComparableStructCondition().LessThanEqualTo(IntEqualToSource));

            Assert.True(NullableComparableStructCondition().LessThanEqualTo(NullableIntGreaterThanSource));
            Assert.True(NullableComparableStructCondition().LessThanEqualTo(NullableIntEqualToSource));
            Assert.True(NullableComparableStructCondition(true).LessThanEqualTo(null));

            Assert.True(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectGreaterThanSource));
            Assert.True(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectEqualToSource));
            Assert.True(ComparableClassCondition(true).LessThanEqualTo(null));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Greater_Than_Value()
        {
            Assert.False(ComparableStructCondition().LessThanEqualTo(IntLessThanSource));

            Assert.False(NullableComparableStructCondition().LessThanEqualTo(NullableIntLessThanSource));

            Assert.False(ComparableClassCondition().LessThanEqualTo(ComparableTestObjectLessThanSource));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Greater_Than_Value()
        {
            Assert.True(ComparableStructCondition().GreaterThan(IntLessThanSource));

            Assert.True(NullableComparableStructCondition().GreaterThan(NullableIntLessThanSource));

            Assert.True(ComparableClassCondition().GreaterThan(ComparableTestObjectLessThanSource));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.False(ComparableStructCondition().GreaterThan(IntGreaterThanSource));
            Assert.False(ComparableStructCondition().GreaterThan(IntEqualToSource));

            Assert.False(NullableComparableStructCondition().GreaterThan(NullableIntGreaterThanSource));
            Assert.False(NullableComparableStructCondition().GreaterThan(NullableIntEqualToSource));
            Assert.False(NullableComparableStructCondition(true).GreaterThan(null));

            Assert.False(ComparableClassCondition().GreaterThan(ComparableTestObjectGreaterThanSource));
            Assert.False(ComparableClassCondition().GreaterThan(ComparableTestObjectEqualToSource));
            Assert.False(ComparableClassCondition(true).GreaterThan(null));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.True(ComparableStructCondition().GreaterThanEqualTo(IntLessThanSource));
            Assert.True(ComparableStructCondition().GreaterThanEqualTo(IntEqualToSource));

            Assert.True(NullableComparableStructCondition().GreaterThanEqualTo(NullableIntLessThanSource));
            Assert.True(NullableComparableStructCondition().GreaterThanEqualTo(NullableIntEqualToSource));
            Assert.True(NullableComparableStructCondition(true).GreaterThanEqualTo(null));

            Assert.True(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectLessThanSource));
            Assert.True(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectEqualToSource));
            Assert.True(ComparableClassCondition(true).GreaterThanEqualTo(null));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Less_Than_Value()
        {
            Assert.False(ComparableStructCondition().GreaterThanEqualTo(IntGreaterThanSource));

            Assert.False(NullableComparableStructCondition().GreaterThanEqualTo(NullableIntGreaterThanSource));

            Assert.False(ComparableClassCondition().GreaterThanEqualTo(ComparableTestObjectGreaterThanSource));
        }

        [Theory]
        [InlineData(4, 6)]
        [InlineData(5, 7)]
        [InlineData(3, 5)]
        public void Should_Return_True_When_Source_Is_Within_Range(int min, int max)
        {
            Assert.True(ComparableStructCondition().WithinRange(min, max));

            Assert.True(NullableComparableStructCondition().WithinRange(min, max));

            Assert.True(ComparableClassCondition().WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)));
        }

        [Theory]
        [InlineData(6, 8)]
        [InlineData(2, 4)]
        public void Should_Return_False_When_Source_Is_Not_Within_Range(int min, int max)
        {
            Assert.False(ComparableStructCondition().WithinRange(min, max));

            Assert.False(NullableComparableStructCondition().WithinRange(min, max));

            Assert.False(ComparableClassCondition().WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)));
        }

        [Theory]
        [InlineData(6, 8)]
        [InlineData(2, 4)]
        public void Should_Return_True_When_Source_Is_Not_Within_Range(int min, int max)
        {
            Assert.True(ComparableStructCondition().Not.WithinRange(min, max));

            Assert.True(NullableComparableStructCondition().Not.WithinRange(min, max));

            Assert.True(ComparableClassCondition().Not.WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)));
        }

        [Theory]
        [InlineData(4, 6)]
        [InlineData(5, 7)]
        [InlineData(3, 5)]
        public void Should_Return_False_When_Source_Is_Within_Range(int min, int max)
        {
            Assert.False(ComparableStructCondition().Not.WithinRange(min, max));

            Assert.False(NullableComparableStructCondition().Not.WithinRange(min, max));

            Assert.False(ComparableClassCondition().Not.WithinRange(ComparableTestObject.New(min), ComparableTestObject.New(max)));
        }

        [Fact]
        public void Should_Throw_Invalid_Operation_When_Min_Or_Max_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).WithinRange(null, ComparableTestObjectGreaterThanSource));
            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).WithinRange(ComparableTestObjectLessThanSource, null));
            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).WithinRange(null, null));

            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).Not.WithinRange(null, ComparableTestObjectGreaterThanSource));
            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).Not.WithinRange(ComparableTestObjectLessThanSource, null));
            Assert.Throws<ArgumentNullException>(() => ComparableClassCondition(true).Not.WithinRange(null, null));

            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().WithinRange(null, 7));
            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().WithinRange(3, null));
            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().WithinRange(null, null));

            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().Not.WithinRange(null, 7));
            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().Not.WithinRange(3, null));
            Assert.Throws<ArgumentNullException>(() => NullableComparableStructCondition().Not.WithinRange(null, null));
        }

        private static IComparableClassCondition<ComparableTestObject> ComparableClassCondition(bool nullSource = false)
        {
            return (nullSource ? null : ComparableTestObjectSource).IsComparableClass();
        }

        private static IComparableStructCondition<int> ComparableStructCondition()
        {
            return IntSource.IsComparableStruct();
        }

        private static INullableComparableStructCondition<int> NullableComparableStructCondition(bool nullSource = false)
        {
            return (nullSource ? null : NullableIntSource).IsNullableComparableStruct();
        }
    }
}