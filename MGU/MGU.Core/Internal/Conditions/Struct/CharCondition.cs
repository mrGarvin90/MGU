namespace MGU.Core.Internal.Conditions.Struct
{
    using System.Globalization;
    using Base;
    using Core.Interfaces.Conditions.Struct;
    using Core.Interfaces.Conditions.Struct.Not;

    /// <inheritdoc cref="ConditionBase{TSource,TNotCondition}"/>
    /// <inheritdoc cref="ICharCondition"/>
    /// <summary>
    /// The <see cref="CharCondition"/> class.
    /// </summary>
    internal class CharCondition
        : ComparableConditionBase<char, ICharNotCondition>,
          ICharCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharCondition"/> class.
        /// </summary>
        /// <param name="source">The source char.</param>
        internal CharCondition(char source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public bool Control => Result(char.IsControl(Source));

        /// <inheritdoc />
        public bool Digit => Result(char.IsDigit(Source));

        /// <inheritdoc />
        public bool HighSurrogate => Result(char.IsHighSurrogate(Source));

        /// <inheritdoc />
        public bool Letter => Result(char.IsLetter(Source));

        /// <inheritdoc />
        public bool LetterOrDigit => Result(char.IsLetterOrDigit(Source));

        /// <inheritdoc />
        public bool Lower => Result(char.IsLower(Source));

        /// <inheritdoc />
        public bool LowSurrogate => Result(char.IsLowSurrogate(Source));

        /// <inheritdoc />
        public bool Number => Result(char.IsNumber(Source));

        /// <inheritdoc />
        public bool Punctuation => Result(char.IsPunctuation(Source));

        /// <inheritdoc />
        public bool Separator => Result(char.IsSeparator(Source));

        /// <inheritdoc />
        public bool Surrogate => Result(char.IsSurrogate(Source));

        /// <inheritdoc />
        public bool Symbol => Result(char.IsSymbol(Source));

        /// <inheritdoc />
        public bool Upper => Result(char.IsUpper(Source));

        /// <inheritdoc />
        public bool WhiteSpace => Result(char.IsWhiteSpace(Source));

        /// <inheritdoc />
        protected override ICharNotCondition NotCondition => this;

        /// <inheritdoc />
        public bool In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            if (str is null)
                return Result(false);
            var source = Source.ToString();
            if (ignoreCase)
            {
                source = culture is null ? source.ToLower() : source.ToLower(culture);
                str = culture is null ? str.ToLower() : str.ToLower(culture);
            }

            return Result(str.Contains(source));
        }
    }
}