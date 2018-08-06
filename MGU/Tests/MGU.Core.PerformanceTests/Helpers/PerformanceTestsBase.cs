namespace MGU.Core.PerformanceTests.Helpers
{
    using System;

    /// <summary>
    /// The <see cref="PerformanceTestsBase"/> class.
    /// </summary>
    public abstract class PerformanceTestsBase
    {
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
            => new PerformanceTestCollection();
    }
}