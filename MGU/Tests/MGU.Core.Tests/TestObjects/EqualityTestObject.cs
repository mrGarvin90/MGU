namespace MGU.Core.Tests.TestObjects
{
    using System;

    public class EqualityTestObject : IEquatable<EqualityTestObject>
    {
        public const string Guid = "639252b5-2f9b-4f4b-a4cf-a58d2ff44610";

        public const int FortyTwo = 42;
        
        public string StringValue { get; set; }

        public int IntValue { get; set; }

        private EqualityTestObject()
        {
        }

        private EqualityTestObject(string stringValue, int intValue)
        {
            StringValue = stringValue;
            IntValue = intValue;
        }

        public bool Equals(EqualityTestObject other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(StringValue, other.StringValue) && IntValue == other.IntValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((EqualityTestObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((StringValue != null ? StringValue.GetHashCode() : 0) * 397) ^ IntValue;
            }
        }

        public static bool operator ==(EqualityTestObject left, EqualityTestObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EqualityTestObject left, EqualityTestObject right)
        {
            return !Equals(left, right);
        }

        public static EqualityTestObject New()
        {
            return new EqualityTestObject();
        }

        public static EqualityTestObject New(string stringValue, int intValue)
        {
            return new EqualityTestObject(stringValue, intValue);
        }

        public static EqualityTestObject Default()
        {
            return new EqualityTestObject(Guid, FortyTwo);
        }
    }
}