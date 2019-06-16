namespace MGU.Console.Utilities.Input.InputRange
{
    public sealed class DoubleRange : BaseRange<double>
    {
        public DoubleRange()
            : this(double.MinValue)
        {
        }

        public DoubleRange(double minValue)
            : this(minValue, double.MaxValue)
        {
        }

        public DoubleRange(double minValue, double maxValue)
            : base(minValue, maxValue)
        {
        }
    }
}