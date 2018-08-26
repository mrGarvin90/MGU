namespace MGU.Core.Tests.Extensions
{
    using System;
    using Core.Extensions.If;
    using Helpers;
    using Interfaces.Options;
    using Xunit;

    public class IfExtensionsTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Type()
        {
            Assert.True(GetTypeOption<int, int>(5).Result);
            Assert.True(GetTypeOption<object, int>(5).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Type_But_Source_Is_Null()
        {
            Assert.False(GetTypeOption<int?, int?>(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Type()
        {
            Assert.False(GetTypeOption<object, int>("Text").Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Type()
        {
            Assert.True(GetNotTypeOption<object, int>("Text").Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Type_But_Source_Is_Null()
        {
            Assert.True(GetNotTypeOption<int?, int?>(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Type()
        {
            Assert.False(GetNotTypeOption<int, int>(5).Result);
            Assert.False(GetNotTypeOption<object, int>(5).Result);
        }

        [Fact]
        public void Not_Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Type()
        {
            Assert.False(GetNotTypeOption<object, int>(true, LogicalOperator.And, 5).Result);

            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.Or, 5).Result);

            Assert.True(GetNotTypeOption<int?, int?>(true, LogicalOperator.Or, null).Result);

            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.Or, 5).Result);

            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.And, 5).Result);
            Assert.False(GetNotTypeOption<int?, int?>(false, LogicalOperator.And, null).Result);
        }

        [Fact]
        public void Not_Type_Should_Should_Return_Correct_Result_When_Chained_And_Source_Is_Not_Type()
        {
            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.Or, "Text").Result);

            Assert.True(GetNotTypeOption<object, int>(true, LogicalOperator.And, "Text").Result);
            Assert.False(GetNotTypeOption<object, int>(false, LogicalOperator.And, "Text").Result);
            Assert.True(GetNotTypeOption<object, int>(false, LogicalOperator.Or, "Text").Result);
        }

        private ITypeConditionResultOption<TTarget> GetTypeOption<TSource, TTarget>(TSource source)
            => source.If<TTarget>();

        private INotTypeConditionResultOption<object> GetNotTypeOption<TSource, TTarget>(TSource source)
            => source.If().Not<TTarget>();

        private INotTypeConditionResultOption<object> GetNotTypeOption<TSource, TTarget>(bool previousConditionResult, LogicalOperator logicalOperator, TSource source)
        {
            switch (logicalOperator)
            {
                case LogicalOperator.And:
                    return source.If().Fulfills(s => previousConditionResult).And.Not<TTarget>();
                case LogicalOperator.Or:
                    return source.If().Fulfills(s => previousConditionResult).Or.Not<TTarget>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicalOperator), logicalOperator, null);
            }
        }
    }
}