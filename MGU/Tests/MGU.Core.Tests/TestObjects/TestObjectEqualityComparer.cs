namespace MGU.Core.Tests.TestObjects
{
    using System.Collections.Generic;

    public class TestObjectEqualityComparer : IEqualityComparer<TestObject>
    {
        public bool Equals(TestObject x, TestObject y)
        {
            if (x is null && y is null)
                return true;
            if (x != null && y != null)
                return x.StringValue == y.StringValue && x.IntValue == y.IntValue;
            return false;
        }

        public int GetHashCode(TestObject obj)
        {
            unchecked
            {
                return ((obj.StringValue != null ? obj.StringValue.GetHashCode() : 0) * 397) ^ obj.IntValue;
            }
        }
    }
}