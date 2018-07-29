﻿namespace MGU.Core.Extensions.If
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.ChainableConditions.Base;
    using Interfaces.ChainableConditions.Enumerable.Count;
    using Interfaces.Couplers;
    using Internal.Couplers;
    using JetBrains.Annotations;

    /// <summary>
    /// Contains extension methods for <see cref="IChainableEnumerableCountIsCondition{TSource,TObject,TChainableEnumerableCondition}"/>.
    /// </summary>
    public static class ChainableEnumerableCountIsConditionExtensions
    {
        /// <summary>
        /// Determines whether the number of elements in the source enumerable is not equal to the specified value.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <typeparam name="TChainableEnumerableCondition">The type of the chainable enumerable condition.</typeparam>
        /// <param name="source">The source condition.</param>
        /// <param name="value">The value.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// The source enumerable is <see langword="null"/>.
        /// </exception>
        public static IConditionCoupler<TSource, TChainableEnumerableCondition> Not<TSource, TObject, TChainableEnumerableCondition>(
            [NotNull]this IChainableEnumerableCountIsCondition<TSource, TObject, TChainableEnumerableCondition> source,
            int value)
            where TSource : IEnumerable<TObject>
            where TChainableEnumerableCondition : IChainableEnumerableConditionBase<TSource, TObject>
        {
            return ((ConditionCoupler<TSource, TChainableEnumerableCondition>)source).Evaluate(s => s.Count() == value, true);
        }
    }
}