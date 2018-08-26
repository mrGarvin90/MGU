namespace MGU.Core.Internal.Options
{
    using Interfaces.Couplers;
    using Interfaces.Options;

    /// <inheritdoc cref="ConditionResultOption{TSource}" />
    /// <inheritdoc cref="INotTypeConditionResultOption{TSource}" />
    /// <summary>
    /// The <see cref="NotTypeConditionResultOption{TSource}"/> class.
    /// </summary>
    internal sealed class NotTypeConditionResultOption<TSource>
        : ConditionResultOption<TSource>,
          INotTypeConditionResultOption<TSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotTypeConditionResultOption{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="sourceIsNotType">Determines the outcome of the options.</param>
        internal NotTypeConditionResultOption(TSource source, bool sourceIsNotType)
            : base(source, sourceIsNotType)
        {
        }

        /// <inheritdoc />
        public INotTypeConditionResultOptionCoupler<TValue> Use<TValue>(TValue value)
            => new NotTypeConditionResultOptionCoupler<TValue>(value, Result);

        private sealed class NotTypeConditionResultOptionCoupler<TValue> : INotTypeConditionResultOptionCoupler<TValue>
        {
            private readonly TValue _value;
            private readonly bool _valueIsNotType;

            internal NotTypeConditionResultOptionCoupler(TValue value, bool valueIsNotType)
            {
                _value = value;
                _valueIsNotType = valueIsNotType;
            }

            /// <inheritdoc />
            public IConditionResultOption<TValue> And => new ConditionResultOption<TValue>(_value, _valueIsNotType);
        }
    }
}