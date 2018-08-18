namespace MGU.Core.Tests.TestObjects
{
    public class TestObject
    {
        public const string Guid = "639252b5-2f9b-4f4b-a4cf-a58d2ff44610";

        public const int FortyTwo = 42;

        private TestObject()
        {
        }

        private TestObject(string stringValue, int intValue)
        {
            StringValue = stringValue;
            IntValue = intValue;
        }

        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public static TestObject New()
            => new TestObject();

        public static TestObject New(string stringValue, int intValue)
            => new TestObject(stringValue, intValue);

        public static TestObject Default()
            => new TestObject(Guid, FortyTwo);
    }
}