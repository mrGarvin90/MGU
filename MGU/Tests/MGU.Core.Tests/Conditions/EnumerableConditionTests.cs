namespace MGU.Core.Tests.Conditions
{
    using System;
    using System.Collections.Generic;
    using Core.Extensions.Is.Base;
    using Interfaces.Conditions.Enumerable;
    using Xunit;

    public class EnumerableConditionTests
    {
        private const int IntValueInSource = 3;

        private static int[] SourceArray => new[] { 1, 2, IntValueInSource, 4, 4, 5 };

        private static IEnumerable<int> SourceIEnumerable => SourceArray;

        private static List<int> SourceList => new List<int>(SourceArray);

        [Fact]
        public void Should_Return_True_When_The_Source_Is_Empty()
        {
            Assert.True(ArrayCondition(new int[0]).Empty);

            Assert.True(IEnumerableCondition(new int[0]).Empty);

            Assert.True(ListCondition(new List<int>()).Empty);
        }

        [Fact]
        public void Should_Return_False_When_The_Source_Is_Not_Empty()
        {
            Assert.False(ArrayCondition().Empty);

            Assert.False(IEnumerableCondition().Empty);

            Assert.False(ListCondition().Empty);
        }

        [Fact]
        public void Should_Return_True_When_The_Source_Is_Not_Empty()
        {
            Assert.True(ArrayCondition().Not.Empty);

            Assert.True(IEnumerableCondition().Not.Empty);

            Assert.True(ListCondition().Not.Empty);
        }

        [Fact]
        public void Should_Return_False_When_The_Source_Is_Empty()
        {
            Assert.False(ArrayCondition(new int[0]).Not.Empty);

            Assert.False(IEnumerableCondition(new int[0]).Not.Empty);

            Assert.False(ListCondition(new List<int>()).Not.Empty);
        }

        [Fact]
        public void Should_Throw_ArgumentNullException_When_Source_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => NullArrayCondition().Empty);
            Assert.Throws<ArgumentNullException>(() => NullArrayCondition().Not.Empty);
        }

        [Fact]
        public void Should_Return_True_When_The_Source_Is_Null_Or_Empty()
        {
            Assert.True(NullArrayCondition().NullOrEmpty);
            Assert.True(ArrayCondition(new int[0]).NullOrEmpty);

            Assert.True(NullIEnumerableCondition().NullOrEmpty);
            Assert.True(IEnumerableCondition(new int[0]).NullOrEmpty);

            Assert.True(NullListCondition().NullOrEmpty);
            Assert.True(ListCondition(new List<int>()).NullOrEmpty);
        }

        [Fact]
        public void Should_Return_False_When_The_Source_Is_Not_Null_Or_Empty()
        {
            Assert.False(ArrayCondition().NullOrEmpty);

            Assert.False(IEnumerableCondition().NullOrEmpty);

            Assert.False(ListCondition().NullOrEmpty);
        }

        [Fact]
        public void Should_Return_True_When_The_Source_Is_Not_Null_Or_Empty()
        {
            Assert.True(ArrayCondition().Not.NullOrEmpty);

            Assert.True(IEnumerableCondition().Not.NullOrEmpty);

            Assert.True(ListCondition().Not.NullOrEmpty);
        }

        [Fact]
        public void Should_Return_False_When_The_Source_Is_Null_Or_Empty()
        {
            Assert.False(NullArrayCondition().Not.NullOrEmpty);
            Assert.False(ArrayCondition(new int[0]).Not.NullOrEmpty);

            Assert.False(NullIEnumerableCondition().Not.NullOrEmpty);
            Assert.False(IEnumerableCondition(new int[0]).Not.NullOrEmpty);

            Assert.False(NullListCondition().Not.NullOrEmpty);
            Assert.False(ListCondition(new List<int>()).Not.NullOrEmpty);
        }

        private static IEnumerableCondition<int[], int> ArrayCondition(int[] source = null)
        {
            if (source is null)
                source = SourceArray;
            return source.IsEnumerable<int[], int>();
        }

        private static IEnumerableCondition<int[], int> NullArrayCondition()
        {
            int[] source = null;
            return source.IsEnumerable<int[], int>();
        }

        private static IEnumerableCondition<IEnumerable<int>, int> IEnumerableCondition(IEnumerable<int> source = null)
        {
            if (source is null)
                source = SourceIEnumerable;
            return source.IsEnumerable<IEnumerable<int>, int>();
        }

        private static IEnumerableCondition<IEnumerable<int>, int> NullIEnumerableCondition()
        {
            IEnumerable<int> source = null;
            return source.IsEnumerable<IEnumerable<int>, int>();
        }

        private static IEnumerableCondition<List<int>, int> ListCondition(List<int> source = null)
        {
            if (source is null)
                source = SourceList;
            return source.IsEnumerable<List<int>, int>();
        }

        private static IEnumerableCondition<List<int>, int> NullListCondition()
        {
            List<int> source = null;
            return source.IsEnumerable<List<int>, int>();
        }
    }
}