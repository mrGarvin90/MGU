namespace MGU.Core.Extensions.Cast
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
    /// Contains Cast extension methods to block accidental use of Cast on conditions, chainable conditions, condition couplers, condition actions and options.
    /// </summary>
    public static class BlockCastExtensions
    {
        #region Conditions

        #region ICondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="ICondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this ICondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this INotCondition<TSource> source)
        {
        }

        #endregion

        #region IComparableStructCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region INullableComparableStructCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this INullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this INullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IComparableClassCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IEnumerableCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TObject>(this IEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TObject>(this IEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IStringCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IStringNotCondition source)
        {
        }

        #endregion

        #region ICharCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="ICharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this ICharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this ICharNotCondition source)
        {
        }

        #endregion

        #region ICharNullableCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this INullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this INullableCharNotCondition source)
        {
        }

        #endregion

        #region IBoolCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IBoolNotCondition source)
        {
        }

        #endregion

        #region INullableBoolCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this INullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="INullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this INullableBoolNotCondition source)
        {
        }

        #endregion

        #endregion

        #region Chainable Conditions

        #region IChainableCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableNotCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableDoesNotCondition<TSource> source)
        {
        }

        #endregion

        #region IChainableComparableStructCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableNullableComparableStructCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableNullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableNullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableNullableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableComparableClassCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableComparableClassDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IChainableComparableClassDoesNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableEnumerableCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TObject>(this IChainableEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TObject>(this IChainableEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableEnumerableDoesNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TObject>(this IChainableEnumerableDoesNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IChainableStringCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableStringNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableStringDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableStringDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableCharCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableCharCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableBoolCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableBoolDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableBoolCondition

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IChainableNullableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this IChainableNullableBoolDoesNotCondition source)
        {
        }

        #endregion

        #endregion

        #region IConditionCoupler

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IConditionCoupler{TSource,TChainableCondition}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource, TChainableCondition>(this IConditionCoupler<TSource, TChainableCondition> source)
            where TChainableCondition : IChainableConditionBase
        {
        }

        #endregion

        #region Options

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IConditionResultOption<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="ICastOption"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Cast(this ICastOption source)
        {
        }

        /// <summary>
        /// Blocks the use of Cast on <inheritdoc cref="IThrowOption{TSource}"/>.
        /// </summary>
        /// /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void Cast<TSource>(this IThrowOption<TSource> source)
        {
        }

        #endregion
    }
}