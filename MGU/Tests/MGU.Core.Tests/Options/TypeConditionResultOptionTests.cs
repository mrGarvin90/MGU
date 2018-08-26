namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Core.Helpers;
    using Interfaces.Options;
    using TestObjects;
    using Xunit;

    public class TypeConditionResultOptionTests
    {
        private const string Message = "Message";
        private static readonly Exception InnerException = new Exception("Inner exception.");

        #region Result

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Type()
        {
            Assert.True(GetOption<object, int>(5).Result);
            Assert.True(GetOption<int?, int?>(null).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Type()
        {
            Assert.False(GetOption<object, int>("Text").Result);
        }

        #endregion

        #region Cast

        [Fact]
        public void Cast_Should_Return_5_When_Source_Is_Int()
        {
            Assert.Equal(5, TrueResultOption().Cast());
        }

        [Fact]
        public void Cast_Should_Return_0_When_Source_Is_Not_Int()
        {
            Assert.Equal(0, FalseResultOption().Cast());
        }

        #endregion

        #region Get

        [Fact]
        public void Get_Should_Return_42_When_Source_Is_Int()
        {
            Assert.Equal(42, TrueResultOption().Get(GetValue));

            int GetValue() => 42;
        }

        [Fact]
        public void Get_Should_Return_0_When_Source_Is_Not_Int()
        {
            Assert.Equal(0, FalseResultOption().Get(GetValue));

            int GetValue() => 42;
        }

        #endregion

        #region Invoke

        [Fact]
        public void Invoke_Should_Invoke_Action_And_Return_5_When_Source_Is_Int()
        {
            var invoked = false;
            Assert.Equal(5, TrueResultOption().Invoke(Action));
            Assert.True(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Invoke_Action_And_Actions_And_Return_5_When_Source_Is_Int()
        {
            var invoked1 = false;
            var invoked2 = false;
            var invoked3 = false;
            Assert.Equal(5, TrueResultOption().Invoke(Action1, Action2, Action3));
            Assert.True(invoked1);
            Assert.True(invoked2);
            Assert.True(invoked3);

            void Action1() => invoked1 = true;
            void Action2() => invoked2 = true;
            void Action3() => invoked3 = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_And_Return_0_When_Source_Is_Not_Int()
        {
            var invoked = false;
            Assert.Equal(0, FalseResultOption().Invoke(Action));
            Assert.False(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_Or_Actions_And_Return_0_When_Source_Is_Not_Int()
        {
            var invoked1 = false;
            var invoked2 = false;
            var invoked3 = false;
            Assert.Equal(0, FalseResultOption().Invoke(Action1, Action2, Action3));
            Assert.False(invoked1);
            Assert.False(invoked2);
            Assert.False(invoked3);

            void Action1() => invoked1 = true;
            void Action2() => invoked2 = true;
            void Action3() => invoked3 = true;
        }

        #endregion

        #region Set

        [Fact]
        public void Set_Should_Set_Other_To_5_And_Return_5_When_Source_Is_Int()
        {
            var other = -1;
            Assert.Equal(5, TrueResultOption().Set(ref other));
            Assert.Equal(5, other);
        }

        [Fact]
        public void Set_Should_Not_Set_Other_To_5_And_Return_0_When_Source_Is_Not_Int()
        {
            var other = -1;
            Assert.Equal(0, FalseResultOption().Set(ref other));
            Assert.Equal(-1, other);
        }

        #endregion

        #region Then

        [Fact]
        public void Then_Should_Return_Other_Value_When_Source_Is_Int()
        {
            Assert.Equal(42, TrueResultOption().Then(42));
        }

        [Fact]
        public void Then_Should_Return_Default_Value_When_Source_Is_Not_Int()
        {
            Assert.Equal(0, FalseResultOption().Then(42));
        }

        #endregion

        #region Throw

        [Fact]
        public void Throw_Should_Throw_Exception_When_Condition_Is_True()
        {
            var exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>());
            Assert.NotNull(exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>(Message));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>(Message, InnerException));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(InnerException, exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>(null, null));
            Assert.NotNull(exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>(new Type[0], new object[0]));
            Assert.NotNull(exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw<TestException>(new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Throw_Should_Not_Throw_Exception_When_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().Throw<TestException>());
            Assert.Equal(0, FalseResultOption().Throw<TestException>(Message));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(Message, InnerException));

            Assert.Equal(0, FalseResultOption().Throw<TestException>(null, null));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(new Type[0], new object[0]));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }));
        }

        [Fact]
        public void Throw_Should_Throw_CouldNotCreateExceptionInstanceException_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_True()
        {
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(42));
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(new[] { typeof(int) }, new object[] { 42 }));
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(new[] { typeof(int) }, new object[0]));
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(new[] { typeof(int) }, null));
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(new Type[0], new object[] { 42 }));
            Assert.Throws<CouldNotCreateInstanceException>(() => TrueResultOption().Throw<TestException>(null, new object[] { 42 }));
        }

        [Fact]
        public void Throw_Should_Not_Throw_CouldNotCreateExceptionInstanceException_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().Throw<TestException>(42));

            Assert.Equal(0, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, new object[] { 42 }));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, new object[0]));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, null));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(new Type[0], new object[] { 42 }));
            Assert.Equal(0, FalseResultOption().Throw<TestException>(null, new object[] { 42 }));
        }

        #endregion

        #region ThrowOrDefault

        [Fact]
        public void ThrowOrDefault_Should_Throw_Exception_When_Condition_Is_True()
        {
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm), null, null);

            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, null, null), null, null);
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new Type[0], new object[0]), null, null);
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, null, new object[0]), null, null);
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new Type[0], null), null, null);

            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, Message), Message, null);
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new[] { typeof(string) }, new object[] { Message }), Message, null);

            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, Message, InnerException), Message, InnerException);
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }), Message, InnerException);
        }

        [Fact]
        public void ThrowOrDefault_Should_Not_Throw_Exception_When_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, Message));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, Message, InnerException));

            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, null, null));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new Type[0], new object[0]));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }));
        }

        [Fact]
        public void ThrowOrDefault_Should_Throw_Default_Exception_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_True()
        {
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, 42));

            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new[] { typeof(int) }, new object[] { 42 }));
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new[] { typeof(int) }, new object[0]));
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new[] { typeof(int) }, null));
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, new Type[0], new object[] { 42 }));
            AssertThrows(dm => TrueResultOption().ThrowOrDefault<TestException>(dm, null, new object[] { 42 }));
        }

        [Fact]
        public void ThrowOrDefault_Should_Not_Throw_Default_Exception_When_Exception_Parameters_Are_Not_Valid_And_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, 42));

            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, new object[] { 42 }));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, new object[0]));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, null));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, new Type[0], new object[] { 42 }));
            Assert.Equal(0, FalseResultOption().ThrowOrDefault<TestException>(null, null, new object[] { 42 }));
        }

        #endregion

        #region Throw

        [Fact]
        public void Should_Throw_TestException_When_Condition_Is_True()
        {
            var exception = Assert.Throws<TestException>(() => TrueResultOption().Throw(new TestException(Message)));
            Assert.Equal(Message, exception.Message);
            Assert.Null(exception.InnerException);

            exception = Assert.Throws<TestException>(() => TrueResultOption().Throw(new TestException(Message, InnerException)));
            Assert.Equal(Message, exception.Message);
            Assert.Equal(InnerException, exception.InnerException);
        }

        [Fact]
        public void Should_Throw_ExceptionIsNullException_When_Exception_Is_Null_When_Condition_Is_True()
        {
            Assert.Throws<ExceptionIsNullException>(() => TrueResultOption().Throw((TestException)null));
        }

        [Fact]
        public void Should_Not_Throw_TestException_When_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().Throw(new TestException(Message)));
            Assert.Equal(0, FalseResultOption().Throw(new TestException(Message, InnerException)));
        }

        [Fact]
        public void Should_Not_Throw_ExceptionIsNullException_When_Exception_Is_Null_When_Condition_Is_False()
        {
            Assert.Equal(0, FalseResultOption().Throw((TestException)null));
        }

        #endregion

        #region Helpers

        private ITypeConditionResultOption<int> TrueResultOption()
            => ((object)5).If().Type<int>();

        private ITypeConditionResultOption<int> FalseResultOption()
            => new object().If().Type<int>();

        private ITypeConditionResultOption<TTarget> GetOption<TSource, TTarget>(TSource source)
            => source.If().Type<TTarget>();

        private void AssertThrows(Func<DefaultMessage, object> func, string message, Exception innerException)
        {
            var defaultMessage = DefaultMessage.New("Default message.");
            AssertException(Assert.Throws<TestException>(() => func(defaultMessage)));
            defaultMessage = null;
            AssertException(Assert.Throws<TestException>(() => func(defaultMessage)));

            void AssertException(Exception exception)
            {
                if (message is null)
                {
                    Assert.NotNull(exception.Message);
                    if (defaultMessage != null)
                        Assert.NotEqual(defaultMessage.ToString(), exception.Message);
                }
                else
                {
                    Assert.Equal(message, exception.Message);
                }

                if (innerException is null)
                    Assert.Null(exception.InnerException);
                else
                    Assert.Equal(innerException, exception.InnerException);
            }
        }

        private void AssertThrows(Func<DefaultMessage, object> func)
        {
            var defaultMessage = DefaultMessage.New("Default message.");
            AssertException(Assert.Throws<TestException>(() => func(defaultMessage)));
            defaultMessage = null;
            AssertException(Assert.Throws<TestException>(() => func(defaultMessage)));

            void AssertException(Exception exception)
            {
                if (defaultMessage is null)
                    Assert.NotNull(exception.Message);
                else
                    Assert.Equal(defaultMessage.ToString(), exception.Message);
                Assert.Null(exception.InnerException);
            }
        }

        #endregion
    }
}