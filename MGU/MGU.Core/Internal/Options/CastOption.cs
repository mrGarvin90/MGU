namespace MGU.Core.Internal.Options
{
    using Core.Interfaces.Options;

    /// <inheritdoc />
    /// <summary>
    /// The <see cref="CastOption"/> class.
    /// </summary>
    /// <seealso cref="ICastOption" />
    internal class CastOption : ICastOption
    {
        private readonly bool _castSource;

        private readonly object _source;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastOption"/> class.
        /// </summary>
        /// <param name="source">The source object.</param>
        internal CastOption(object source)
        {
            _castSource = true;
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CastOption"/> class.
        /// </summary>
        /// <param name="castSource">
        /// If set to <see langword="true" /> the source object will be cast to the specified target type.
        /// If set to <see langword="false" /> the default value of the target type will be returned.
        /// </param>
        /// <param name="source">The source object.</param>
        internal CastOption(bool castSource, object source)
        {
            _castSource = castSource;
            _source = source;
        }

        /// <inheritdoc />
        public TTarget To<TTarget>(bool unboxBeforeCast = false)
        {
            if (_castSource)
            {
                return unboxBeforeCast
                    ? (TTarget)(dynamic)_source
                    : (TTarget)_source;
            }

            return default;
        }

        /// <inheritdoc />
        public TTarget ToOrDefault<TTarget>(bool unboxBeforeCast = false)
        {
            try
            {
                return To<TTarget>(unboxBeforeCast);
            }
            catch
            {
                return default;
            }
        }
    }
}