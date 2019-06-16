namespace MGU.Console.Utilities.Input.InputRange
{
    using System;
    using Interfaces.Input;

    public abstract class BaseRange<T> : IRange
        where T : IComparable<T>
    {
        public T MinValue { get; }
        public T MaxValue { get; }
        public virtual string ErrorMessage { get; protected set; }
        
        protected BaseRange(T minValue, T maxValue)
        {
            if (minValue.CompareTo(maxValue) > 0)
                throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"Cannot be greater than {nameof(maxValue)}.");

            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.ErrorMessage = $"Must be within the range {this.ToString()}.";
        }

        public virtual bool WithinRange(object obj)
        {
            var value = (T) obj;
            var compareToMinResult = value.CompareTo(this.MinValue);
            var compareToMaxResult = value.CompareTo(this.MaxValue);
            return 0 <= compareToMinResult && compareToMaxResult <= 0;
        }
        
        public virtual string MinValueToString() => this.MinValue.ToString();

        public virtual string MaxValueToString() => this.MaxValue.ToString();

        public override string ToString()
        {
            return $"{this.MinValue} to {this.MaxValue}";
        }
    }
}