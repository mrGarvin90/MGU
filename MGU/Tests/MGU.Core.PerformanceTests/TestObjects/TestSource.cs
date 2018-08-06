namespace MGU.Core.PerformanceTests.TestObjects
{
    using System;

    public class TestSource : IEquatable<TestSource>
    {
        private TestSource(int number, string text)
        {
            Number = number;
            Text = text;
        }

        public static int DefaultNumber { get; } = 42;

        public static string DefaultText { get; } = "Text";

        public int Number { get; }

        public string Text { get; }

        public static TestSource Default()
            => new TestSource(DefaultNumber, DefaultText);

        public static TestSource New(int number, string text)
            => new TestSource(number, text);

        public bool Equals(TestSource other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Number == other.Number && string.Equals(Text, other.Text);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((TestSource)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Number * 397) ^ (Text != null ? Text.GetHashCode() : 0);
            }
        }
    }
}