namespace MGU.Core.Helpers
{
    /// <summary>
    /// The <see cref="DefaultMessage"/> class.
    /// </summary>
    public class DefaultMessage
    {
        private readonly string _value;

        private DefaultMessage(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DefaultMessage"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="DefaultMessage"/> class.</returns>
        public static DefaultMessage New(string value = "") => new DefaultMessage(value);

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}