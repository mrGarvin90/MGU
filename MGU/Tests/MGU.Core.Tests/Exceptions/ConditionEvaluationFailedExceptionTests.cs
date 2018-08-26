namespace MGU.Core.Tests.Exceptions
{
    using System;
    using System.Text;
    using Core.Exceptions;
    using Helpers;
    using Interfaces.ChainableConditions.Enumerable;
    using Xunit;

    public class ConditionEvaluationFailedExceptionTests : ExceptionTestBase<ConditionEvaluationFailedException>
    {
        private readonly Type _conditionType = typeof(IChainableStringCondition);
        private readonly string _conditionName = "StartsWith";
        private readonly Type _sourceType = typeof(string);
        private readonly object _sourceObjectValue = "Test";
        private readonly Exception _innerException = new Exception();

        public ConditionEvaluationFailedExceptionTests()
            : base(new[] { typeof(Type), typeof(string), typeof(Type), typeof(object), typeof(Exception) })
        {
        }

        [Fact]
        public void Should_Be_Able_To_Serialize_And_Deserialize_Exception()
        {
            var exception = CreateException(_conditionType, _conditionName, _sourceType, _sourceObjectValue, _innerException);
            AssertProperties(exception);

            exception = SerializeAndDeserialize(exception);
            AssertProperties(exception);
        }

        [Fact]
        public void Exception_Message_Should_Be_Formatted_Correctly()
        {
            var exception = CreateException(_conditionType, _conditionName, _sourceType, _sourceObjectValue, _innerException);
            Assert.Equal(CreateExpectedMessage(), exception.Message);
        }

        private void AssertProperties(ConditionEvaluationFailedException exception)
        {
            Assert.Equal(_conditionType.Name.Remove(0, 1), exception.ConditionType);
            Assert.Equal(_conditionName, exception.ConditionName);
            Assert.Equal(_sourceType.FullName, exception.SourceObjectType);
            Assert.Equal(_sourceObjectValue, exception.SourceObjectValue);
            Assert.Equal(CreateExpectedMessage(), exception.Message);
            Assert.Equal(_innerException.Message, exception.InnerException.Message);
        }

        private string CreateExpectedMessage()
        {
            var builder = new StringBuilder();
            return builder.AppendLine("An exception was thrown while evaluating a condition")
                          .Append("Condition type: ").AppendLine(_conditionType.Name.Remove(0, 1))
                          .Append("Condition name: ").AppendLine(_conditionName)
                          .Append("Source type: ").AppendLine(_sourceType.FullName)
                          .Append("Source value: ").Append("'").Append(_sourceObjectValue).Append("'").ToString();
        }
    }
}