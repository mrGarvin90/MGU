namespace MGU.Console.Utilities.Input.InputRange
{
    public sealed class UIntRange : BaseRange<uint>
    {
        public UIntRange()
            : this(uint.MinValue)
        {
        }

        public UIntRange(uint minValue)
            : this(minValue, uint.MaxValue)
        {
        }

        public UIntRange(uint minValue, uint maxValue)
            : base(minValue, maxValue)
        {
        }
    }
}