namespace MGU.Core.Extensions.If
{
    using Interfaces.ChainableConditions.Struct;
    using Internal.ChainableConditions.Struct;

    /// <summary>
    /// Contains If extension methods for <see langword="struct"/>.
    /// </summary>
    public static class IfStructExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for <see cref="bool"/>.
        /// </summary>
        /// <param name="source">The source <see cref="bool"/>.</param>
        /// <returns><see cref="IChainableBoolCondition"/></returns>
        public static IChainableBoolCondition If(this bool source)
        {
            return new ChainableBoolCondition(source);
        }
    }
}