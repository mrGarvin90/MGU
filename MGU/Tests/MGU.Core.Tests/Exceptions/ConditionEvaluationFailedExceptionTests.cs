namespace MGU.Core.Tests.Exceptions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Core.Exceptions;
    using Core.Extensions.If;
    using TestObjects;
    using Xunit;

    public class ConditionEvaluationFailedExceptionTests
    {
        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            int? source = 0;
            var originalException = Assert.Throws<ConditionEvaluationFailedException>(() => source.If().WithinRange(null, null).Throw<TestException>());
            var buffer = new byte[4096];
            var memoryStream = new MemoryStream(buffer);
            var memoryStream2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, originalException);
            var deserializedException = (ConditionEvaluationFailedException)formatter.Deserialize(memoryStream2);

            Assert.Equal(originalException.Message, deserializedException.Message);
            Assert.Equal(originalException.InnerException.Message, deserializedException.InnerException.Message);
        }
    }
}