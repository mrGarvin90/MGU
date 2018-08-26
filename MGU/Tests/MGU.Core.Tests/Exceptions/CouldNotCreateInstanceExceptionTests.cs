namespace MGU.Core.Tests.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.Exceptions;
    using Helpers;
    using TestObjects;
    using Xunit;

    public class CouldNotCreateInstanceExceptionTests : ExceptionTestBase<CouldNotCreateInstanceException>
    {
        private readonly Type _instanceType = typeof(TestException);
        private readonly Exception _innerException = new Exception();

        public CouldNotCreateInstanceExceptionTests()
            : base(
                new[] { typeof(Type), typeof(IEnumerable<object>), typeof(Exception) },
                new[] { typeof(Type), typeof(IEnumerable<Type>), typeof(IEnumerable<object>), typeof(Exception) })
        {
        }

        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            var exception = CreateException(CreateParameters(new object[] { 42 }));
            AssertProperties(exception);

            exception = SerializeAndDeserialize(exception);
            AssertProperties(exception);

            exception = CreateException(CreateParameters(new[] { typeof(int) }, new object[] { 42 }));
            AssertProperties(exception);

            exception = SerializeAndDeserialize(exception);
            AssertProperties(exception);
        }

        [Fact]
        public void Exception_Message_Should_Be_Formatted_Correctly_For_Constructor_With_InstanceType_Parameters_And_InnerException()
        {
            AssertMessage(new object[0]);
            AssertMessage(null);
            AssertMessage(new object[] { 42 });
            AssertMessage(new object[] { null });
            AssertMessage(new object[] { 42, "test" });
            AssertMessage(new object[] { 42, null });
        }

        [Fact]
        public void Exception_Message_Should_Be_Formatted_Correctly_For_Constructor_With_InstanceType_ParameterTypes_Parameters_And_InnerException()
        {
            AssertMessage(new Type[0], new object[0]);
            AssertMessage(null, null);
            AssertMessage(new[] { typeof(int), typeof(string) }, new object[] { 42, "test" });
            AssertMessage(new[] { typeof(int), null }, new object[] { 42, null });
            AssertMessage(new[] { typeof(int) }, null);
            AssertMessage(null, new object[] { 42 });
        }

        private void AssertProperties(CouldNotCreateInstanceException exception)
        {
            Assert.Equal(_instanceType.FullName, exception.InstanceType);
            Assert.Equal(_innerException.Message, exception.InnerException.Message);
        }

        private void AssertMessage(IEnumerable<object> parameters)
        {
            string message;
            var builder = CreateNewMessageBuilder().Append(" with ");
            if (!parameters?.Any() ?? true)
            {
                message = builder.Append("no parameters.").ToString();
            }
            else
            {
                message = builder
                    .AppendLine("parameters:")
                    .AppendJoin(
                        Environment.NewLine,
                        parameters.Select(
                            p => $"{(p is null ? "<null>" : $"'{p}'")} : '{p?.GetType().FullName ?? "<undefined>"}'"))
                    .ToString();
            }

            var exception = CreateException(CreateParameters(parameters));
            Assert.Equal(message, exception.Message);
        }

        private void AssertMessage(IEnumerable<Type> parameterTypes, IEnumerable<object> parameters)
        {
            string message;
            var builder = CreateNewMessageBuilder().AppendLine();
            if (!parameterTypes?.Any() ?? true)
            {
                builder.AppendLine("No parameter types.");
            }
            else
            {
                builder
                    .AppendLine("Parameter types:")
                    .AppendJoin(
                        Environment.NewLine,
                        parameterTypes.Select(pt => pt is null ? "<null>" : $"'{pt.FullName}'"))
                    .AppendLine();
            }

            if (!parameters?.Any() ?? true)
            {
                message = builder.Append("No parameters.").ToString();
            }
            else
            {
                message = builder
                    .AppendLine("Parameters:")
                    .AppendJoin(
                        Environment.NewLine,
                        parameters.Select(
                            p => $"{(p is null ? "<null>" : $"'{p}'")} : '{p?.GetType().FullName ?? "<undefined>"}'"))
                    .ToString();
            }

            var exception = CreateException(CreateParameters(parameterTypes, parameters));
            Assert.Equal(message, exception.Message);
        }

        private object[] CreateParameters(IEnumerable<object> parameters)
            => new object[] { _instanceType, parameters, _innerException };

        private object[] CreateParameters(IEnumerable<Type> parameterTypes, IEnumerable<object> parameters)
            => new object[] { _instanceType, parameterTypes, parameters, _innerException };

        private StringBuilder CreateNewMessageBuilder()
            => new StringBuilder("Could not create a new instance of ").Append(typeof(TestException).FullName);
    }
}