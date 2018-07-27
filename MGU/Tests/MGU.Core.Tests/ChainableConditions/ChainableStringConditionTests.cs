namespace MGU.Core.Tests.ChainableConditions
{
    using Core.Exceptions;
    using Core.Extensions.If;
    using Interfaces.ChainableConditions.Enumerable;
    using Xunit;

    public class ChainableStringConditionTests
    {
        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Whitespace()
        {
            var source = " ";
            Assert.True(source.If().WhiteSpace.Result);

            source = "\r";
            Assert.True(source.If().WhiteSpace.Result);

            source = "\n";
            Assert.True(source.If().WhiteSpace.Result);

            source = "\t";
            Assert.True(source.If().WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Whitespace()
        {
            var source = "";
            Assert.False(source.If().WhiteSpace.Result);

            source = "6";
            Assert.False(source.If().WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Whitespace()
        {
            var source = "";
            Assert.True(source.If().Not.WhiteSpace.Result);

            source = "6";
            Assert.True(source.If().Not.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Whitespace()
        {
            var source = " ";
            Assert.False(source.If().Not.WhiteSpace.Result);

            source = "\r";
            Assert.False(source.If().Not.WhiteSpace.Result);

            source = "\n";
            Assert.False(source.If().Not.WhiteSpace.Result);

            source = "\t";
            Assert.False(source.If().Not.WhiteSpace.Result);

            source = "\t";
            Assert.False(source.If().Not.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Null_Empty_Or_Whitespace()
        {
            string source = null;
            Assert.True(source.If().Null.Or.WhiteSpace.Result);

            source = string.Empty;
            Assert.True(source.If().Null.Or.WhiteSpace.Result);

            source = "   ";
            Assert.True(source.If().Null.Or.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Null_Empty_Or_Whitespace()
        {
            var source = "Test";
            Assert.False(source.If().Null.Or.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Null_Empty_Or_Whitespace()
        {
            var source = "Test";
            Assert.True(source.If().Not.Null.Or.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Null_Empty_Or_Whitespace()
        {
            string source = null;
            Assert.False(source.If().Not.Null.Or.WhiteSpace.Result);

            source = string.Empty;
            Assert.False(source.If().Not.Null.Or.WhiteSpace.Result);

            source = "   ";
            Assert.False(source.If().Not.Null.Or.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Starts_With_Value()
        {
            var source = "This is a Test";
            Assert.True(source.If().StartsWith("This").Result);
            Assert.True(source.If().StartsWith("this", true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Do_Not_Start_With_Value()
        {
            var source = "This is a Test";
            Assert.False(source.If().StartsWith("this").Result);
            Assert.False(source.If().StartsWith(" ").Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Do_Not_Start_With_Value()
        {
            var source = "This is a Test";
            Assert.True(source.If().DoNot.StartWith("this").Result);
            Assert.True(source.If().DoNot.StartWith(" ").Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Starts_With_Value()
        {
            var source = "This is a Test";
            Assert.False(source.If().DoNot.StartWith("This").Result);
            Assert.False(source.If().DoNot.StartWith("this", true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Ends_With_Value()
        {
            var source = "This is a Test";
            Assert.True(source.If().EndsWith("Test").Result);
            Assert.True(source.If().EndsWith("test", true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Do_Not_End_With_Value()
        {
            var source = "This is a Test";
            Assert.False(source.If().EndsWith("test").Result);
            Assert.False(source.If().EndsWith(" ").Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Do_Not_End_With_Value()
        {
            var source = "This is a Test";
            Assert.True(source.If().DoNot.EndWith("test").Result);
            Assert.True(source.If().DoNot.EndWith(" ").Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Ends_With_Value()
        {
            var source = "This is a Test";
            Assert.False(source.If().DoNot.EndWith("Test").Result);
            Assert.False(source.If().DoNot.EndWith("test", true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Other()
        {
            var source = "is a ";
            var other = "This is a Test";
            Assert.True(source.If().In(other).Result);
            Assert.True(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_In_Other()
        {
            var source = "something";
            var other = "This is a Test";
            Assert.False(source.If().In(other).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_In_Other()
        {
            var source = "something";
            var other = "This is a Test";
            Assert.True(source.If().Not.In(other).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Other()
        {
            var source = "is a ";
            var other = "This is a Test";
            Assert.False(source.If().Not.In(other).Result);
            Assert.False(source.If().Not.In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Contains_Value()
        {
            var source = "This is a Test";
            var value = "is a ";
            Assert.True(source.If().Contains(value).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Do_Not_Contain_Value()
        {
            var source = "This is a Test";
            var value = "bananas";
            Assert.False(source.If().Contains(value).Result);
            Assert.False(source.If().Contains(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Do_Not_Contain_Value()
        {
            var source = "This is a Test";
            var value = "bananas";
            Assert.True(source.If().DoNot.Contain(value).Result);
            Assert.True(source.If().DoNot.Contain(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Contains_Value()
        {
            var source = "This is a Test";
            var value = "is a ";
            Assert.False(source.If().DoNot.Contain(value).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Null()
        {
            const string other = "Other";

            string source = null;
            Assert.False(source.If().In(other).Result);
            Assert.False(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Null()
        {
            const string other = "Other";

            string source = null;
            Assert.True(source.If().Not.In(other).Result);
            Assert.True(source.If().Not.In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Other_Is_Null()
        {
            const string other = null;

            var source = "SOURCE";
            Assert.False(source.If().In(other).Result);

            source = "source";
            Assert.False(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Other_Is_Null()
        {
            const string other = null;

            var source = "SOURCE";
            Assert.True(source.If().Not.In(other).Result);

            source = "source";
            Assert.True(source.If().Not.In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Is_Null()
        {
            const string other = null;

            string source = null;
            Assert.False(source.If().In(other).Result);
            Assert.False(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Is_Null()
        {
            const string other = null;

            string source = null;
            Assert.True(source.If().Not.In(other).Result);
            Assert.True(source.If().Not.In(other, true).Result);
        }

        #region Length

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Not_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is(2).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Not_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is.Not(2).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.Not(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Less_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.LessThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.LessThan(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is.LessThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Greater_Than_Value()
        {
            Assert.False(StringCondition().Length.Is.LessThanEqualTo(5).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Greater_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.GreaterThan(5).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.GreaterThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Greater_Or_Equal_To_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.GreaterThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Less_Than_To_Value()
        {
            Assert.False(StringCondition().Length.Is.GreaterThanEqualTo(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Within()
        {
            Assert.True(StringCondition().Length.Is.WithinRange(0, 6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Not_Within_Range()
        {
            Assert.False(StringCondition().Length.Is.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Not_Within_Range()
        {
            Assert.True(StringCondition().Length.Is.Not.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Within_Range()
        {
            Assert.False(StringCondition().Length.Is.Not.WithinRange(0, 6).Result);
        }

            #endregion

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException()
        {
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().StartsWith(""));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().StartsWith("", true));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoNot.StartWith(""));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoNot.StartWith("", true));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().EndsWith(""));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().EndsWith("", true));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoNot.EndWith(""));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoNot.EndWith("", true));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().WhiteSpace);

            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.LessThan(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.LessThanEqualTo(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.GreaterThan(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.GreaterThanEqualTo(5));

            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.Not(5));
            Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.Not.WithinRange(5, 6));
        }

        private static IChainableStringCondition StringCondition()
        {
            return "123456".If();
        }

        private static IChainableStringCondition NullStringCondition()
        {
            return ((string) null).If();
        }
    }
}