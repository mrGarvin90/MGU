namespace MGU.Console.Utilities.Input.InputRange
{
    public sealed class IntRange : BaseRange<int>
    {
        public IntRange()
            : this(int.MinValue)
        {
        }

        public IntRange(int minValue)
            : this(minValue, int.MaxValue)
        {
        }

        public IntRange(int minValue, int maxValue)
            : base(minValue, maxValue)
        {
        }
    }
}