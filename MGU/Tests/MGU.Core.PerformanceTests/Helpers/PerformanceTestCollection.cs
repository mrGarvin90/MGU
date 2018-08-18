namespace MGU.Core.PerformanceTests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;
    using NUnit.Framework;

    /// <summary>
    /// The <see cref="PerformanceTestCollection"/> class.
    /// </summary>
    public class PerformanceTestCollection
    {
        private readonly bool _skipAllTests;
        private readonly List<PerformanceTest> _tests;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceTestCollection"/> class.
        /// </summary>
        /// <param name="skipAllTests">If set to <c>true</c> all tests will be skipped.</param>
        public PerformanceTestCollection(bool skipAllTests)
        {
            _skipAllTests = skipAllTests;
            _tests = new List<PerformanceTest>();
        }

        /// <summary>
        /// Adds a test to the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="action">The action to test.</param>
        /// <param name="maxMilliseconds">The maximum milliseconds.</param>
        /// <param name="ignoreException">The function that is used to evaluate if an exception should be ignored.</param>
        /// <param name="iterations">The number of test iterations.</param>
        /// <param name="warmupIterations">The number of warmup iterations.</param>
        /// <returns>This instance.</returns>
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
        /// <exception cref="ArgumentException">
        /// The <paramref name="name"/> is not unique.
        /// </exception>
        public PerformanceTestCollection Add(
            [NotNull]string name,
            [NotNull]Action action,
            uint maxMilliseconds,
            Func<Exception, bool> ignoreException = null,
            uint iterations = 100_000,
            uint warmupIterations = 5_000)
        {
            if (_tests.Any(t => t.Name == name))
                throw new ArgumentException($"There is already a test in the collection with the name '{name}'.");
            _tests.Add(new PerformanceTest(
                name,
                action,
                maxMilliseconds,
                iterations,
                warmupIterations,
                ignoreException));
            return this;
        }

        /// <summary>
        /// Adds a test to the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="function">The function to test.</param>
        /// <param name="maxMilliseconds">The maximum milliseconds.</param>
        /// <param name="ignoreException">The function that is used to evaluate if an exception should be ignored.</param>
        /// <param name="iterations">The number of test iterations.</param>
        /// <param name="warmupIterations">The number of warmup iterations.</param>
        /// <returns>This instance.</returns>
        /// <remarks>
        /// If <paramref name="warmupIterations"/> is set to 0,
        /// a warmup iteration will still run to check if any exception is thrown.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// <paramref name="name"/> is <c>null</c>, empty or consists only of white-space characters.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="function"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxMilliseconds"/> is equal to 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="name"/> is not unique.
        /// </exception>
        public PerformanceTestCollection Add(
            [NotNull]string name,
            [NotNull]Func<object> function,
            uint maxMilliseconds,
            Func<Exception, bool> ignoreException = null,
            uint iterations = 100_000,
            uint warmupIterations = 5_000)
        {
            if (_tests.Any(t => t.Name == name))
                throw new ArgumentException($"There is already a test in the collection with the name '{name}'.");
            _tests.Add(new PerformanceTest(
                name,
                function,
                maxMilliseconds,
                iterations,
                warmupIterations,
                ignoreException));
            return this;
        }

        /// <summary>
        /// Sets that the last added test should be skipped.
        /// </summary>
        /// <returns>This instance.</returns>
        public PerformanceTestCollection Skip()
        {
            if (_tests.Any())
            {
                _tests.Last().CanBeSkipped = true;
                _tests.Last().Skip = true;
            }

            return this;
        }

        /// <summary>
        /// Sets that all tests currently in the collection,
        /// that can be skipped, should be skipped.
        /// </summary>
        /// <returns>This instance.</returns>
        public PerformanceTestCollection SkipPreceding()
        {
            if (_tests.Any())
            {
                foreach (var test in _tests)
                    test.Skip = test.CanBeSkipped;
            }

            return this;
        }

        /// <summary>
        /// Sets that the last added test should not be skipped
        /// when <see cref="SkipPreceding"/> is called.
        /// </summary>
        /// <returns>This instance.</returns>
        public PerformanceTestCollection DoNotSkip()
        {
            if (_tests.Any())
            {
                _tests.Last().CanBeSkipped = false;
                _tests.Last().Skip = false;
            }

            return this;
        }

        /// <summary>
        /// Runs all tests that is not set to be skipped.
        /// </summary>
        public void RunAll()
        {
            if (!_tests.Any())
                AssertInconclusive("The test collection is empty.");
            var skippedTests = _tests.Count(t => t.Skip);
            if (_skipAllTests || skippedTests == _tests.Count)
                AssertInconclusive("All tests is set to be skipped.");
            var outputHelper = new PerformanceTestOutputHelper();

            var result = true;
            var failedTests = 0;
            foreach (var test in _tests)
            {
                if (test.Skip)
                {
                    outputHelper.Append(test);
                    continue;
                }

                test.Run();
                if (!test.Passed)
                {
                    failedTests++;
                    result = false;
                }

                outputHelper.Append(test);
            }

            outputHelper.WriteToOutput(_tests.Count, skippedTests, failedTests);
            Assert.True(result, "One or more tests failed.");
            if (skippedTests > 0)
                AssertInconclusive("One or more tests was skipped.");
        }

        private void AssertInconclusive(string message)
        {
            Console.WriteLine(message);
            Assert.Inconclusive(message);
        }
    }
}