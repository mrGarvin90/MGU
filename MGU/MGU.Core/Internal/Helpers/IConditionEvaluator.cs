namespace MGU.Core.Internal.Helpers
{
    /// <summary>
    /// The <see cref="IConditionEvaluator"/> interface.
    /// </summary>
    internal interface IConditionEvaluator
    {
        /// <summary>
        /// Evaluates the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns><c>true</c> or <c>false</c>.</returns>
        bool Evaluate(bool condition);
    }
}