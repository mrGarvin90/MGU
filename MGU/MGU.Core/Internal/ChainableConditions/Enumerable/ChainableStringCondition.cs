namespace MGU.Core.Internal.ChainableConditions.Enumerable
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Base;
    using Core.Interfaces.ChainableConditions.Enumerable;
    using Core.Interfaces.ChainableConditions.Enumerable.Count;
    using Core.Interfaces.ChainableConditions.Enumerable.DoNot;
    using Core.Interfaces.ChainableConditions.Enumerable.Not;
    using Core.Interfaces.Couplers;

    /// <inheritdoc cref="ChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoNotCondition}" />
    /// <inheritdoc cref="IChainableStringCondition" />
    /// <inheritdoc cref="IChainableStringDoNotCondition" />
    /// <summary>
    /// The <see cref="ChainableStringCondition"/> class.
    /// </summary>
    internal sealed class ChainableStringCondition
        : ChainableEnumerableConditionBase<string, char, IChainableStringCondition, IChainableStringNotCondition, IChainableStringDoNotCondition>,
          IChainableStringCondition,
          IChainableStringDoNotCondition
    {
        private static readonly Regex WhiteSpaceRegex = new Regex(@"^\s+$", RegexOptions.Compiled);

        private bool _nullWasCalled;

        private bool _orWasCalled;

        private bool _nullResultWasInverted;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainableStringCondition"/> class.
        /// </summary>
        /// <param name="source">The source string.</param>
        internal ChainableStringCondition(string source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public override IChainableStringCondition Or
        {
            get
            {
                _orWasCalled = true;
                return base.Or;
            }
        }

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Null
        {
            get
            {
                _nullWasCalled = true;
                _nullResultWasInverted = InvertResult;
                return Evaluate(s => s is null);
            }
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> WhiteSpace
        {
            get
            {
                var checkNullOrWhiteSpace = _nullWasCalled && _orWasCalled && !InvertResult;
                var invertResult = _nullResultWasInverted;
                _nullWasCalled = _orWasCalled = _nullResultWasInverted = false;
                if (!checkNullOrWhiteSpace)
                    return Evaluate(s => WhiteSpaceRegex.IsMatch(s));
                Result = false;
                return Evaluate(s => invertResult ? !string.IsNullOrWhiteSpace(s) : string.IsNullOrWhiteSpace(s));
            }
        }

        /// <inheritdoc />
        public IChainableEnumerableCountCondition<string, char, IChainableStringCondition> Length => Couple(this);

        /// <inheritdoc />
        protected override IChainableStringCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableStringNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableStringDoNotCondition DoNotCondition => this;

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartsWith(string value)
        {
            return StartsWith(value, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartWith(string value)
        {
            return StartsWith(value, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartWith(string value, bool ignoreCase, CultureInfo culture = null)
        {
            return StartsWith(value, ignoreCase);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartsWith(string value, bool ignoreCase, CultureInfo culture = null)
        {
            return Evaluate(s =>
            {
                if (value is null)
                    return false;
                (s, value) = Transform(s, value, ignoreCase, culture);
                return s.StartsWith(value);
            });
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndsWith(string value)
        {
            return EndsWith(value, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndWith(string value)
        {
            return EndsWith(value, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndWith(string value, bool ignoreCase, CultureInfo culture = null)
        {
            return EndsWith(value, ignoreCase);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndsWith(string value, bool ignoreCase, CultureInfo culture = null)
        {
            return Evaluate(s =>
            {
                if (value is null)
                    return false;
                (s, value) = Transform(s, value, ignoreCase, culture);
                return s.EndsWith(value);
            });
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contains(string value)
        {
            return Evaluate(s => value != null && s.Contains(value));
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contain(string value)
        {
            return Contains(value);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> In(string other)
        {
            return In(other, false);
        }

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> In(string other, bool ignoreCase, CultureInfo culture = null)
        {
            return Evaluate(s =>
            {
                if (other is null)
                    return false;
                (s, other) = Transform(s, other, ignoreCase, culture);
                return other != null && s != null && other.Contains(s);
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