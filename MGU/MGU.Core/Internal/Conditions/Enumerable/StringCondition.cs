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
        public bool In(string other)
        {
            return In(other, false);
        }

        /// <inheritdoc />
        public bool In(string other, bool ignoreCase, CultureInfo culture = null)
        {
            if (!ignoreCase)
                return Result(IsIn(other, Source));

            string source;
            if (culture is null)
            {
                source = Source?.ToLower();
                other = other?.ToLower();
            }
            else
            {
                source = Source?.ToLower(culture);
                other = other?.ToLower(culture);
            }

            return Result(IsIn(other, source));
        }

        private static bool IsIn(string other, string source)
        {
            return source != null && (other?.Contains(source) ?? false);
        }
    }
}