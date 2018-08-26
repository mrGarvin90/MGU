namespace MGU.Core.Tests.Exceptions
{
    using System;
    using Core.Exceptions;
    using Helpers;
    using TestObjects;
    using Xunit;

    public class ExceptionIsNullExceptionTests : ExceptionTestBase<ExceptionIsNullException>
    {
        private readonly Type _exceptionType = typeof(TestException);

        public ExceptionIsNullExceptionTests()
            : base(new[] { typeof(Type) })
        {
        }

        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            var exception = CreateException(_exceptionType);
            AssertProperties(exception);

            exception = SerializeAndDeserialize(exception);
            AssertProperties(exception);
        }

        [Fact]
        public void Exception_Message_Should_Be_Formatted_Correctly()
        {
            var exception = CreateException(_exceptionType);
            Assert.Equal(CreateExpectedMessage(), exception.Message);
        }

        private void AssertProperties(ExceptionIsNullException exception)
        {
            Assert.Equal(CreateExpectedMessage(), exception.Message);
            Assert.Null(exception.InnerException);
        }

        private string CreateExpectedMessage()
            => $"Exception cannot be null.{Environment.NewLine}Type: {_exceptionType.FullName}";
    }
}