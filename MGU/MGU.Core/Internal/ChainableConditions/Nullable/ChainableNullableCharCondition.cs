namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.Not;
    using Core.Interfaces.Couplers;
    using Interfaces.ChainableConditions.Nullable.DoesNot;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableNullableCharCondition" />
    /// <inheritdoc cref="IChainableNullableCharDoesNotCondition" />
    /// <summary>
    /// The <see cref="ChainableNullableCharCondition" /> class.
    /// </summary>
    internal sealed class ChainableNullableCharCondition
        : ChainableNullableComparableStructConditionBase<char, IChainableNullableCharCondition, IChainableNullableCharNotCondition, IChainableNullableCharDoesNotCondition>,
          IChainableNullableCharCondition,
          IChainableNullableCharDoesNotCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableCharCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source char.</param>
        internal ChainableNullableCharCondition(char? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Control => Evaluate(char.IsControl);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Digit => Evaluate(char.IsDigit);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> HighSurrogate => Evaluate(char.IsHighSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Letter => Evaluate(char.IsLetter);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Lower => Evaluate(char.IsLower);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> LowSurrogate => Evaluate(char.IsLowSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Number => Evaluate(char.IsNumber);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Punctuation => Evaluate(char.IsPunctuation);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Separator => Evaluate(char.IsSeparator);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Surrogate => Evaluate(char.IsSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Symbol => Evaluate(char.IsSymbol);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Upper => Evaluate(char.IsUpper);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> WhiteSpace => Evaluate(char.IsWhiteSpace);

        /// <inheritdoc />
        protected override IChainableNullableCharCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableNullableCharNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableNullableCharDoesNotCondition DoesNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> In(string str, bool ignoreCase = false, CultureInfo culture = null)
        {
            return base.Evaluate(s =>
            {
                if (!s.HasValue || str is null)
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

        private IConditionCoupler<char?, IChainableNullableCharCondition> Evaluate(Func<char, bool> condition, [CallerMemberName]string callerMemberName = "")
        {
            return base.Evaluate(s => s.HasValue && condition(s.Value), callerMemberName);
        }
    }
}