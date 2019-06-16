namespace MGU.Console.Utilities.Input.InputRange
{
    using System;

    public class TimeSpanRange : BaseRange<TimeSpan>
    {
        public TimeSpanRange()
            : this(TimeSpan.MinValue)
        {
        }

        public TimeSpanRange(TimeSpan minValue)
            : this(minValue, TimeSpan.MaxValue)
        {
        }

        public TimeSpanRange(TimeSpan minValue, TimeSpan maxValue)
            : base(minValue, maxValue)
        {
        }

        public TimeSpanRange(string minValue, string maxValue)
            : base(TimeSpan.Parse(minValue), TimeSpan.Parse(maxValue))
        {
        }

        public override string MinValueToString() => this.MinValue.ToString("c");

        public override string MaxValueToString() => this.MaxValue.ToString("c");
    }
}