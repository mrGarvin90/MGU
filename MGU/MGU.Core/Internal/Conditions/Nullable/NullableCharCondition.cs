namespace MGU.Core.Internal.Conditions.Nullable
{
    using System;
    using System.Globalization;
    using Base;
    using Interfaces.Conditions.Nullable;
    using Interfaces.Conditions.Nullable.Not;

    /// <inheritdoc cref="NullableComparableStructConditionBase{TSource,TComparableNotCondition}" />
    /// <inheritdoc cref="INullableCharCondition" />
    /// <summary>
    /// The <see cref="NullableCharCondition" /> class.
    /// </summary>
    internal sealed class NullableCharCondition
        : NullableComparableStructConditionBase<char, INullableCharNotCondition>,
          INullableCharCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableCharCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source <see cref="char"/>.</param>
        internal NullableCharCondition(char? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool Control => Evaluate(char.IsControl);

        /// <inheritdoc />
        public bool Digit => Evaluate(char.IsDigit);

        /// <inheritdoc />
        public bool HighSurrogate => Evaluate(char.IsHighSurrogate);

        /// <inheritdoc />
        public bool Letter => Evaluate(char.IsLetter);

        /// <inheritdoc />
        public bool LetterOrDigit => Evaluate(char.IsLetterOrDigit);

        /// <inheritdoc />
        public bool Lower => Evaluate(char.IsLower);

        /// <inheritdoc />
        public bool LowSurrogate => Evaluate(char.IsLowSurrogate);

        /// <inheritdoc />
        public bool Number => Evaluate(char.IsNumber);

        /// <inheritdoc />
        public bool Punctuation => Evaluate(char.IsPunctuation);

        /// <inheritdoc />
        public bool Separator => Evaluate(char.IsSeparator);

        /// <inheritdoc />
        public bool Surrogate => Evaluate(char.IsSurrogate);

        /// <inheritdoc />
        public bool Symbol => Evaluate(char.IsSymbol);

        /// <inheritdoc />
        public bool Upper => Evaluate(char.IsUpper);

        /// <inheritdoc />
        public bool WhiteSpace => Evaluate(char.IsWhiteSpace);

        /// <inheritdoc />
        protected override INullableCharNotCondition NotCondition => this;

        /// <inheritdoc />
        public bool In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            if (!Source.HasValue || str is null)
                return Result(false);
            var source = Source.ToString();
            if (ignoreCase)
            {
                source = culture is null ? source.ToLower() : source.ToLower(culture);
                str = culture is null ? str.ToLower() : str.ToLower(culture);
            }

            return Result(str.Contains(source));
        }

        private bool Evaluate(Func<char, bool> condition)
            => Result(Source.HasValue && condition(Source.Value));
    }
}