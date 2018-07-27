namespace MGU.Core.Internal.ChainableConditions.Nullable
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using Base;
    using Core.Interfaces.ChainableConditions.Nullable;
    using Core.Interfaces.ChainableConditions.Nullable.DoNot;
    using Core.Interfaces.ChainableConditions.Nullable.Not;
    using Core.Interfaces.Couplers;

    /// <inheritdoc cref="ChainableConditionBase{TSource,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableNullableCharCondition" />
    /// <inheritdoc cref="IChainableNullableCharDoNotCondition" />
    /// <summary>
    /// The <see cref="ChainableNullableCharCondition" /> class.
    /// </summary>
    internal sealed class ChainableNullableCharCondition
        : ChainableNullableComparableStructConditionBase<char, IChainableNullableCharCondition, IChainableNullableCharNotCondition, IChainableNullableCharDoNotCondition>,
          IChainableNullableCharCondition,
          IChainableNullableCharDoNotCondition
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableNullableCharCondition"/> class.
        /// </summary>
        /// <param name="source">The nullable source char.</param>
        internal ChainableNullableCharCondition(char? source)
            : base(source)
        {
        }

        /// <inheritdoc />
        protected override IChainableNullableCharCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableNullableCharNotCondition NotCondition => this;
        
        /// <inheritdoc />
        protected override IChainableNullableCharDoNotCondition DoNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Control => SetResult(char.IsControl);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Digit => SetResult(char.IsDigit);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> HighSurrogate => SetResult(char.IsHighSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Letter => SetResult(char.IsLetter);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Lower => SetResult(char.IsLower);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> LowSurrogate => SetResult(char.IsLowSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Number => SetResult(char.IsNumber);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Punctuation => SetResult(char.IsPunctuation);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Separator => SetResult(char.IsSeparator);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Surrogate => SetResult(char.IsSurrogate);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Symbol => SetResult(char.IsSymbol);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> Upper => SetResult(char.IsUpper);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> WhiteSpace => SetResult(char.IsWhiteSpace);

        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> In(string str)
        {
            return In(str, false);
        }
        
        /// <inheritdoc />
        public IConditionCoupler<char?, IChainableNullableCharCondition> In(string str, bool ignoreCase, CultureInfo culture = null)
        {
            return base.SetResult(s =>
            {
                var sourceAsString = s.ToString();
                (sourceAsString, str) = Transform(sourceAsString, str, ignoreCase, culture);
                return str != null && s != null && str.Contains(sourceAsString);
            });
        }

        private IConditionCoupler<char?, IChainableNullableCharCondition> SetResult(Func<char, bool> condition, [CallerMemberName]string callerMemberName = "")
        {
            return base.SetResult(s => condition(s.Value), callerMemberName);
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