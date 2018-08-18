namespace MGU.Core.Extensions.If
{
    using Interfaces.ChainableConditions.Nullable;
    using Internal.ChainableConditions.Nullable;

    /// <summary>
    /// Contains If extension methods for nullable <see langword="struct"/>.
    /// </summary>
    public static class IfNullableStructExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for <see cref="bool"/>.
        /// </summary>
        /// <param name="source">The source <see cref="bool"/>.</param>
        /// <returns><see cref="IChainableNullableBoolCondition"/></returns>
        public static IChainableNullableBoolCondition If(this bool? source)
            => new ChainableNullableBoolCondition(source);
    }
}