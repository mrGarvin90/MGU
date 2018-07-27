namespace MGU.Core.Helpers
{
    /// <summary>
    /// The <see cref="DefaultMessage"/> class.
    /// </summary>
    public class DefaultMessage
    {
        private DefaultMessage(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a empty default message.
        /// </summary>
        public static DefaultMessage Empty => new DefaultMessage(null);

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DefaultMessage"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public static DefaultMessage New(string value)
        {
            return new DefaultMessage(value);
        }
    }
}