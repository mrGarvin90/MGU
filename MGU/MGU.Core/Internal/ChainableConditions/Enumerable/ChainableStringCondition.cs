namespace MGU.Core.Internal.ChainableConditions.Enumerable
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Base;
    using Core.Interfaces.ChainableConditions.Enumerable;
    using Core.Interfaces.ChainableConditions.Enumerable.Count;
    using Core.Interfaces.ChainableConditions.Enumerable.Not;
    using Core.Interfaces.Couplers;
    using Interfaces.ChainableConditions.Enumerable.DoesNot;

    /// <inheritdoc cref="ChainableEnumerableConditionBase{TSource,TObject,TChainableCondition,TChainableNotCondition,TChainableDoesNotCondition}" />
    /// <inheritdoc cref="IChainableStringCondition" />
    /// <inheritdoc cref="IChainableStringDoesNotCondition" />
    /// <summary>
    /// The <see cref="ChainableStringCondition"/> class.
    /// </summary>
    internal sealed class ChainableStringCondition
        : ChainableEnumerableConditionBase<string, char, IChainableStringCondition, IChainableStringNotCondition, IChainableStringDoesNotCondition>,
          IChainableStringCondition,
          IChainableStringDoesNotCondition
    {
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
        public IChainableEnumerableCountCondition<string, char, IChainableStringCondition> Length => Return(this);

        /// <inheritdoc />
        IConditionCoupler<string, IChainableStringCondition> IChainableStringNotCondition.Empty => Return(Evaluate(s => s.Length == 0));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> WhiteSpace
        {
            get
            {
                if (InvertConditionResult || !_nullWasCalled || !_orWasCalled)
                {
                    return Return(
                        Evaluate(s =>
                        {
                            for (var index = 0; index < s.Length; index++)
                            {
                                if (!char.IsWhiteSpace(s[index]))
                                    return false;
                            }

                            return s.Length != 0;
                        }));
                }

                InvertConditionResult = _nullResultWasInverted;
                Result = false;
                return Return(Evaluate(string.IsNullOrWhiteSpace));
            }
        }

        #region StartsWith And StartWith

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartsWith(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.StartsWith(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartsWith(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.StartsWith(v), source, value, ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartWith(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.StartsWith(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> StartWith(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.StartsWith(v), source, value, ignoreCase, culture)));

        #endregion

        #region EndsWith And EndWith

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndsWith(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.EndsWith(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndsWith(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.EndsWith(v), source, value, ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndWith(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.EndsWith(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> EndWith(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.EndsWith(v), source, value, ignoreCase, culture)));

        #endregion

        #region Contains And Contain

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contains(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.Contains(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contains(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.Contains(v), source, value, ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contain(char character, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.Contains(v), source, character.ToString(), ignoreCase, culture)));

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> Contain(string value, bool ignoreCase = false, CultureInfo culture = null)
            => Return(Evaluate(source => Check((s, v) => s.Contains(v), source, value, ignoreCase, culture)));

        #endregion

        /// <inheritdoc />
        public IConditionCoupler<string, IChainableStringCondition> In(string other, bool ignoreCase = false, CultureInfo culture = null)
            => Return(
                Evaluate(s =>
                {
                    if (s is null || other is null)
                        return false;
                    if (ignoreCase)
                    {
                        s = culture is null ? s.ToLower() : s.ToLower(culture);
                        other = culture is null ? other.ToLower() : other.ToLower(culture);
                    }

                    return other.Contains(s);
                }));

        private static bool Check(Func<string, string, bool> func, string str, string value, bool ignoreCase, CultureInfo culture)
        {
            if (value is null)
                return false;
            if (ignoreCase)
            {
                str = culture is null ? str.ToLower() : str.ToLower(culture);
                value = culture is null ? value.ToLower() : value.ToLower(culture);
            }

            return func(str, value);
        }

        private T Return<T>(T returnValue)
        {
            _nullWasCalled = _nullResultWasInverted = _orWasCalled = false;
            return returnValue;
        }

        #region Overriden Properties And Methods

#pragma warning disable SA1201 // Elements must appear in the correct order
#pragma warning disable SA1202 // Elements must be ordered by access

        /// <inheritdoc />
        public override IChainableStringCondition And => Return(base.And);

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
        protected override IChainableStringCondition Condition => this;

        /// <inheritdoc />
        protected override IChainableStringNotCondition NotCondition => this;

        /// <inheritdoc />
        protected override IChainableStringDoesNotCondition DoesNotCondition => this;

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Null
        {
            get
            {
                _nullWasCalled = true;
                _nullResultWasInverted = InvertConditionResult;
                return Evaluate(s => s is null);
            }
        }

        /// <inheritdoc />
        public override IChainableEnumerableCountCondition<string, char, IChainableStringCondition> Count => Return(this);

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Fulfills(Func<string, bool> condition)
            => Return(Evaluate(condition));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Fulfill(Func<string, bool> condition)
            => Return(Evaluate(condition));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> EqualTo(string other)
            => Return(Evaluate(s => s == other));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> In(IEnumerable<string> collection, IEqualityComparer<string> comparer = null)
            => Return(Evaluate(s => collection?.Contains(s) ?? false));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> All(Func<char, bool> predicate)
            => Return(Evaluate(s => s.All(predicate)));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Any(Func<char, bool> predicate)
            => Return(Evaluate(s => s.Any(predicate)));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> None(Func<char, bool> predicate)
            => Return(Evaluate(s => !s.Any(predicate)));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> SequentiallyEqualTo(IEnumerable<char> other, IEqualityComparer<char> comparer = null)
            => Return(base.SequentiallyEqualTo(other, comparer));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Contains(char value, IEqualityComparer<char> comparer = null)
            => Return(base.Contains(value, comparer));

        /// <inheritdoc />
        public override IConditionCoupler<string, IChainableStringCondition> Contain(char value, IEqualityComparer<char> comparer = null)
            => Return(base.Contain(value, comparer));

        #endregion
    }
}