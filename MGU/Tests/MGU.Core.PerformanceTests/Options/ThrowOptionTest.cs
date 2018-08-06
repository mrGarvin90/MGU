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
        public void ThrowArgumentShouldPass()
        {
            object source = null;
            const string message = "Message",
                         paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Argument(message)",
                    () => source.If().Null.Throw().Argument(message),
                    6000,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName)",
                    () => source.If().Null.Throw().Argument(message, paramName),
                    6000,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, innerException)",
                    () => source.If().Null.Throw().Argument(message, innerException),
                    6000,
                    IgnoreArgument)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName, innerException)",
                    () => source.If().Null.Throw().Argument(message, paramName, innerException),
                    6000,
                    IgnoreArgument)
                .RunAll();
        }

        [Test]
        public void ThrowNullShouldPass()
        {
            object source = null;
            const string message = "Message",
                         paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Null(paramName)",
                    () => source.If().Null.Throw().Null(paramName),
                    6000,
                    IgnoreNull)
                .Add(
                    "source.If().Null.Throw().Null(paramName, message)",
                    () => source.If().Null.Throw().Null(paramName, message),
                    6000,
                    IgnoreNull)
                .Add(
                    "source.If().Null.Throw().Null(message, innerException)",
                    () => source.If().Null.Throw().Null(message, innerException),
                    6000,
                    IgnoreNull)
                .RunAll();
        }

        [Test]
        public void ThrowOutOfRangeShouldPass()
        {
            object source = null;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().OutOfRange(message)",
                    () => source.If().Null.Throw().OutOfRange(paramName),
                    6000,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, message),
                    6000,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, null, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, null, message),
                    6000,
                    IgnoreOutOfRange)
                .Add(
                    "source.If().Null.Throw().OutOfRange(message, innerException)",
                    () => source.If().Null.Throw().OutOfRange(message, innerException),
                    6000,
                    IgnoreOutOfRange)
                .RunAll();
        }

        [Test]
        public void ThrowInvalidOperationShouldPass()
        {
            object source = null;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message)",
                    () => source.If().Null.Throw().InvalidOperation(message),
                    6000,
                    IgnoreInvalidOperation)
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message, innerException)",
                    () => source.If().Null.Throw().InvalidOperation(message, innerException),
                    6000,
                    IgnoreInvalidOperation)
                .RunAll();
        }

        [Test]
        public void ThrowExceptionShouldPass()
        {
            object source = null;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Exception(message)",
                    () => source.If().Null.Throw().Exception(message),
                    6000,
                    IgnoreException)
                .Add(
                    "source.If().Null.Throw().Exception(message, innerException)",
                    () => source.If().Null.Throw().Exception(message, innerException),
                    6000,
                    IgnoreException)
                .RunAll();
        }

        #endregion

        #region DoNotThrow

        [Test]
        public void DoNotThrowArgumentShouldPass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Argument(message)",
                    () => source.If().Null.Throw().Argument(message),
                    45)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName)",
                    () => source.If().Null.Throw().Argument(message, paramName),
                    45)
                .Add(
                    "source.If().Null.Throw().Argument(message, innerException)",
                    () => source.If().Null.Throw().Argument(message, innerException),
                    45)
                .Add(
                    "source.If().Null.Throw().Argument(message, paramName, innerException)",
                    () => source.If().Null.Throw().Argument(message, paramName, innerException),
                    45)
                .RunAll();
        }

        [Test]
        public void DoNotThrowNullShouldPass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Null(paramName)",
                    () => source.If().Null.Throw().Null(paramName),
                    45)
                .Add(
                    "source.If().Null.Throw().Null(paramName, message)",
                    () => source.If().Null.Throw().Null(paramName, message),
                    45)
                .Add(
                    "source.If().Null.Throw().Null(message, innerException)",
                    () => source.If().Null.Throw().Null(message, innerException),
                    45)
                .RunAll();
        }

        [Test]
        public void DoNotThrowOutOfRangeShouldPass()
        {
            object source = 5;
            const string message = "Message",
                paramName = "Param";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().OutOfRange(message)",
                    () => source.If().Null.Throw().OutOfRange(paramName),
                    45)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, message),
                    45)
                .Add(
                    "source.If().Null.Throw().OutOfRange(paramName, 5, message)",
                    () => source.If().Null.Throw().OutOfRange(paramName, 5, message),
                    45)
                .Add(
                    "source.If().Null.Throw().OutOfRange(message, innerException)",
                    () => source.If().Null.Throw().OutOfRange(message, innerException),
                    45)
                .RunAll();
        }

        [Test]
        public void DoNotThrowInvalidOperationShouldPass()
        {
            object source = 5;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message)",
                    () => source.If().Null.Throw().InvalidOperation(message),
                    45)
                .Add(
                    "source.If().Null.Throw().InvalidOperation(message, innerException)",
                    () => source.If().Null.Throw().InvalidOperation(message, innerException),
                    45)
                .RunAll();
        }

        [Test]
        public void DoNotThrowExceptionShouldPass()
        {
            object source = 5;
            const string message = "Message";
            var innerException = new Exception();

            NewTestCollection()
                .Add(
                    "source.If().Null.Throw().Exception(message)",
                    () => source.If().Null.Throw().Exception(message),
                    45)
                .Add(
                    "source.If().Null.Throw().Exception(message, innerException)",
                    () => source.If().Null.Throw().Exception(message, innerException),
                    45)
                .RunAll();
        }

        #endregion
    }
}