namespace MGU.Console.Utilities.Input.InputRange
{
    public sealed class DecimalRange : BaseRange<decimal>
    {
        public DecimalRange()
            : this(decimal.MinValue)
        {
        }

        public DecimalRange(decimal minValue)
            : this(minValue, decimal.MaxValue)
        {
        }

        public DecimalRange(decimal minValue, decimal maxValue)
            : base(minValue, maxValue)
        {
        }
    }
}