namespace MGU.Core.PerformanceTests.ChainableConditions
{
    using Extensions.If;
    using Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class ChainableStringConditionTests : PerformanceTestsBase
    {
        private static string Source { get; } = "Text";

        private static string EmptySource { get; } = string.Empty;

        private static string NullSource { get; } = null;

        [Test]
        public void StartsWith_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().StartsWith(\"T\")",
                    () => Source.If().StartsWith("T"),
                    25)
                .Add(
                    "Source.If().StartsWith(\"t\", true)",
                    () => Source.If().StartsWith("t", true),
                    35)
                .Add(
                    "Source.If().StartsWith('T')",
                    () => Source.If().StartsWith('T'),
                    25)
                .Add(
                    "Source.If().StartsWith('t', true)",
                    () => Source.If().StartsWith('t', true),
                    35)
                .Add(
                    "Source.If().StartsWith(\"M\")",
                    () => Source.If().StartsWith("M"),
                    25)
                .Add(
                    "Source.If().StartsWith(\"m\", true)",
                    () => Source.If().StartsWith("m", true),
                    35)
                .Add(
                    "Source.If().StartsWith('M')",
                    () => Source.If().StartsWith('M'),
                    25)
                .Add(
                    "Source.If().StartsWith('m', true)",
                    () => Source.If().StartsWith('m', true),
                    35)
                .Add(
                    "Source.If().StartsWith(null)",
                    () => Source.If().StartsWith(null),
                    15)
                .RunAll();
        }

        [Test]
        public void DoesNot_StartWith_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().DoesNot.StartWith(\"T\")",
                    () => Source.If().DoesNot.StartWith("T"),
                    30)
                .Add(
                    "Source.If().DoesNot.StartWith(\"t\", true)",
                    () => Source.If().DoesNot.StartWith("t", true),
                    35)
                .Add(
                    "Source.If().DoesNot.StartWith('T')",
                    () => Source.If().DoesNot.StartWith('T'),
                    25)
                .Add(
                    "Source.If().DoesNot.StartWith('t', true)",
                    () => Source.If().DoesNot.StartWith('t', true),
                    35)
                .Add(
                    "Source.If().DoesNot.StartWith(\"M\")",
                    () => Source.If().DoesNot.StartWith("M"),
                    25)
                .Add(
                    "Source.If().DoesNot.StartWith(\"m\", true)",
                    () => Source.If().DoesNot.StartWith("m", true),
                    35)
                .Add(
                    "Source.If().DoesNot.StartWith('M')",
                    () => Source.If().DoesNot.StartWith('M'),
                    25)
                .Add(
                    "Source.If().DoesNot.StartWith('m', true)",
                    () => Source.If().DoesNot.StartWith('m', true),
                    35)
                .Add(
                    "Source.If().DoesNot.StartWith(null)",
                    () => Source.If().DoesNot.StartWith(null),
                    15)
                .RunAll();
        }

        [Test]
        public void In_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().In(\"Some Text\")",
                    () => Source.If().In("Some Text"),
                    20)
                .Add(
                    "Source.If().In(\"some text\")",
                    () => Source.If().In("some text"),
                    20)
                .RunAll();
        }

        [Test]
        public void Not_In_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Not.In(\"Some Text\")",
                    () => Source.If().Not.In("Some Text"),
                    20)
                .Add(
                    "Source.If().Not.In(\"some text\")",
                    () => Source.If().Not.In("some text"),
                    20)
                .RunAll();
        }

        [Test]
        public void WhiteSpace_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().WhiteSpace",
                    () => Source.If().WhiteSpace,
                    12)
                .Add(
                    "EmptySource.If().WhiteSpace",
                    () => EmptySource.If().WhiteSpace,
                    12)
                .RunAll();
        }

        [Test]
        public void Null_Or_WhiteSpace_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Null.Or.WhiteSpace",
                    () => Source.If().Null.Or.WhiteSpace,
                    20)
                .Add(
                    "EmptySource.If().Null.Or.WhiteSpace",
                    () => EmptySource.If().Null.Or.WhiteSpace,
                    20)
                .Add(
                    "NullSource.If().Null.Or.WhiteSpace",
                    () => NullSource.If().Null.Or.WhiteSpace,
                    20)
                .RunAll();
        }

        [Test]
        public void Not_Null_Or_WhiteSpace_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Not.Null.Or.WhiteSpace",
                    () => Source.If().Not.Null.Or.WhiteSpace,
                    20)
                .Add(
                    "EmptySource.If().Not.Null.Or.WhiteSpace",
                    () => EmptySource.If().Not.Null.Or.WhiteSpace,
                    20)
                .Add(
                    "NullSource.If().Not.Null.Or.WhiteSpace",
                    () => NullSource.If().Not.Null.Or.WhiteSpace,
                    20)
                .RunAll();
        }

        [Test]
        public void Length_Should_Pass()
        {
            NewTestCollection()
                .Add(
                    "Source.If().Length.Is(5)",
                    () => Source.If().Length.Is(5),
                    20)
                .Add(
                    "EmptySource.If().Length.Is(0)",
                    () => EmptySource.If().Length.Is(0),
                    20)
                .Add(
                    "Source.If().Length.Is.Not(5)",
                    () => Source.If().Length.Is.Not(5),
                    20)
                .Add(
                    "EmptySource.If().Length.Is.Not(0)",
                    () => EmptySource.If().Length.Is.Not(0),
                    20)
                .RunAll();
        }

        [Test]
        public void Contains_Should_Pass()
        {
            const string source = "Some text containing SOUP and Q.";

            NewTestCollection()
                .Add(
                    "source.If().Contains(\"SOUP\")",
                    () => source.If().Contains("SOUP"),
                    23)
                .Add(
                    "source.If().Contains(\"soup\", true)",
                    () => source.If().Contains("soup", true),
                    30)
                .Add(
                    "source.If().Contains('Q')",
                    () => source.If().Contains('Q'),
                    23)
                .Add(
                    "source.If().Contains('q', true)",
                    () => source.If().Contains('q', true),
                    30)
                .RunAll();
        }

        [Test]
        public void DoesNot_Contain_Should_Pass()
        {
            const string source = "Some text containing SOUP and Q.";

            NewTestCollection()
                .Add(
                    "source.If().DoesNot.Contain(\"SOUP\")",
                    () => source.If().DoesNot.Contain("SOUP"),
                    28)
                .Add(
                    "source.If().DoesNot.Contain(\"soup\", true)",
                    () => source.If().DoesNot.Contain("soup", true),
                    35)
                .Add(
                    "source.If().DoesNot.Contain('Q')",
                    () => source.If().DoesNot.Contain('Q'),
                    28)
                .Add(
                    "source.If().DoesNot.Contain('q', true)",
                    () => source.If().DoesNot.Contain('q', true),
                    35)
                .RunAll();
        }
    }
}