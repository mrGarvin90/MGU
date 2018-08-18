namespace MGU.Core.Tests.TestObjects
{
    using System;

    public class ComparableTestObject : IComparable<ComparableTestObject>, IComparable
    {
        private ComparableTestObject(int intValue)
        {
            IntValue = intValue;
        }

        public int IntValue { get; set; }

        public static ComparableTestObject New(int intValue)
            => new ComparableTestObject(intValue);

        public int CompareTo(ComparableTestObject other)
        {
            if (this == other)
                return 0;
            return other is null ? 1 : IntValue.CompareTo(other.IntValue);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
                return 1;
            if (this == obj)
                return 0;
            if (!(obj is ComparableTestObject))
                throw new ArgumentException($"Object must be of type {nameof(ComparableTestObject)}");
            return CompareTo((ComparableTestObject)obj);
        }
    }
}