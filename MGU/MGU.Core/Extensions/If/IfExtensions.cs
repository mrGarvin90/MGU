namespace MGU.Core.Extensions.If
{
    using Interfaces.ChainableConditions.Base;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.Couplers;
    using Interfaces.Options;
    using Internal.ChainableConditions.Nullable;
    using Internal.Couplers;
    using Internal.Helpers;
    using Internal.Options;

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
            => new ChainableCondition<TSource>(source);

        /// <summary>
        /// Determines whether this instance is of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns><see cref="ITypeConditionResultOption{T}"/></returns>
        /// <remarks>
        /// If <paramref name="source"/> is <c>null</c> the condition will evaluate to <c>false</c>
        /// and the default value of <typeparamref name="T"/> will be used.
        /// </remarks>
        public static ITypeConditionResultOption<T> If<T>(this object source)
            => new TypeConditionResultOption<object, T>(source, source is T);

        /// <summary>
        /// Determines whether this instance is not of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="chainableCondition">The source condition.</param>
        /// <returns><see cref="INotTypeConditionResultOption{TSource}"/></returns>
        /// <remarks>
        /// If the source object is <c>null</c> the condition will evaluate to <c>true</c>.
        /// </remarks>
        public static INotTypeConditionResultOption<object> Not<T>(this IChainableConditionBase chainableCondition)
        {
            var sourceObject = (ISourceObject)chainableCondition;
            return new NotTypeConditionResultOption<object>(
                sourceObject.Value,
                ((IConditionEvaluator)chainableCondition).Evaluate(!(sourceObject.Value is T)));
        }
    }
}