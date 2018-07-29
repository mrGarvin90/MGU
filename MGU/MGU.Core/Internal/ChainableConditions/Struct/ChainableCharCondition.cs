namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using System.Globalization;
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.DoNot;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Core.Interfaces.Couplers;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoNotCondition}" />
    /// <inheritdoc cref="IChainableCharCondition" />
    /// <inheritdoc cref="IChainableCharDoNotCondition" />
    /// <summary>
    /// The <see cref="ChainableCharCondition" /> class.
    /// </summary>
    internal sealed class ChainableCharCondition
        : ChainableComparableConditionBase<char, IChainableCharCondition, IChainableCharNotCondition, IChainableCharDoNotCondition>,
          IChainableCharCondition,
          IChainableCharDoNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableCharCondition"/> class.
        /// </summary>
        /// <param name="source">The source char.</param>
        internal ChainableCharCondition(char source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Control => Evaluate(char.IsControl);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Digit => Evaluate(char.IsDigit);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> HighSurrogate => Evaluate(char.IsHighSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Letter => Evaluate(char.IsLetter);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Lower => Evaluate(char.IsLower);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> LowSurrogate => Evaluate(char.IsLowSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Number => Evaluate(char.IsNumber);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Punctuation => Evaluate(char.IsPunctuation);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Separator => Evaluate(char.IsSeparator);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Surrogate => Evaluate(char.IsSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Symbol => Evaluate(char.IsSymbol);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Upper => Evaluate(char.IsUpper);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> WhiteSpace => Evaluate(char.IsWhiteSpace);

        /// <inheritdoc />
        protected override IChainableCharCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableCharNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableCharDoNotCondition DoNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> In(string str)
        {
            return In(str, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            return Evaluate(s =>
            {
                var sourceAsString = s.ToString();
                (sourceAsString, str) = Transform(sourceAsString, str, ignoreCase, culture);
                return str != null && str.Contains(sourceAsString);
            });
        }

        private static (string Source, string OtherString) Transform(string source, string otherString, bool ignoreCase, CultureInfo culture)
        {
            if (!ignoreCase)
                return (source, otherString);

            return culture is null
                ? (source?.ToLower(), otherString?.ToLower())
                : (source?.ToLower(culture), otherString?.ToLower(culture));
        }
    }
}