namespace MGU.Core.PerformanceTests.Options
{
    using System;
    using Extensions.If;
    using Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class ThrowOptionTest : PerformanceTestsBase
    {
        #region Throw

        [Test]
        public void Throw_Argument_Should_Pass()
        {
            object source = null;
            const string message = "Message",
                         paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Argument(message)",
                    () => source.If().Null.Throw().Argument(message),
                    5400,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName)",
                    () => source.If().Null.Throw().Argument(message, paramName),
                    5400,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, innerException)",
                    () => source.If().Null.Throw().Argument(message, innerException),
                    5400,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName, innerException)",
                    () => source.If().Null.Throw().Argument(message, paramName, innerException),
                    5400,
                    IgnoreArgument)
                .RunAll();
        }

        [Test]
        public void Throw_Null_Should_Pass()
        {
            object source = null;
            const string message = "Message",
                         paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Null(paramName)",
                    () => source.If().Null.Throw().Null(paramName),
                    5400,
                    IgnoreNull)
                .Add(
                    "source.If().Null.Throw().Null(paramName, message)",
                    () => source.If().Null.Throw().Null(paramName, message),
                    5400,
                    IgnoreNull)
                .Add(
                    "source.If().Null.Throw().Null(message, innerException)",
                    () => source.If().Null.Throw().Null(message, innerException),
                    5400,
                    IgnoreNull)
                .RunAll();
        }

        [Test]
        public void Throw_OutOfRange_Should_Pass()
        {
            object source = null;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().OutOfRange(message)",
                    () => source.If().Null.Throw().OutOfRange(paramName),
                    5500,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, message),
                    5500,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, null, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, null, message),
                    5500,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(message, innerException)",
                    () => source.If().Null.Throw().OutOfRange(message, innerException),
                    5500,
                    IgnoreOutOfRange)
                .RunAll();
        }

        [Test]
        public void Throw_InvalidOperation_Should_Pass()
        {
            object source = null;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message)",
                    () => source.If().Null.Throw().InvalidOperation(message),
                    5400,
                    IgnoreInvalidOperation)
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message, innerException)",
                    () => source.If().Null.Throw().InvalidOperation(message, innerException),
                    5400,
                    IgnoreInvalidOperation)
                .RunAll();
        }

        [Test]
        public void Throw_Exception_Should_Pass()
        {
            object source = null;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Exception(message)",
                    () => source.If().Null.Throw().Exception(message),
                    5400,
                    IgnoreException)
                .Add(
                    "source.If().Null.Throw().Exception(message, innerException)",
                    () => source.If().Null.Throw().Exception(message, innerException),
                    5400,
                    IgnoreException)
                .RunAll();
        }

        #endregion

        #region DoNotThrow

        [Test]
        public void Do_Not_Throw_Argument_Should_Pass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Argument(message)",
                    () => source.If().Null.Throw().Argument(message),
                    20)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName)",
                    () => source.If().Null.Throw().Argument(message, paramName),
                    20)
                .Add(
                    "source.If().Null.Throw().Argument(message, innerException)",
                    () => source.If().Null.Throw().Argument(message, innerException),
                    20)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName, innerException)",
                    () => source.If().Null.Throw().Argument(message, paramName, innerException),
                    20)
                .RunAll();
        }

        [Test]
        public void Do_Not_Throw_Null_Should_Pass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Null(paramName)",
                    () => source.If().Null.Throw().Null(paramName),
                    20)
                .Add(
                    "source.If().Null.Throw().Null(paramName, message)",
                    () => source.If().Null.Throw().Null(paramName, message),
                    20)
                .Add(
                    "source.If().Null.Throw().Null(message, innerException)",
                    () => source.If().Null.Throw().Null(message, innerException),
                    20)
                .RunAll();
        }

        [Test]
        public void Do_Not_Throw_OutOfRange_Should_Pass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().OutOfRange(message)",
                    () => source.If().Null.Throw().OutOfRange(paramName),
                    20)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, message),
                    20)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, 5, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, 5, message),
                    20)
                .Add(
                    "source.If().Null.Throw().OutOfRange(message, innerException)",
                    () => source.If().Null.Throw().OutOfRange(message, innerException),
                    20)
                .RunAll();
        }

        [Test]
        public void Do_Not_Throw_InvalidOperation_Should_Pass()
        {
            object source = 5;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message)",
                    () => source.If().Null.Throw().InvalidOperation(message),
                    20)
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message, innerException)",
                    () => source.If().Null.Throw().InvalidOperation(message, innerException),
                    20)
                .RunAll();
        }

        [Test]
        public void Do_Not_Throw_Exception_Should_Pass()
        {
            object source = 5;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Exception(message)",
                    () => source.If().Null.Throw().Exception(message),
                    20)
                .Add(
                    "source.If().Null.Throw().Exception(message, innerException)",
                    () => source.If().Null.Throw().Exception(message, innerException),
                    20)
                .RunAll();
        }

        #endregion
    }
}