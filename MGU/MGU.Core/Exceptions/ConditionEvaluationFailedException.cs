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
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionEvaluationFailedException"/> class.
        /// </summary>
        /// <param name="conditionType">The condition type.</param>
        /// <param name="conditionName">The condition name.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="sourceObjectValue">The source value.</param>
        /// <param name="innerException">The inner exception.</param>
        internal ConditionEvaluationFailedException(
            [NotNull] Type conditionType,
            [NotNull] string conditionName,
            [NotNull] Type sourceType,
            object sourceObjectValue,
            Exception innerException)
            : base(CreateMessage(conditionType, conditionName, sourceType, sourceObjectValue), innerException)
        {
            SourceObjectType = sourceType.FullName;
            SourceObjectValue = sourceObjectValue;
            ConditionType = conditionType.Name.Remove(0, 1);
            ConditionName = conditionName;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private ConditionEvaluationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ConditionType = info.GetString(nameof(ConditionType));
            ConditionName = info.GetString(nameof(ConditionName));
            SourceObjectType = info.GetString(nameof(SourceObjectType));
            SourceObjectValue = info.GetValue(nameof(SourceObjectValue), typeof(object));
        }

        /// <summary>
        /// Gets the condition type.
        /// </summary>
        public string ConditionType { get; }

        /// <summary>
        /// Gets the condition name.
        /// </summary>
        public string ConditionName { get; }

        /// <summary>
        /// Gets the full name of the source object type.
        /// </summary>
        public string SourceObjectType { get; }

        /// <summary>
        /// Gets the value of the source object.
        /// </summary>
        public object SourceObjectValue { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue(nameof(ConditionType), ConditionType);
            info.AddValue(nameof(ConditionName), ConditionName);
            info.AddValue(nameof(SourceObjectType), SourceObjectType);
            info.AddValue(nameof(SourceObjectValue), SourceObjectValue);
            base.GetObjectData(info, context);
        }

        private static string CreateMessage(
            Type conditionType,
            string conditionName,
            Type sourceType,
            object sourceValue)
        {
            var builder = new StringBuilder();
            return builder
                .AppendLine("An exception was thrown while evaluating a condition")
                .Append("Condition type: ").AppendLine(conditionType.Name.Remove(0, 1))
                .Append("Condition name: ").AppendLine(conditionName)
                .Append("Source type: ").AppendLine(sourceType.FullName)
                .Append("Source value: ").AppendValue(sourceValue).AppendLine()
                .ToString();
        }
    }
}