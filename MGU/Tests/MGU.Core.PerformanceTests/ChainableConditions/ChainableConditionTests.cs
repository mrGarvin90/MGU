namespace MGU.Core.PerformanceTests.ChainableConditions
{
    using System.Collections.Generic;
    using Extensions.If;
    using Helpers;
    using NUnit.Framework;
    using TestObjects;

    [TestFixture]
    public class ChainableConditionTests : PerformanceTestsBase
    {
        private static TestSource Source { get; } = TestSource.Default();

        private static IEnumerable<TestSource> Collection { get; } = new[] { TestSource.New(1, "1"), TestSource.New(2, "2"), TestSource.New(3, "3"), TestSource.Default() };

        [Test]
        public void Null_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Null",
                    () => Source.If().Null,
                    12)
                .RunAll();
        }

        [Test]
        public void Not_Null_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Not.Null",
                    () => Source.If().Not.Null,
                    12)
                .RunAll();
        }

        [Test]
        public void EqualTo_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().EqualTo(Source)",
                    () => Source.If().EqualTo(Source),
                    14)
                .Add(
                    "Source.If().EqualTo(TestSource.Default())",
                    () => Source.If().EqualTo(TestSource.Default()),
                    20)
                .RunAll();
        }

        [Test]
        public void Not_EqualTo_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Not.EqualTo(Source)",
                    () => Source.If().Not.EqualTo(Source),
                    12)
                .Add(
                    "Source.If().Not.EqualTo(TestSource.Default())",
                    () => Source.If().Not.EqualTo(TestSource.Default()),
                    20)
                .RunAll();
        }

        [Test]
        public void Fulfills_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Fulfills(s => s.Number == 42)",
                    () => Source.If().Fulfills(s => s.Number == 42),
                    10)
                .RunAll();
        }

        [Test]
        public void DoesNot_Fulfill_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().DoesNot.Fulfill(s => s.Number == 42)",
                    () => Source.If().DoesNot.Fulfill(s => s.Number == 42),
                    10)
                .RunAll();
        }

        [Test]
        public void In_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().In(collection)",
                    () => Source.If().In(Collection),
                    35)
                .RunAll();
        }

        [Test]
        public void Not_In_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Not.In(collection)",
                    () => Source.If().Not.In(Collection),
                    35)
                .RunAll();
        }
    }
}