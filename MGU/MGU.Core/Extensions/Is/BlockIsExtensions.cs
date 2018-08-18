namespace MGU.Core.Extensions.Is
{
    using System;
    using System.Collections.Generic;
    using Interfaces.ChainableConditions.Base;
    using Interfaces.ChainableConditions.Enumerable;
    using Interfaces.ChainableConditions.Enumerable.DoesNot;
    using Interfaces.ChainableConditions.Enumerable.Not;
    using Interfaces.ChainableConditions.Nullable;
    using Interfaces.ChainableConditions.Nullable.DoesNot;
    using Interfaces.ChainableConditions.Nullable.Not;
    using Interfaces.ChainableConditions.Struct;
    using Interfaces.ChainableConditions.Struct.DoesNot;
    using Interfaces.ChainableConditions.Struct.Not;
    using Interfaces.Conditions.Enumerable;
    using Interfaces.Conditions.Enumerable.Not;
    using Interfaces.Conditions.Nullable;
    using Interfaces.Conditions.Nullable.Not;
    using Interfaces.Conditions.Struct;
    using Interfaces.Conditions.Struct.Not;
    using Interfaces.Couplers;
    using Interfaces.Options;

    /// <summary>
    /// Contains Is extension methods to block accidental use of Is on conditions, chainable conditions, condition couplers, condition actions and options.
    /// </summary>
    public static class BlockIsExtensions
    {
        #region Conditions

        #region ICondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="ICondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this ICondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this INotCondition<TSource> source)
        {
        }

        #endregion

        #region IComparableStructCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region INullableComparableStructCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this INullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this INullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IComparableClassCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IEnumerableCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TObject>(this IEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TObject>(this IEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IStringCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IStringNotCondition source)
        {
        }

        #endregion

        #region ICharCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="ICharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this ICharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this ICharNotCondition source)
        {
        }

        #endregion

        #region ICharNullableCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this INullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this INullableCharNotCondition source)
        {
        }

        #endregion

        #region IBoolCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IBoolNotCondition source)
        {
        }

        #endregion

        #region INullableBoolCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this INullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="INullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this INullableBoolNotCondition source)
        {
        }

        #endregion

        #endregion

        #region Chainable Conditions

        #region IChainableCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableNotCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableDoesNotCondition<TSource> source)
        {
        }

        #endregion

        #region IChainableComparableStructCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableNullableComparableStructCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableNullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableNullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableNullableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableComparableClassCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableComparableClassDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IChainableComparableClassDoesNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableEnumerableCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TObject>(this IChainableEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TObject>(this IChainableEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableEnumerableDoesNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TObject>(this IChainableEnumerableDoesNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IChainableStringCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableStringNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableStringDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableStringDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableCharCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableCharCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableBoolCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableBoolDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableBoolCondition

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IChainableNullableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this IChainableNullableBoolDoesNotCondition source)
        {
        }

        #endregion

        #endregion

        #region IConditionCoupler

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IConditionCoupler{TSource,TChainableCondition}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource, TChainableCondition>(this IConditionCoupler<TSource, TChainableCondition> source)
            where TChainableCondition : IChainableConditionBase
        {
        }

        #endregion

        #region Options

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IConditionResultOption<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="ICastOption"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Is(this ICastOption source)
        {
        }

        /// <summary>
        /// Blocks the use of Is on <inheritdoc cref="IThrowOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Is<TSource>(this IThrowOption<TSource> source)
        {
        }

        #endregion
    }
}