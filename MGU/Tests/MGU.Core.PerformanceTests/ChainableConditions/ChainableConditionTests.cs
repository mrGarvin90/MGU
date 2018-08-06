namespace MGU.Core.PerformanceTests.ChainableConditions
{
    using Extensions.If;
    using Helpers;
    using NUnit.Framework;
    using TestObjects;

    [TestFixture]
    public class ChainableConditionTests : PerformanceTestsBase
    {
        [Test]
        public void ShouldPass()
        {
            var source = TestSource.Default();
            var otherSource = TestSource.New(7, "7");
            var collection = new[] { TestSource.New(1, "1"), TestSource.New(2, "2"), TestSource.New(3, "3"), TestSource.Default() };

            NewTestCollection()
                .Add(
                    "source.If().Null",
                    () => source.If().Null.Then(default),
                    38)
                .Add(
                    "source.If().Not.Null",
                    () => source.If().Not.Null.Then(default),
                    40)
                .Add(
                    "source.If().EqualTo(source)",
                    () => source.If().EqualTo(source).Then(default),
                    40)
                .Add(
                    "source.If().EqualTo(TestSource.Default())",
                    () => source.If().EqualTo(TestSource.Default()).Then(default),
                    45)
                .Add(
                    "source.If().Not.EqualTo(source)",
                    () => source.If().Not.EqualTo(source).Then(default),
                    45)
                .Add(
                    "source.If().Not.EqualTo(TestSource.Default())",
                    () => source.If().Not.EqualTo(TestSource.Default()).Then(default),
                    50)
                .Add(
                    "source.If().Fulfills(s => s.Number == 42)",
                    () => source.If().Fulfills(s => s.Number == 42).Then(default),
                    38)
                .Add(
                    "source.If().DoesNot.Fulfill(s => s.Number == 42)",
                    () => source.If().DoesNot.Fulfill(s => s.Number == 42).Then(default),
                    40)
                .Add(
                    "nullSource.If().In(collection)",
                    () => source.If().In(collection).Then(default),
                    60)
                .Add(
                    "nullSource.If().Not.In(collection)",
                    () => otherSource.If().Not.In(collection).Then(default),
                    60)
                .RunAll();
        }
    }
}