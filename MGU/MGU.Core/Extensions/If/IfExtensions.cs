namespace MGU.Core.Extensions.If
{
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.Couplers;
    using Internal.ChainableConditions.Nullable;
    using Internal.Couplers;

    /// <summary>
    /// Contains If extension methods for all objects.
    /// </summary>
    public static class IfExtensions
    {
        /// <summary>
        /// Gets conditions that can be chained for any object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns><see cref="IChainableCondition{TSource}"/></returns>
        public static IChainableCondition<TSource> If<TSource>(this TSource source)
        {
            return new ChainableCondition<TSource>(source);
        }

        /// <summary>
        /// Determines whether this instance is of type <typeparamref name="T"/> and
        /// gets conditions that can be chained for <typeparamref name="T"/>.
        /// If this instance is of type <typeparamref name="T"/> it will be cast to <typeparamref name="T"/>,
        /// if not the default value of <typeparamref name="T"/> will be used in proceeding conditions.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        public static IConditionCoupler<T, IChainableCondition<T>> If<T>(this object source)
        {
            var isType = source is T;
            return ((ConditionCoupler<T, IChainableCondition<T>>)(isType ? (T)source : default).If())
                .Evaluate(s => isType, "If<T>");
        }
    }
}