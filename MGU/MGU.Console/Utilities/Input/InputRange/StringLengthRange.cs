namespace MGU.Console.Utilities.Input.InputRange
{
    using System;

    public sealed class StringLengthRange : BaseRange<uint>
    {
        private const uint MaxStringLength = 1073741823;

        public static uint Max => MaxStringLength;

        public StringLengthRange()
            : this(0)
        {
        }
        
        public StringLengthRange(uint minLength)
            : this(minLength, MaxStringLength)
        {
        }

        public StringLengthRange(uint minLength, uint maxLength)
            : base(minLength, maxLength <= MaxStringLength ? maxLength : throw new InvalidOperationException($"{nameof(maxLength)} cannot be larger than {nameof(MaxStringLength)}."))
        {
            this.ErrorMessage = $"Must contain {this.ToString()} characters.";
        }

        public override bool WithinRange(object obj)
        {
            var value = (string) obj;
            return this.MinValue <= value.Length && value.Length <= this.MaxValue;
        }

        public override string ToString()
        {
            return $"{this.MinValue} to {this.MaxValue}";
        }
    }
}