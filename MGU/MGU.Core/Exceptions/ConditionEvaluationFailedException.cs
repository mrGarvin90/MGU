namespace MGU.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Text;
    using Internal.Extensions;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The exception that is thrown when the evaluation of a condition failed.
    /// </summary>
    [Serializable]
    public sealed class ConditionEvaluationFailedException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionEvaluationFailedException"/> class.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="sourceObjectValue">The source value.</param>
        /// <param name="conditionTrace">The condition trace.</param>
        /// <param name="innerException">The inner exception.</param>
        internal ConditionEvaluationFailedException([NotNull]Type sourceType, object sourceObjectValue, [NotNull]string conditionTrace, Exception innerException)
            : base(CreateMessage(sourceType, sourceObjectValue, conditionTrace), innerException)
        {
            SourceObjectType = sourceType.FullName;
            SourceObjectValue = sourceObjectValue;
            ConditionTrace = conditionTrace;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private ConditionEvaluationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            SourceObjectType = info.GetString(nameof(SourceObjectType));
            SourceObjectValue = info.GetValue(nameof(SourceObjectValue), typeof(object));
            ConditionTrace = info.GetString(nameof(ConditionTrace));
        }

        /// <summary>
        /// Gets the full name of the source object type.
        /// </summary>
        public string SourceObjectType { get; }

        /// <summary>
        /// Gets the value of the source object.
        /// </summary>
        public object SourceObjectValue { get; }

        /// <summary>
        /// Gets the condition trace.
        /// </summary>
        public string ConditionTrace { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue(nameof(SourceObjectType), SourceObjectType);
            info.AddValue(nameof(SourceObjectValue), SourceObjectValue);
            info.AddValue(nameof(ConditionTrace), ConditionTrace);
            base.GetObjectData(info, context);
        }

        private static string CreateMessage(Type sourceType, object sourceValue, string trace)
        {
            var builder = new StringBuilder();
            builder.AppendLine("An exception was thrown while evaluating a condition")
                .AppendLine(trace)
                .Append("Source type: ").AppendLine(sourceType.FullName)
                .Append("Source value: ").AppendValue(sourceValue).AppendLine();
            return builder.ToString();
        }
    }
}