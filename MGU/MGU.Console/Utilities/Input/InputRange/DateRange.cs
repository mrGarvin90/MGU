namespace MGU.Console.Utilities.Input.InputRange
{
    using System;

    public sealed class DateRange : BaseRange<DateTime>
    {
        public DateRange()
            : this(DateTime.MinValue)
        {
        }

        public DateRange(DateTime minValue)
            : this(minValue, DateTime.MaxValue)
        {
        }

        public DateRange(DateTime minValue, DateTime maxValue)
            : base(minValue, maxValue)
        {
        }

        public DateRange(string minValue, string maxValue)
            : base(DateTime.Parse(minValue).Date, DateTime.Parse(maxValue).Date)
        {
        }

        public override string MinValueToString() => this.MinValue.ToString("yyyy-MM-dd");

        public override string MaxValueToString() => this.MaxValue.ToString("yyyy-MM-dd");
    }
}