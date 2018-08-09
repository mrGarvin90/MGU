namespace MGU.Core.PerformanceTests.Helpers
{
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;
    using NUnit.Framework;

    /// <summary>
    /// The <see cref="PerformanceTest"/> class.
    /// </summary>
    internal sealed class PerformanceTest
    {
        private bool _skip;
        private bool _canBeSkipped;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceTest"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="action">The action to test.</param>
        /// <param name="maxMilliseconds">The maximum milliseconds.</param>
        /// <param name="iterations">The number of test iterations.</param>
        /// <param name="warmupIterations">The number of warmup iterations.</param>
        /// <param name="ignoreException">The function that is used to evaluate if an exception should be ignored.</param>
        /// <remarks>
        /// If <paramref name="warmupIterations"/> is set to 0,
        /// a warmup iteration will still run to check if any exception is thrown.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// <paramref name="name"/> is <c>null</c>, empty or consists only of white-space characters.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxMilliseconds"/> is equal to 0.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="iterations"/> is equal to 0.
        /// </exception>
        internal PerformanceTest(
            [NotNull]string name,
            [NotNull]Action action,
            uint maxMilliseconds,
            uint iterations,
            uint warmupIterations,
            [CanBeNull]Func<Exception, bool> ignoreException)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Cannot be null, empty or consists only of white-space characters.", nameof(name));
            Action = action ?? throw new ArgumentNullException(nameof(action));
            MaxMilliseconds = maxMilliseconds > 0 ? maxMilliseconds : throw new ArgumentOutOfRangeException(nameof(maxMilliseconds), maxMilliseconds, "Must be larger than 0.");
            IgnoreException = ignoreException;
            Iterations = iterations > 0 ? iterations : throw new ArgumentOutOfRangeException(nameof(iterations), iterations, "Must be larger than 0.");
            WarmupIterations = warmupIterations == 0 ? 1 : warmupIterations;
            _canBeSkipped = true;
            _skip = false;
            ActualMilliseconds = 0;
            Passed = false;
        }

        /// <summary>
        /// Gets the name of the test.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this test can be skipped.
        /// </summary>
        internal bool CanBeSkipped
        {
            get => _canBeSkipped;
            set
            {
                _canBeSkipped = value;
                if (!_canBeSkipped)
                    _skip = false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this test should be skipped.
        /// </summary>
        internal bool Skip
        {
            get => _skip;
            set
            {
                _skip = value;
                if (_skip)
                    _canBeSkipped = true;
            }
        }

        /// <summary>
        /// Gets the number of test iterations.
        /// </summary>
        internal uint Iterations { get; }

        /// <summary>
        /// Gets the number of warmup iterations.
        /// </summary>
        internal uint WarmupIterations { get; }

        /// <summary>
        /// Gets the maximum milliseconds.
        /// </summary>
        internal uint MaxMilliseconds { get; }

        /// <summary>
        /// Gets the actual milliseconds.
        /// </summary>
        internal long ActualMilliseconds { get; private set; }

        /// <summary>
        /// Gets a value indicating whether test passed.
        /// </summary>
        /// <remarks>
        /// Will be set after a <see cref="Run"/> is invoked.
        /// </remarks>
        internal bool Passed { get; private set; }

        private Action Action { get; }

        private Func<Exception, bool> IgnoreException { get; }

        /// <summary>
        /// Runs the test.
        /// </summary>
        internal void Run()
        {
            if (Skip)
                return;
            var stopwatch = new Stopwatch();
            for (var warmup = 0; warmup < WarmupIterations; warmup++)
            {
                try
                {
                    Action();
                }
                catch (Exception exception) when (IgnoreException?.Invoke(exception) ?? false)
                {
                }
                catch (ResultStateException)
                {
                    Console.WriteLine($"{Name} failed.");
                    throw;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{Name} threw an exception.");
                    throw;
                }
            }

            stopwatch.Start();
            for (var iteration = 0; iteration < Iterations; iteration++)
            {
                try
                {
                    Action();
                }
                catch when (IgnoreException != null)
                {
                }
            }

            stopwatch.Stop();
            ActualMilliseconds = stopwatch.ElapsedMilliseconds;
            Passed = ActualMilliseconds <= MaxMilliseconds;
        }
    }
}