namespace MGU.Core.Interfaces.Conditions.Base
{
    using JetBrains.Annotations;
    using Not;

    /// <inheritdoc cref="IComparableNotConditionBase{TSource}" />
    /// <inheritdoc cref="IConditionBase{TSource,TNotCondition}" />
    /// <summary>
    /// The base interface that defines conditions for comparable objects.
    /// </summary>
    /// <typeparam name="TSource">The type of the comparable source.</typeparam>
    /// <typeparam name="TComparableNotCondition">The type of the comparable not condition.</typeparam>
    public interface IComparableConditionBase<TSource, out TComparableNotCondition>
        : IComparableNotConditionBase<TSource>,
          IConditionBase<TSource, TComparableNotCondition>
        where TComparableNotCondition : IComparableNotConditionBase<TSource>
    {
        /// <summary>
        /// Determines whether the source comparable is less than the specified other.
        /// </summary>
        /// <param name="other">The other comparable.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is less than the comparable other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool LessThan([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is less than or equal to the specified other.
        /// </summary>
        /// <param name="other">The other comparable.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is less than or equal to the comparable other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool LessThanEqualTo([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is greater than the specified other.
        /// </summary>
        /// <param name="other">The other comparable.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is greater than the comparable other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool GreaterThan([CanBeNull]TSource other);

        /// <summary>
        /// Determines whether the source comparable is greater than or equal to the specified other.
        /// </summary>
        /// <param name="other">The other comparable.</param>
        /// <returns>
        /// <c>true</c> if the source comparable is greater than or equal to the comparable other;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool GreaterThanEqualTo([CanBeNull]TSource other);
    }
}