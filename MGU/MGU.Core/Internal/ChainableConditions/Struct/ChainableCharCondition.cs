namespace MGU.Core.Internal.ChainableConditions.Struct
{
    using System.Globalization;
    using Base;
    using Core.Interfaces.ChainableConditions.Struct;
    using Core.Interfaces.ChainableConditions.Struct.Not;
    using Core.Interfaces.Couplers;
    using Interfaces.ChainableConditions.Struct.DoesNot;

    /// <inheritdoc cref="ChainableComparableConditionBase{TSource,TChainableComparableCondition,TChainableComparableNotCondition,TChainableComparableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableCharCondition" />
    /// <inheritdoc cref="IChainableCharDoesNotCondition" />
    /// <summary>
    /// The <see cref="ChainableCharCondition" /> class.
    /// </summary>
    internal sealed class ChainableCharCondition
        : ChainableComparableConditionBase<char, IChainableCharCondition, IChainableCharNotCondition, IChainableCharDoesNotCondition>,
          IChainableCharCondition,
          IChainableCharDoesNotCondition
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
        protected override IChainableCharDoesNotCondition DoesNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<char, IChainableCharCondition> In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            return Evaluate(s =>
            {
                if (str is null)
                    return false;
                var source = s.ToString();
                if (ignoreCase)
                {
                    source = culture is null ? source.ToLower() : source.ToLower(culture);
                    str = culture is null ? str.ToLower() : str.ToLower(culture);
                }

                return str.Contains(source);
            });
        }
    }
}