namespace MGU.Core.Tests.Exceptions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Core.Exceptions;
    using Core.Extensions.If;
    using TestObjects;
    using Xunit;

    public class CouldNotCreateInstanceExceptionTests
    {
        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            var obj = new object();
            var originalException = Assert.Throws<CouldNotCreateInstanceException>(() => obj.If().Fulfills(s => true).Throw<TestException>(42));
            var buffer = new byte[4096];
            var memoryStream = new MemoryStream(buffer);
            var memoryStream2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, originalException);
            var deserializedException = (CouldNotCreateInstanceException)formatter.Deserialize(memoryStream2);

            Assert.Equal(originalException.Message, deserializedException.Message);
            Assert.Equal(originalException.InnerException.Message, deserializedException.InnerException.Message);
        }
    }
}