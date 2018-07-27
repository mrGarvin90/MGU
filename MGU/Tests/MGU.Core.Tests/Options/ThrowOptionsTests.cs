namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Extensions.If;
    using Xunit;

    public class ThrowOptionsTests
    {
        private const string Message = "Message";
        private const string ParameterName = "ParameterName";
        private const int ActualValue = 42;
        private static readonly Exception InnerException = new Exception();

        [Fact]
        public void Should_Throw_ArgumentException_When_Condition_Is_True()
        {
            var exception = Assert.Throws<ArgumentException>(() => 5.If().Fulfills(s => true).Throw().Argument(Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.ParamName);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentException>(() => 5.If().Fulfills(s => true).Throw().Argument(Message, ParameterName));
            Assert.Equal($"{Message}{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentException>(() => 5.If().Fulfills(s => true).Throw().Argument(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.ParamName);
            Assert.Equal(InnerException, exception.InnerException);

            exception = Assert.Throws<ArgumentException>(() => 5.If().Fulfills(s => true).Throw().Argument(Message, ParameterName, InnerException));
            Assert.Equal($"{Message}{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Should_Throw_ArgumentNullException_When_Condition_Is_True()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => 5.If().Fulfills(s => true).Throw().Null(ParameterName));
            Assert.Equal($"Value cannot be null.{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentNullException>(() => 5.If().Fulfills(s => true).Throw().Null(ParameterName, Message));
            Assert.Equal($"{Message}{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentNullException>(() => 5.If().Fulfills(s => true).Throw().Null(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.ParamName);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Should_Throw_ArgumentOutOfRangeException_When_Condition_Is_True()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 5.If().Fulfills(s => true).Throw().OutOfRange(ParameterName));
            Assert.Equal($"Specified argument was out of the range of valid values.{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Null(exception.ActualValue);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentOutOfRangeException>(() => 5.If().Fulfills(s => true).Throw().OutOfRange(ParameterName, Message));
            Assert.Equal($"{Message}{Environment.NewLine}Parameter name: {ParameterName}", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Null(exception.ActualValue);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<ArgumentOutOfRangeException>(() => 5.If().Fulfills(s => true).Throw().OutOfRange(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.ParamName);
            Assert.Null(exception.ActualValue);
            Assert.Equal(InnerException, exception.InnerException);

            exception = Assert.Throws<ArgumentOutOfRangeException>(() => 5.If().Fulfills(s => true).Throw().OutOfRange(ParameterName, ActualValue, Message));
            Assert.Equal($"{Message}{Environment.NewLine}Parameter name: {ParameterName}{Environment.NewLine}Actual value was {ActualValue}.", exception.Message);
            Assert.Equal(ParameterName, exception.ParamName);
            Assert.Equal(ActualValue, exception.ActualValue);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void Should_Throw_InvalidOperationException_When_Condition_Is_True()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => 5.If().Fulfills(s => true).Throw().InvalidOperation(Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<InvalidOperationException>(() => 5.If().Fulfills(s => true).Throw().InvalidOperation(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Should_Throw_Exception_When_Condition_Is_True()
        {
            var exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).Throw().Exception(Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).Throw().Exception(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Should_Not_Throw_ArgumentException_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Argument(Message));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Argument(Message, ParameterName));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Argument(Message, InnerException));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Argument(Message, ParameterName, InnerException));
        }

        [Fact]
        public void Should_Not_Throw_ArgumentNullException_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Null(ParameterName));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Null(ParameterName, Message));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Null(Message, InnerException));
        }

        [Fact]
        public void Should_Not_Throw_ArgumentOutOfRangeException_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().OutOfRange(ParameterName));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().OutOfRange(ParameterName, Message));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().OutOfRange(Message, InnerException));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().OutOfRange(ParameterName, ActualValue, Message));
        }

        [Fact]
        public void Should_Not_Throw_InvalidOperationException_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().InvalidOperation(Message));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().InvalidOperation(Message, InnerException));
        }

        [Fact]
        public void Should_Not_Throw_Exception_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Exception(Message));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw().Exception(Message, InnerException));
        }
    }
}