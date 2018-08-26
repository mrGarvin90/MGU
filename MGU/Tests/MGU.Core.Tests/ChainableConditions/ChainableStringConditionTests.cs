namespace MGU.Core.Tests.ChainableConditions
{
    using System;
    using System.Collections.Generic;
    using Core.Exceptions;
    using Core.Extensions;
    using Core.Extensions.If;
    using Interfaces.ChainableConditions.Enumerable;
    using Xunit;

    public class ChainableStringConditionTests
    {
        private IEnumerable<string> StringCollection { get; } = new[] { "This", " ", "is", " ", "a", " ", "Test", "123456" };

        #region WhiteSpace

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
            var source = string.Empty;
            Assert.False(source.If().WhiteSpace.Result);

            source = "6";
            Assert.False(source.If().WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Whitespace()
        {
            var source = string.Empty;
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

        #endregion

        #region Null.Or.WhiteSpace

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

        #endregion

        #region StartsWith And StartWith

        [Fact]
        public void Result_Should_Be_True_When_Source_Starts_With_Value()
        {
            var source = "This is a Test";
            var value = "This";
            var character = 'T';
            Assert.True(source.If().StartsWith(value).Result);
            Assert.True(source.If().StartsWith(value.ToLower(), true).Result);
            Assert.True(source.If().StartsWith(character).Result);
            Assert.True(source.If().StartsWith(character.ToLower(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Does_Not_Start_With_Value()
        {
            var source = "This is a Test";
            var value1 = "this";
            var value2 = "Something";
            var character1 = 't';
            var character2 = 'S';
            Assert.False(source.If().StartsWith(value1).Result);
            Assert.False(source.If().StartsWith(value2, true).Result);
            Assert.False(source.If().StartsWith(character1).Result);
            Assert.False(source.If().StartsWith(character2, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Does_Not_Start_With_Value()
        {
            var source = "This is a Test";
            var value1 = "this";
            var value2 = "Something";
            var character1 = 't';
            var character2 = 'S';
            Assert.True(source.If().DoesNot.StartWith(value1).Result);
            Assert.True(source.If().DoesNot.StartWith(value2, true).Result);
            Assert.True(source.If().DoesNot.StartWith(character1).Result);
            Assert.True(source.If().DoesNot.StartWith(character2, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Starts_With_Value()
        {
            var source = "This is a Test";
            var value = "This";
            var character = 'T';
            Assert.False(source.If().DoesNot.StartWith(value).Result);
            Assert.False(source.If().DoesNot.StartWith(value.ToLower(), true).Result);
            Assert.False(source.If().DoesNot.StartWith(character).Result);
            Assert.False(source.If().DoesNot.StartWith(character.ToLower(), true).Result);
        }

        #endregion

        #region EndsWith And EndWith

        [Fact]
        public void Result_Should_Be_True_When_Source_Ends_With_Value()
        {
            var source = "This is a Test";
            var value = "Test";
            var character = 't';
            Assert.True(source.If().EndsWith(value).Result);
            Assert.True(source.If().EndsWith(value.ToLower(), true).Result);
            Assert.True(source.If().EndsWith(character).Result);
            Assert.True(source.If().EndsWith(character.ToUpper(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Does_Not_End_With_Value()
        {
            var source = "This is a Test";
            var value1 = "test";
            var value2 = "Something";
            var character1 = 'T';
            var character2 = 's';
            Assert.False(source.If().EndsWith(value1).Result);
            Assert.False(source.If().EndsWith(value2, true).Result);
            Assert.False(source.If().EndsWith(character1).Result);
            Assert.False(source.If().EndsWith(character2, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Does_Not_End_With_Value()
        {
            var source = "This is a Test";
            var value1 = "test";
            var value2 = "Something";
            var character1 = 'T';
            var character2 = 's';
            Assert.True(source.If().DoesNot.EndWith(value1).Result);
            Assert.True(source.If().DoesNot.EndWith(value2, true).Result);
            Assert.True(source.If().DoesNot.EndWith(character1).Result);
            Assert.True(source.If().DoesNot.EndWith(character2, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Ends_With_Value()
        {
            var source = "This is a Test";
            var value = "Test";
            var character = 't';
            Assert.False(source.If().DoesNot.EndWith(value).Result);
            Assert.False(source.If().DoesNot.EndWith(value.ToLower(), true).Result);
            Assert.False(source.If().DoesNot.EndWith(character).Result);
            Assert.False(source.If().DoesNot.EndWith(character.ToUpper(), true).Result);
        }

        #endregion

        #region In

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Other()
        {
            var source = "is a ";
            var other = "This is a Test";
            Assert.True(source.If().In(other).Result);
            Assert.True(source.If().In(other.ToUpper(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_In_Other()
        {
            var source = "something";
            var other = "This is a Test";
            Assert.False(source.If().In(other).Result);
            Assert.False(source.If().In(other.ToUpper(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_In_Other()
        {
            var source = "something";
            var other = "This is a Test";
            Assert.True(source.If().Not.In(other).Result);
            Assert.True(source.If().Not.In(other.ToUpper(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Other()
        {
            var source = "is a ";
            var other = "This is a Test";
            Assert.False(source.If().Not.In(other).Result);
            Assert.False(source.If().Not.In(other.ToUpper(), true).Result);
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

        #endregion

        #region Contains And Contain

        [Fact]
        public void Result_Should_Be_True_When_Source_Contains_Value()
        {
            var source = "This is a Test";
            var value = "is a ";
            var character = 'a';
            Assert.True(source.If().Contains(value).Result);
            Assert.True(source.If().Contains(value.ToUpper(), true).Result);
            Assert.True(source.If().Contains(character).Result);
            Assert.True(source.If().Contains(character.ToUpper(), true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Does_Not_Contain_Value()
        {
            var source = "This is a Test";
            var value = "bananas";
            var character = 'b';
            Assert.False(source.If().Contains(value).Result);
            Assert.False(source.If().Contains(value.ToUpper(), true).Result);
            Assert.False(source.If().Contains(character).Result);
            Assert.False(source.If().Contains(character.ToUpper(), true).Result);
            Assert.False(source.If().Contains(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Does_Not_Contain_Value()
        {
            var source = "This is a Test";
            var value = "bananas";
            var character = 'b';
            Assert.True(source.If().DoesNot.Contain(value).Result);
            Assert.True(source.If().DoesNot.Contain(value.ToUpper(), true).Result);
            Assert.True(source.If().DoesNot.Contain(character).Result);
            Assert.True(source.If().DoesNot.Contain(character.ToUpper(), true).Result);
            Assert.True(source.If().DoesNot.Contain(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Contains_Value()
        {
            var source = "This is a Test";
            var value = "is a ";
            var character = 'a';
            Assert.False(source.If().DoesNot.Contain(value).Result);
            Assert.False(source.If().DoesNot.Contain(value.ToUpper(), true).Result);
            Assert.False(source.If().DoesNot.Contain(character).Result);
            Assert.False(source.If().DoesNot.Contain(character.ToUpper(), true).Result);
        }

        #endregion

        #region Length And Count

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is(6).Result);
            Assert.True(StringCondition().Count.Is(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Not_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is(2).Result);
            Assert.False(StringCondition().Count.Is(2).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Not_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is.Not(2).Result);
            Assert.True(StringCondition().Count.Is.Not(2).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.Not(6).Result);
            Assert.False(StringCondition().Count.Is.Not(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Less_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.LessThan(7).Result);
            Assert.True(StringCondition().Count.Is.LessThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Greater_Than_Or_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.LessThan(6).Result);
            Assert.False(StringCondition().Count.Is.LessThan(6).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.True(StringCondition().Length.Is.LessThanEqualTo(6).Result);
            Assert.True(StringCondition().Count.Is.LessThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Greater_Than_Value()
        {
            Assert.False(StringCondition().Length.Is.LessThanEqualTo(5).Result);
            Assert.False(StringCondition().Count.Is.LessThanEqualTo(5).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Greater_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.GreaterThan(5).Result);
            Assert.True(StringCondition().Count.Is.GreaterThan(5).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Less_Than_Or_Equal_To_Value()
        {
            Assert.False(StringCondition().Length.Is.GreaterThan(7).Result);
            Assert.False(StringCondition().Count.Is.GreaterThan(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Greater_Or_Equal_To_Than_Value()
        {
            Assert.True(StringCondition().Length.Is.GreaterThanEqualTo(6).Result);
            Assert.True(StringCondition().Count.Is.GreaterThanEqualTo(6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Less_Than_To_Value()
        {
            Assert.False(StringCondition().Length.Is.GreaterThanEqualTo(7).Result);
            Assert.False(StringCondition().Count.Is.GreaterThanEqualTo(7).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Within()
        {
            Assert.True(StringCondition().Length.Is.WithinRange(0, 6).Result);
            Assert.True(StringCondition().Count.Is.WithinRange(0, 6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Not_Within_Range()
        {
            Assert.False(StringCondition().Length.Is.WithinRange(7, 10).Result);
            Assert.False(StringCondition().Count.Is.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Length_Is_Not_Within_Range()
        {
            Assert.True(StringCondition().Length.Is.Not.WithinRange(7, 10).Result);
            Assert.True(StringCondition().Count.Is.Not.WithinRange(7, 10).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Length_Is_Within_Range()
        {
            Assert.False(StringCondition().Length.Is.Not.WithinRange(0, 6).Result);
            Assert.False(StringCondition().Count.Is.Not.WithinRange(0, 6).Result);
        }

        #endregion

        #region Null

        [Fact]
        public void Result_Should_Be_True_When_Source_String_Is_Null()
        {
            Assert.True(NullStringCondition().Null.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_String_Is_Not_Null()
        {
            Assert.False(StringCondition().Null.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_String_Is_Not_Null()
        {
            Assert.True(StringCondition().Not.Null.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_String_Is_Null()
        {
            Assert.False(NullStringCondition().Not.Null.Result);
        }

        #endregion

        #region EqualTo

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Are_Equal()
        {
            Assert.True(StringCondition().EqualTo("123456").Result);
            Assert.True(NullStringCondition().EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Are_Not_Equal()
        {
            Assert.False(StringCondition().EqualTo("abc").Result);
            Assert.False(StringCondition().EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_Other_Are_Not_Equal()
        {
            Assert.True(StringCondition().Not.EqualTo("abc").Result);
            Assert.True(StringCondition().Not.EqualTo(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_Other_Are_Equal()
        {
            Assert.False(StringCondition().Not.EqualTo("123456").Result);
            Assert.False(NullStringCondition().Not.EqualTo(null).Result);
        }

        #endregion

        #region Fulfills And Fulfill

        [Fact]
        public void Result_Should_Be_True_When_Source_Fulfills_Condition()
        {
            Assert.True(StringCondition().Fulfills(s => s.Length == 6).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Do_Not_Fulfill_Condition()
        {
            Assert.False(StringCondition().Fulfills(s => s.Length == 42).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Do_Not_Fulfill_Condition()
        {
            Assert.True(StringCondition().DoesNot.Fulfill(s => s.Length == 42).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Fulfills_Condition()
        {
            Assert.False(StringCondition().DoesNot.Fulfill(s => s.Length == 6).Result);
        }

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException_When_Condition_Is_Not_Valid()
        {
            var exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().Fulfills(null));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().DoesNot.Fulfill(null));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Fulfills(s => s.Length == 1));
            Assert.NotNull(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.Fulfill(s => s.Length == 1));
            Assert.NotNull(exception.InnerException);
        }

        #endregion

        #region In

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Collection()
        {
            Assert.True(StringCondition().In(StringCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_In_Collection()
        {
            Assert.False(StringCondition("abc").In(StringCollection).Result);
            Assert.False(NullStringCondition().In(StringCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_In_Collection()
        {
            Assert.True(StringCondition("abc").Not.In(StringCollection).Result);
            Assert.True(NullStringCondition().Not.In(StringCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Collection()
        {
            Assert.False(StringCondition().Not.In(StringCollection).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Collection_Is_Null()
        {
            Assert.False(StringCondition().In(null).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Collection_Is_Null()
        {
            Assert.True(StringCondition().Not.In(null).Result);
        }

        #endregion

        #region Empty

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Empty()
        {
            Assert.True(EmptyStringCondition().Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Not_Empty()
        {
            Assert.False(StringCondition().Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_The_Source_Is_Not_Empty()
        {
            Assert.True(StringCondition().Not.Empty.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_The_Source_Is_Empty()
        {
            Assert.False(EmptyStringCondition().Not.Empty.Result);
        }

        #endregion

        #region All

        [Fact]
        public void Result_Should_Be_True_When_All_Elements_In_The_Source_Satisfies_A_Condition()
        {
            Assert.True(StringCondition(new string('4', 6)).All(i => i == '4').Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_All_Elements_In_The_Source_Does_Not_Satisfy_A_Condition()
        {
            Assert.False(StringCondition().All(i => i == '4').Result);
        }

        #endregion

        #region Any

        [Fact]
        public void Result_Should_Be_True_When_Any_Element_In_The_Source_Satisfy_A_Condition()
        {
            Assert.True(StringCondition().Any(i => i == '4').Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Any_Element_In_The_Source_Does_Not_Satisfy_A_Condition()
        {
            Assert.False(StringCondition("123355").Any(i => i == '4').Result);
        }

        #endregion

        #region None

        [Fact]
        public void Result_Should_Be_True_When_None_Of_The_Elements_In_The_Source_Satisfy_A_Condition()
        {
            Assert.True(StringCondition().None(i => i == '7').Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Any_Element_In_The_Source_Satisfy_A_Condition()
        {
            Assert.False(StringCondition().None(i => i == '4').Result);
        }

        #endregion

        #region Throw

        [Fact]
        public void Should_Throw_ConditionEvaluationFailedException()
        {
            var exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().StartsWith('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().StartsWith(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.StartWith('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.StartWith(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().EndsWith('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().EndsWith(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.EndWith('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.EndWith(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Contains('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Contains(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.Contain('s'));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().DoesNot.Contain(string.Empty));
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().WhiteSpace);
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.LessThan(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.LessThanEqualTo(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.GreaterThan(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.GreaterThanEqualTo(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.WithinRange(5, 6));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.Not.WithinRange(5, 6));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is.Not(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Length.Is(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.LessThan(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.LessThanEqualTo(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.GreaterThan(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.GreaterThanEqualTo(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.WithinRange(5, 6));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.Not.WithinRange(5, 6));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is.Not(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Count.Is(5));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Empty);
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Not.Empty);
            Assert.IsType<NullReferenceException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().All(c => c == '4'));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().All(c => ((string)null).Contains(c)));
            Assert.NotNull(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().All(null));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().Any(c => c == '4'));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().Any(c => ((string)null).Contains(c)));
            Assert.NotNull(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().Any(null));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => NullStringCondition().None(c => c == '4'));
            Assert.IsType<ArgumentNullException>(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().None(c => ((string)null).Contains(c)));
            Assert.NotNull(exception.InnerException);

            exception = Assert.Throws<ConditionEvaluationFailedException>(() => StringCondition().None(null));
            Assert.NotNull(exception.InnerException);
        }

        #endregion

        #region And Or

        [Fact]
        public void Result_Should_Be_True_With_And()
        {
            Assert.True(StringCondition().StartsWith('1').And.EndsWith('6').Result);
            Assert.True(StringCondition().StartsWith('1').And.Contains('4').And.EndsWith('6').Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_And()
        {
            Assert.False(StringCondition().StartsWith('2').And.EndsWith('6').Result);
            Assert.False(StringCondition().StartsWith('1').And.EndsWith('5').Result);
            Assert.False(StringCondition().StartsWith('2').And.Contains('4').And.EndsWith('6').Result);
            Assert.False(StringCondition().StartsWith('1').And.Contains('7').And.EndsWith('6').Result);
            Assert.False(StringCondition().StartsWith('1').And.Contains('4').And.EndsWith('5').Result);
        }

        [Fact]
        public void Result_Should_Be_True_With_Or()
        {
            Assert.True(StringCondition().StartsWith('1').Or.EndsWith('6').Result);
            Assert.True(StringCondition().StartsWith('1').Or.Contains('4').Or.EndsWith('6').Result);
            Assert.True(StringCondition().StartsWith('2').Or.Contains('4').Or.EndsWith('6').Result);
            Assert.True(StringCondition().StartsWith('2').Or.Contains('7').Or.EndsWith('6').Result);
        }

        [Fact]
        public void Result_Should_Be_False_With_Or()
        {
            Assert.False(StringCondition().StartsWith('2').And.EndsWith('5').Result);
            Assert.False(StringCondition().StartsWith('2').And.Contains('7').And.EndsWith('7').Result);
        }

        #endregion

        #region Helpers

        private static IChainableStringCondition EmptyStringCondition()
            => string.Empty.If();

        private static IChainableStringCondition StringCondition(string source = "123456")
            => source.If();

        private static IChainableStringCondition NullStringCondition()
            => ((string)null).If();

        #endregion
    }
}