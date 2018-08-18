namespace MGU.Core.Extensions.Is
{
    using Interfaces.Conditions.Nullable;
    using Internal.Conditions.Nullable;

    /// <summary>
    /// Contains Is extension methods for nullable <see langword="struct"/>.
    /// </summary>
    public static class IsNullableStructExtensions
    {
        /// <summary>
        /// Gets conditions for nullable <see cref="bool"/>.
        /// </summary>
        /// <param name="source">The nullable source <see cref="bool"/>.</param>
        /// <returns><see cref="INullableBoolCondition"/></returns>
        public static INullableBoolCondition Is(this bool? source)
            => new NullableBoolCondition(source);
    }
}