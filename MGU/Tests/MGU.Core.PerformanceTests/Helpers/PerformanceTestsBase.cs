namespace MGU.Core.PerformanceTests.Helpers
{
    using System;

    /// <summary>
    /// The <see cref="PerformanceTestsBase"/> class.
    /// </summary>
    public abstract class PerformanceTestsBase
    {
        private readonly bool _skipAllTests;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceTestsBase"/> class.
        /// </summary>
        /// <param name="skipAllTests">If set to <c>true</c> all tests will be skipped.</param>
        protected PerformanceTestsBase(bool skipAllTests = false)
        {
            _skipAllTests = skipAllTests;
        }

        /// <summary>
        /// Gets the ignore <see cref="ArgumentException"/> function.
        /// </summary>
        protected static Func<Exception, bool> IgnoreArgument { get; } = e => e.GetType() == typeof(ArgumentException);

        /// <summary>
        /// Gets the ignore <see cref="ArgumentNullException"/> function.
        /// </summary>
        protected static Func<Exception, bool> IgnoreNull { get; } = e => e.GetType() == typeof(ArgumentNullException);

        /// <summary>
        /// Gets the ignore <see cref="ArgumentOutOfRangeException"/> function.
        /// </summary>
        protected static Func<Exception, bool> IgnoreOutOfRange { get; } = e => e.GetType() == typeof(ArgumentOutOfRangeException);

        /// <summary>
        /// Gets the ignore <see cref="InvalidOperationException"/> function.
        /// </summary>
        protected static Func<Exception, bool> IgnoreInvalidOperation { get; } = e => e.GetType() == typeof(InvalidOperationException);

        /// <summary>
        /// Gets the ignore <see cref="Exception"/> function.
        /// </summary>
        protected static Func<Exception, bool> IgnoreException { get; } = e => e.GetType() == typeof(Exception);

        /// <summary>
        /// Creates a new <see cref="PerformanceTestCollection"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="PerformanceTestCollection"/>.</returns>
        protected PerformanceTestCollection NewTestCollection()
            => new PerformanceTestCollection(_skipAllTests);
    }
}