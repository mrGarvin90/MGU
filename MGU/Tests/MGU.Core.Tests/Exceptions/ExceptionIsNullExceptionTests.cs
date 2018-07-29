namespace MGU.Core.Tests.Exceptions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Core.Exceptions;
    using Core.Extensions.If;
    using TestObjects;
    using Xunit;

    public class ExceptionIsNullExceptionTests
    {
        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            var obj = new object();
            var originalException = Assert.Throws<ExceptionIsNullException>(() => obj.If().Fulfills(s => true).Throw((TestException)null));
            var buffer = new byte[4096];
            var memoryStream = new MemoryStream(buffer);
            var memoryStream2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, originalException);
            var deserializedException = (ExceptionIsNullException)formatter.Deserialize(memoryStream2);

            Assert.Equal(originalException.Message, deserializedException.Message);
        }
    }
}