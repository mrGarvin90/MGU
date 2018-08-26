namespace MGU.Core.Interfaces.ChainableConditions.Base
{
    using System;
    using Couplers;
    using DoesNot;
    using JetBrains.Annotations;
    using Not;
    using Options;

    /// <summary>
    /// The <see cref="IChainableConditionBase"/> interface.
    /// </summary>
    public interface IChainableConditionBase
    {
    }

    /// <summary>
    /// The <see cref="IChainableConditionBase{TSource}"/> interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    public interface IChainableConditionBase<TSource>
    {
    }

    /// <inheritdoc cref="IChainableConditionBase" />
    /// <inheritdoc cref="IChainableNotConditionBase{TSource,TChainableCondition}"/>
    /// <summary>
    /// The base interface that defines chainable conditions for all objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TChainableCondition">The type of the chainable condition.</typeparam>
    /// <typeparam name="TChainableNotCondition">The type of the chainable not condition.</typeparam>
    /// <typeparam name="TChainableDoesNotCondition">The type of the chainable does not condition.</typeparam>
    public interface IChainableConditionBase<TSource, out TChainableCondition, out TChainableNotCondition, out TChainableDoesNotCondition>
        : IChainableConditionBase,
          IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableCondition : IChainableConditionBase<TSource, TChainableCondition, TChainableNotCondition, TChainableDoesNotCondition>
        where TChainableNotCondition : IChainableNotConditionBase<TSource, TChainableCondition>
        where TChainableDoesNotCondition : IChainableDoesNotConditionBase<TSource, TChainableCondition>
    {
        /// <summary>
        /// Gets the not conditions where the result of the conditions will be inverted.
        /// </summary>
        TChainableNotCondition Not { get; }

        /// <summary>
        /// Gets the does not condition.
        /// </summary>
        TChainableDoesNotCondition DoesNot { get; }

        /// <summary>
        /// Determines whether the source object fulfills the specified condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// <paramref name="condition"/> is <c>null</c>.
        /// Inner exception: <see cref="NullReferenceException"/>.
        /// </exception>
        /// <exception cref="Exceptions.ConditionEvaluationFailedException">
        /// <paramref name="condition"/> could not be evaluated.
        /// Inner exception: Cannot specify.
        /// </exception>
        IConditionCoupler<TSource, TChainableCondition> Fulfills([NotNull]Func<TSource, bool> condition);

        /// <summary>
        /// Determines whether the source object is the specified type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns><see cref="IConditionCoupler{TSource,TChainableCondition}"/></returns>
        /// <remarks>
        /// If the source object is <c>null</c> the specific type of the source object and <typeparamref name="T"/>
        /// will be compared, otherwise the <c>is</c> operator will be used.
        /// </remarks>
        new ITypeConditionResultOption<T> Type<T>();
    }
}