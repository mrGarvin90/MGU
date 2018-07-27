﻿namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Helpers;
    using Microsoft.CSharp.RuntimeBinder;
    using TestObjects;
    using Xunit;

    public class ConditionResultOptionTests
    {
        private const string Message = "Message";

        [Fact]
        public void Result_Should_Return_True_When_Condition_Is_True()
        {
            Assert.True(5.If().Fulfills(s => true).Result);
        }

        [Fact]
        public void Result_Should_Return_False_When_Condition_Is_False()
        {
            Assert.False(5.If().Fulfills(s => false).Result);
        }

        [Fact]
        public void CastTo_Should_Return_Correct_Values()
        {
            object source = 5;
            Assert.Equal(5, source.If().Fulfills(s => true).Cast.To<int>());
            Assert.Equal(5, source.If().Fulfills(s => true).Cast.To<int>(true));

            source = -1;
            Assert.Equal(-1, source.If().Fulfills(s => true).Cast.To<int>());
            Assert.Equal(-1, source.If().Fulfills(s => true).Cast.To<int>(true));
            Assert.Equal(uint.MaxValue, source.If().Fulfills(s => true).Cast.To<uint>(true));
        }

        [Fact]
        public void CastTo_Should_Throw_Exceptions()
        {
            object source = null;
            Assert.Throws<NullReferenceException>(() => source.If().Fulfills(s => true).Cast.To<int>());
            Assert.Throws<RuntimeBinderException>(() => source.If().Fulfills(s => true).Cast.To<int>(true));

            source = 5;
            Assert.Throws<InvalidCastException>(() => source.If().Fulfills(s => true).Cast.To<uint>());
        }

        [Fact]
        public void CastTo_Should_Return_Default_Value()
        {
            object source = null;
            Assert.Equal(0, source.If().Fulfills(s => false).Cast.To<int>());
            Assert.Equal(0, source.If().Fulfills(s => false).Cast.To<int>(true));

            source = 5;
            Assert.Equal((uint) 0, source.If().Fulfills(s => false).Cast.To<uint>());
        }

        [Fact]
        public void CastToOrDefault_Should_Return_Correct_Value()
        {
            object source = 5;
            Assert.Equal(5, source.If().Fulfills(s => true).Cast.ToOrDefault<int>());
            Assert.Equal(5, source.If().Fulfills(s => true).Cast.ToOrDefault<int>(true));

            source = -1;
            Assert.Equal(-1, source.If().Fulfills(s => true).Cast.ToOrDefault<int>());
            Assert.Equal(-1, source.If().Fulfills(s => true).Cast.ToOrDefault<int>(true));
            Assert.Equal(uint.MaxValue, source.If().Fulfills(s => true).Cast.ToOrDefault<uint>(true));
        }

        [Fact]
        public void CastToOrDefault_Should_Return_Default_Value()
        {
            object source = null;
            Assert.Equal(0, source.If().Fulfills(s => true).Cast.ToOrDefault<int>());
            Assert.Equal(0, source.If().Fulfills(s => true).Cast.ToOrDefault<int>(true));
            Assert.Equal(0, source.If().Fulfills(s => false).Cast.ToOrDefault<int>());
            Assert.Equal(0, source.If().Fulfills(s => false).Cast.ToOrDefault<int>(true));

            source = 5;
            Assert.Equal((uint) 0, source.If().Fulfills(s => true).Cast.ToOrDefault<uint>());
            Assert.Equal((uint) 0, source.If().Fulfills(s => false).Cast.ToOrDefault<uint>());
        }

        [Fact]
        public void Then_Should_Return_Other_Value_When_Condition_Is_True()
        {
            var actual = 5.If().Fulfills(s => true).Then(42);
            Assert.Equal(42, actual);
        }

        [Fact]
        public void Then_Should_Return_Same_Value_When_Condition_Is_False()
        {
            var actual = 5.If().Fulfills(s => false).Then(42);
            Assert.Equal(5, actual);
        }

        [Fact]
        public void Get_Should_Invoke_Func_And_Return_Other_Value_When_Condition_Is_True()
        {
            var invoked = false;
            var actual = 5.If().Fulfills(s => true).Get(Func);
            Assert.Equal(42, actual);
            Assert.True(invoked);

            int Func()
            {
                invoked = true;
                return 42;
            }
        }

        [Fact]
        public void Get_Should_Not_Invoke_Func_And_Return_Same_Value_When_Condition_Is_False()
        {
            var invoked = false;
            var actual = 5.If().Fulfills(s => false).Get(Func);
            Assert.Equal(5, actual);
            Assert.False(invoked);

            int Func()
            {
                invoked = true;
                return 42;
            }
        }

        [Fact]
        public void Invoke_Should_Invoke_Action_And_Return_Same_Value_When_Condition_Is_True()
        {
            var invoked = false;
            var actual = 5.If().Fulfills(s => true).Invoke(Action);
            Assert.Equal(5, actual);
            Assert.True(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_And_Return_Same_Value_When_Condition_Is_False()
        {
            var invoked = false;
            var actual = 5.If().Fulfills(s => false).Invoke(Action);
            Assert.Equal(5, actual);
            Assert.False(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Set_Should_Set_Other_And_Return_Same_Value_When_Condition_Is_True()
        {
            var other = 0;
            var actual = 5.If().Fulfills(s => true).Set(ref other);
            Assert.Equal(5, actual);
            Assert.Equal(5, other);
        }

        [Fact]
        public void Set_Should_Not_Set_Other_And_Return_Same_Value_When_Condition_Is_False()
        {
            var other = 0;
            var actual = 5.If().Fulfills(s => false).Set(ref other);
            Assert.Equal(5, actual);
            Assert.Equal(0, other);
        }

        [Fact]
        public void Throw_Should_Throw_Exception_When_Condition_Is_True()
        {
            var exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).Throw<Exception>());
            Assert.NotNull(exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).Throw<Exception>(Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            var innerException = new Exception("Inner exception.");
            exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).Throw<Exception>(Message, innerException));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void Throw_Should_Not_Throw_Exception_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw<Exception>());
        }

        [Fact]
        public void Throw_Should_Throw_CouldNotCreateExceptionInstanceException_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_True()
        {
            Assert.Throws<CouldNotCreateInstanceException>(() => 5.If().Fulfills(s => true).Throw<Exception>(42));
        }

        [Fact]
        public void Throw_Should_Not_Throw_CouldNotCreateExceptionInstanceException_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw<Exception>(42));
        }

        [Fact]
        public void ThrowOrDefault_Should_Throw_Exception_When_Condition_Is_True()
        {
            var exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).ThrowOrDefault<Exception>(null));
            Assert.NotNull(exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).ThrowOrDefault<Exception>(null, Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            var innerException = new Exception("Inner exception.");
            exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).ThrowOrDefault<Exception>(null, Message, innerException));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void ThrowOrDefault_Should_Not_Throw_Exception_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).ThrowOrDefault<Exception>(null));
        }

        [Fact]
        public void ThrowOrDefault_Should_Throw_Default_Exception_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_True()
        {
            var exception = Assert.Throws<Exception>(() => 5.If().Fulfills(s => true).ThrowOrDefault<Exception>(DefaultMessage.New(Message), 42));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ThrowOrDefault_Should_Not_Throw_Default_Exception_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).ThrowOrDefault<Exception>(null, 42));
        }

        [Fact]
        public void Should_Throw_TestException_When_Condition_Is_True()
        {
            var innerException = new Exception("Inner exception.");
            var exception = Assert.Throws<TestException>(() => 5.If().Fulfills(s => true).Throw(new TestException(Message)));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => 5.If().Fulfills(s => true).Throw(new TestException(Message, innerException)));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void Should_Throw_ExceptionIsNullException_When_Exception_Is_Null_When_Condition_Is_True()
        {
            Assert.Throws<ExceptionIsNullException>(() => 5.If().Fulfills(s => true).Throw((Exception) null));
        }

        [Fact]
        public void Should_Not_Throw_TestException_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw(new TestException(Message)));

            Assert.Equal(5, 5.If().Fulfills(s => false).Throw(new TestException(Message, new Exception("Inner exception."))));
        }

        [Fact]
        public void Should_Not_Throw_ExceptionIsNullException_When_Exception_Is_Null_When_Condition_Is_False()
        {
            Assert.Equal(5, 5.If().Fulfills(s => false).Throw((Exception) null));
        }
    }
}