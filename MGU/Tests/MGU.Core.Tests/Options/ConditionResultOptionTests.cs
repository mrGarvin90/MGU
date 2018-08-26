namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Exceptions;
    using Core.Extensions.If;
    using Core.Helpers;
    using Interfaces.Options;
    using Microsoft.CSharp.RuntimeBinder;
    using TestObjects;
    using Xunit;

    public class ConditionResultOptionTests
    {
        private const string Message = "Message";
        private static readonly Exception InnerException = new Exception("Inner exception.");

        #region Result

        [Fact]
        public void Result_Should_Return_True_When_Condition_Is_True()
        {
            Assert.True(TrueResultOption().Result);
        }

        [Fact]
        public void Result_Should_Return_False_When_Condition_Is_False()
        {
            Assert.False(FalseResultOption().Result);
        }

        #endregion

        #region CastTo

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
            Assert.Equal((uint)0, source.If().Fulfills(s => false).Cast.To<uint>());
        }

        #endregion

        #region CastToOrDefault

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
            Assert.Equal((uint)0, source.If().Fulfills(s => true).Cast.ToOrDefault<uint>());
            Assert.Equal((uint)0, source.If().Fulfills(s => false).Cast.ToOrDefault<uint>());
        }

        #endregion

        #region Then

        [Fact]
        public void Then_Should_Return_Other_Value_When_Condition_Is_True()
        {
            Assert.Equal(42, TrueResultOption().Then(42));
        }

        [Fact]
        public void Then_Should_Return_Source_Value_When_Condition_Is_False()
        {
            Assert.Equal(5, FalseResultOption().Then(42));
        }

        #endregion

        #region Get

        [Fact]
        public void Get_Should_Invoke_Func_And_Return_Other_Value_When_Condition_Is_True()
        {
            var invoked = false;
            Assert.Equal(42, TrueResultOption().Get(Func));
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
            Assert.Equal(5, FalseResultOption().Get(Func));
            Assert.False(invoked);

            int Func()
            {
                invoked = true;
                return 42;
            }
        }

        [Fact]
        public void Get_Should_Throw_ArgumentNullException_When_Func_Is_Null_And_Condition_Is_True()
        {
            Assert.Throws<ArgumentNullException>(() => TrueResultOption().Get(null));
        }

        [Fact]
        public void Get_Should_Not_Throw_ArgumentNullException_When_Func_Is_Null_And_Condition_Is_False()
        {
            Assert.Equal(5, FalseResultOption().Get(null));
        }

        #endregion

        #region Invoke

        [Fact]
        public void Invoke_Should_Invoke_Action_And_Return_Same_Value_When_Condition_Is_True()
        {
            var invoked = false;
            Assert.Equal(5, TrueResultOption().Invoke(Action));
            Assert.True(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Invoke_Action_And_Actions_And_Return_Same_Value_When_Condition_Is_True()
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
        public void Invoke_Should_Invoke_Action_But_Not_Actions_If_Null_And_Return_Same_Value_When_Condition_Is_True()
        {
            var invoked = false;
            Assert.Equal(5, TrueResultOption().Invoke(Action, null));
            Assert.True(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_And_Return_Same_Value_When_Condition_Is_False()
        {
            var invoked = false;
            Assert.Equal(5, FalseResultOption().Invoke(Action));
            Assert.False(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_And_Actions_And_Return_Same_Value_When_Condition_Is_False()
        {
            var invoked1 = false;
            var invoked2 = false;
            var invoked3 = false;
            Assert.Equal(5, FalseResultOption().Invoke(Action1, Action2, Action3));
            Assert.False(invoked1);
            Assert.False(invoked2);
            Assert.False(invoked3);

            void Action1() => invoked1 = true;
            void Action2() => invoked2 = true;
            void Action3() => invoked3 = true;
        }

        [Fact]
        public void Invoke_Should_Not_Invoke_Action_And_Not_Actions_If_Null_And_Return_Same_Value_When_Condition_Is_False()
        {
            var invoked = false;
            Assert.Equal(5, FalseResultOption().Invoke(Action, null));
            Assert.False(invoked);

            void Action() => invoked = true;
        }

        [Fact]
        public void Invoke_Should_Throw_ArgumentNullException_When_Action_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => TrueResultOption().Invoke(null));
        }

        [Fact]
        public void Invoke_Should_Not_Throw_ArgumentNullException_When_Action_Is_Null_And_Condition_Is_False()
        {
            Assert.Equal(5, FalseResultOption().Invoke(null));
        }

        [Fact]
        public void Invoke_Should_Throw_ArgumentException_When_Actions_Contain_Null()
        {
            Assert.Throws<ArgumentException>(() => TrueResultOption().Invoke(Action1, Action2, null));

            void Action1()
            {
            }

            void Action2()
            {
            }
        }

        [Fact]
        public void Invoke_Should_Not_Throw_ArgumentException_When_Actions_Contain_Null_And_Condition_Is_False()
        {
            var invoked1 = false;
            var invoked2 = false;
            Assert.Equal(5, FalseResultOption().Invoke(Action1, Action2, null));
            Assert.False(invoked1);
            Assert.False(invoked2);

            void Action1() => invoked1 = true;
            void Action2() => invoked2 = true;
        }

        #endregion

        #region Set

        [Fact]
        public void Set_Should_Set_Other_And_Return_Same_Value_When_Condition_Is_True()
        {
            var other = 0;
            var actual = TrueResultOption().Set(ref other);
            Assert.Equal(5, actual);
            Assert.Equal(5, other);
        }

        [Fact]
        public void Set_Should_Not_Set_Other_And_Return_Same_Value_When_Condition_Is_False()
        {
            var other = 0;
            var actual = FalseResultOption().Set(ref other);
            Assert.Equal(5, actual);
            Assert.Equal(0, other);
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
            Assert.Equal(5, FalseResultOption().Throw<TestException>());
            Assert.Equal(5, FalseResultOption().Throw<TestException>(Message));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(Message, InnerException));

            Assert.Equal(5, FalseResultOption().Throw<TestException>(null, null));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(new Type[0], new object[0]));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }));
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
            Assert.Equal(5, FalseResultOption().Throw<TestException>(42));

            Assert.Equal(5, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, new object[] { 42 }));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, new object[0]));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(new[] { typeof(int) }, null));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(new Type[0], new object[] { 42 }));
            Assert.Equal(5, FalseResultOption().Throw<TestException>(null, new object[] { 42 }));
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
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, Message));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, Message, InnerException));

            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, null, null));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new Type[0], new object[0]));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(string), typeof(Exception) }, new object[] { Message, InnerException }));
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
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, 42));

            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, new object[] { 42 }));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, new object[0]));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new[] { typeof(int) }, null));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, new Type[0], new object[] { 42 }));
            Assert.Equal(5, FalseResultOption().ThrowOrDefault<TestException>(null, null, new object[] { 42 }));
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
            Assert.Equal(5, FalseResultOption().Throw(new TestException(Message)));
            Assert.Equal(5, FalseResultOption().Throw(new TestException(Message, InnerException)));
        }

        [Fact]
        public void Should_Not_Throw_ExceptionIsNullException_When_Exception_Is_Null_When_Condition_Is_False()
        {
            Assert.Equal(5, FalseResultOption().Throw((TestException)null));
        }

        #endregion

        #region Helpers

        private IConditionResultOption<int> TrueResultOption()
            => 5.If().Fulfills(s => true);

        private IConditionResultOption<int> FalseResultOption()
            => 5.If().Fulfills(s => false);

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