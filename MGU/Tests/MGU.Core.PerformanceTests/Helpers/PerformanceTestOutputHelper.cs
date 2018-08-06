namespace MGU.Core.PerformanceTests.Helpers
{
    using System;
    using System.Text;

    /// <summary>
    /// The <see cref="PerformanceTestOutputHelper"/> class.
    /// </summary>
    internal sealed class PerformanceTestOutputHelper
    {
        private readonly StringBuilder _outputBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceTestOutputHelper"/> class.
        /// </summary>
        internal PerformanceTestOutputHelper()
        {
            _outputBuilder = new StringBuilder();
        }

        /// <summary>
        /// Appends information about the specified test to the output.
        /// </summary>
        /// <param name="test">The test.</param>
        internal void Append(PerformanceTest test)
        {
            var outcome = test.Skip ? "[SKIPPED]" : test.Passed ? "[PASSED]" : "[FAILED]";
            _outputBuilder.Append(test.Name).Append(": ").AppendLine(outcome)
                          .AppendLine(new string('-', test.Name.Length + 2 + outcome.Length));
            if (!test.Skip)
            {
                _outputBuilder.Append("Iterations - Warmup: ").AppendLine(test.WarmupIterations.ToString("N0"))
                              .Append("           - Test:   ").AppendLine(test.Iterations.ToString("N0"))
                              .Append("      Time - Max:    ").Append(test.MaxMilliseconds).AppendLine(" ms")
                              .Append("           - Actual: ").Append(test.ActualMilliseconds).AppendLine(" ms");
            }

            _outputBuilder.AppendLine(new string('-', test.Name.Length + 2 + outcome.Length))
                          .AppendLine();
        }

        /// <summary>
        /// Writes to output.
        /// </summary>
        /// <param name="testsTotal">The tests total.</param>
        /// <param name="skippedTests">The skipped tests.</param>
        /// <param name="failedTests">The failed tests.</param>
        internal void WriteToOutput(int testsTotal, int skippedTests, int failedTests)
        {
            if (skippedTests > 0)
            {
                Console.WriteLine("One or more tests was skipped.");
                Console.WriteLine();
            }

            Console.WriteLine($"Total:   {testsTotal}");
            Console.WriteLine($"Skipped: {skippedTests}");
            Console.WriteLine($"Passed:  {testsTotal - skippedTests - failedTests}");
            Console.WriteLine($"Failed:  {failedTests}");
            Console.WriteLine();
            Console.WriteLine(_outputBuilder);
        }
    }
}