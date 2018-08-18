namespace MGU.Core.Internal.Conditions.Enumerable
{
    using System.Globalization;
    using Base;
    using Core.Interfaces.Conditions.Enumerable;
    using Core.Interfaces.Conditions.Enumerable.Not;

    /// <inheritdoc cref="EnumerableConditionBase{TSource,TObject,TEnumerableNotConditionBase}" />
    /// <inheritdoc cref="IStringCondition"/>
    /// <summary>
    /// The <see cref="StringCondition"/> class.
    /// </summary>
    internal sealed class StringCondition
        : EnumerableConditionBase<string, char, IStringNotCondition>,
          IStringCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringCondition"/> class.
        /// </summary>
        /// <param name="source">The source string.</param>
        internal StringCondition(string source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool NullOrWhitespace => Result(string.IsNullOrWhiteSpace(Source));

        /// <inheritdoc />
        protected override IStringNotCondition NotCondition => this;

        /// <inheritdoc />
        public bool In(string other, bool ignoreCase = false, CultureInfo culture = null)
        {
            if (Source is null || other is null)
                return Result(false);
            var source = Source;
            if (ignoreCase)
            {
                source = culture is null ? source.ToLower() : source.ToLower(culture);
                other = culture is null ? other.ToLower() : other.ToLower(culture);
            }

            return Result(other.Contains(source));
        }
    }
}