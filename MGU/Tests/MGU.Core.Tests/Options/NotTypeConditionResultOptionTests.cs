namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Extensions.If;
    using Interfaces.Options;
    using Xunit;

    public class NotTypeConditionResultOptionTests
    {
        #region Result

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Type()
        {
            Assert.True(GetOption<object, int>("Text").Result);
            Assert.True(GetOption<object, int>("Text").Use(DateTime.MaxValue).And.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Type()
        {
            Assert.False(GetOption<object, int>(5).Result);
            Assert.False(GetOption<int?, int?>(null).Result);

            Assert.False(GetOption<object, int>(5).Use(DateTime.MaxValue).And.Result);
            Assert.False(GetOption<int?, int?>(null).Use(DateTime.MaxValue).And.Result);
        }

        #endregion

        #region Helpers

        private INotTypeConditionResultOption<TSource> GetOption<TSource, TTarget>(TSource source)
            => source.If().Not.Type<TTarget>();

        #endregion
    }
}