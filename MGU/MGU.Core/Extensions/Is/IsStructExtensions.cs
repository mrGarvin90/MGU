namespace MGU.Core.Extensions.Is
{
    using Interfaces.Conditions.Struct;
    using Internal.Conditions.Struct;

    /// <summary>
    /// Contains Is extension methods for <see langword="struct"/>.
    /// </summary>
    public static class IsStructExtensions
    {
        /// <summary>
        /// Gets conditions for <see cref="bool"/>.
        /// </summary>
        /// <param name="source">The source bool.</param>
        /// <returns><see cref="IBoolCondition"/></returns>
        public static IBoolCondition Is(this bool source)
        {
            return new BoolCondition(source);
        }
    }
}