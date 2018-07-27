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
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableCharCondition"/> class.
        /// </summary>
        /// <param name="source">The source char.</param>
        internal ChainableCharCondition(char source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableCharCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableCharNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableCharDoNotCondition DoNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Control => SetResult(char.IsControl);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Digit => SetResult(char.IsDigit);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> HighSurrogate => SetResult(char.IsHighSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Letter => SetResult(char.IsLetter);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Lower => SetResult(char.IsLower);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> LowSurrogate => SetResult(char.IsLowSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Number => SetResult(char.IsNumber);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Punctuation => SetResult(char.IsPunctuation);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Separator => SetResult(char.IsSeparator);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Surrogate => SetResult(char.IsSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Symbol => SetResult(char.IsSymbol);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> Upper => SetResult(char.IsUpper);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> WhiteSpace => SetResult(char.IsWhiteSpace);

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> In(string str)
        {
            return In(str, false);
        }
        
        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            return SetResult(s =>
            {
                var sourceAsString = s.ToString();
                (sourceAsString, str) = Transform(sourceAsString, str, ignoreCase, culture);
                return str != null && str.Contains(sourceAsString);
            });
        }

        private static (string Source, string OtherString) Transform(string source, string otherString, bool ignoreCase, CultureInfo culture)
        {
            if (!ignoreCase) return (source, otherString);

            return culture is null
                ? (source?.ToLower(), otherString?.ToLower())
                : (source?.ToLower(culture), otherString?.ToLower(culture));
        }
    }
}