namespace MGU.Core.Extensions.If
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
    /// Contains If extension methods to block accidental use of If on conditions, chainable conditions, couplers and options.
    /// </summary>
    public static class BlockIfExtensions
    {
        #region Conditions

        #region ICondition

        /// <summary>
        /// Blocks the use of If on <see cref="ICondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this ICondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="INotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this INotCondition<TSource> source)
        {
        }

        #endregion

        #region IComparableStructCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region INullableComparableStructCondition

        /// <summary>
        /// Blocks the use of If on <see cref="INullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this INullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="INullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this INullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IComparableClassCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IEnumerableCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TObject>(this IEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TObject>(this IEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IStringCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IStringNotCondition source)
        {
        }

        #endregion

        #region ICharCondition

        /// <summary>
        /// Blocks the use of If on <see cref="ICharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this ICharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this ICharNotCondition source)
        {
        }

        #endregion

        #region ICharNullableCondition

        /// <summary>
        /// Blocks the use of If on <see cref="INullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="ICharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableCharNotCondition source)
        {
        }

        #endregion

        #region IBoolCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IBoolNotCondition source)
        {
        }

        #endregion

        #region INullableBoolCondition

        /// <summary>
        /// Blocks the use of If on <see cref="INullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="INullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableBoolNotCondition source)
        {
        }

        #endregion

        #region IGuidCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IGuidCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IGuidCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IGuidNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IGuidNotCondition source)
        {
        }

        #endregion

        #region IGuidNullableCondition

        /// <summary>
        /// Blocks the use of If on <see cref="INullableGuidCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableGuidCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IGuidNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this INullableGuidNotCondition source)
        {
        }

        #endregion

        #endregion

        #region Chainable Conditions

        #region IChainableCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableNotCondition<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableDoesNotCondition<TSource> source)
        {
        }

        #endregion

        #region IChainableComparableStructCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableNullableComparableStructCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableComparableStructCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableNullableComparableStructCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableComparableStructNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableNullableComparableStructNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableComparableStructDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableNullableComparableStructDoesNotCondition<TSource> source)
            where TSource : struct, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableComparableClassCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableClassCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableClassCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableClassNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableClassNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableComparableClassDoesNotCondition{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the comparable.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IChainableComparableClassDoesNotCondition<TSource> source)
            where TSource : class, IComparable<TSource>
        {
        }

        #endregion

        #region IChainableEnumerableCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableEnumerableCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TObject>(this IChainableEnumerableCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableEnumerableNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TObject>(this IChainableEnumerableNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableEnumerableDoesNotCondition{TSource,TObject}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TObject>(this IChainableEnumerableDoesNotCondition<TSource, TObject> source)
            where TSource : IEnumerable<TObject>
        {
        }

        #endregion

        #region IChainableStringCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableStringCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableStringCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableStringNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableStringNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableStringDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableStringDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableCharCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableCharCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableCharCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableCharCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableCharNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableCharNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableCharDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableCharDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableBoolCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableBoolDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableBoolCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableBoolCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableBoolCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableBoolNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableBoolNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableBoolDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableBoolDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableGuidCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableGuidCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableGuidCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableGuidNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableGuidNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableGuidDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableGuidDoesNotCondition source)
        {
        }

        #endregion

        #region IChainableNullableGuidCondition

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableGuidCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableGuidCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableGuidNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableGuidNotCondition source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IChainableNullableGuidDoesNotCondition"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this IChainableNullableGuidDoesNotCondition source)
        {
        }

        #endregion

        #endregion

        #region Couplers

        /// <summary>
        /// Blocks the use of If on <see cref="IConditionCoupler{TSource,TChainableCondition}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource, TChainableCondition>(this IConditionCoupler<TSource, TChainableCondition> source)
            where TChainableCondition : IChainableConditionBase<TSource>
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="INotTypeConditionResultOptionCoupler{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this INotTypeConditionResultOptionCoupler<TSource> source)
        {
        }

        #endregion

        #region Options

        /// <summary>
        /// Blocks the use of If on <see cref="IConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IConditionResultOption<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="ICastOption"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void If(this ICastOption source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="IThrowOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this IThrowOption<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="ITypeConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this ITypeConditionResultOption<TSource> source)
        {
        }

        /// <summary>
        /// Blocks the use of If on <see cref="INotTypeConditionResultOption{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static void If<TSource>(this INotTypeConditionResultOption<TSource> source)
        {
        }

        #endregion
    }
}