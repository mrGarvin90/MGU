namespace MGU.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Text;
    using Internal.Extensions;
    using JetBrains.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The exception that is throw when an instance of type could not be created.
    /// </summary>
    [Serializable]
    public sealed class CouldNotCreateInstanceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CouldNotCreateInstanceException" /> class.
        /// </summary>
        /// <param name="instanceType">The type of the instance.</param>
        /// <param name="parameters">The parameters used to create the instance.</param>
        /// <param name="innerException">The inner exception.</param>
        internal CouldNotCreateInstanceException([NotNull]Type instanceType, IEnumerable<object> parameters, Exception innerException)
            : this(instanceType, CreateMessage(instanceType, parameters), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouldNotCreateInstanceException"/> class.
        /// </summary>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="parameterTypes">The types of the parameters used to create the instance.</param>
        /// <param name="parameters">The parameters used to create the instance.</param>
        /// <param name="innerException">The inner exception.</param>
        internal CouldNotCreateInstanceException([NotNull]Type instanceType, IEnumerable<Type> parameterTypes, IEnumerable<object> parameters, Exception innerException)
            : this(instanceType, CreateMessage(instanceType, parameterTypes, parameters), innerException)
        {
        }

        private CouldNotCreateInstanceException(Type instanceType, string message, Exception innerException)
            : base(message, innerException)
        {
            InstanceType = instanceType.FullName;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private CouldNotCreateInstanceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            InstanceType = info.GetString(nameof(InstanceType));
        }

        /// <summary>
        /// Gets the name of the instance type.
        /// </summary>
        public string InstanceType { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue(nameof(InstanceType), InstanceType);
            base.GetObjectData(info, context);
        }

        private static string CreateMessage(Type instanceType, IEnumerable<object> parameters)
        {
            var builder = CreateNewMessageBuilder(instanceType).Append(" with ");
            if (!parameters?.Any() ?? true)
                return builder.Append("no parameters.").ToString();
            builder.AppendLine("parameters:");
            return builder.AppendValuesAndTypes(parameters, Environment.NewLine).ToString();
        }

        private static string CreateMessage(Type instanceType, IEnumerable<Type> parameterTypes, IEnumerable<object> parameters)
        {
            var builder = CreateNewMessageBuilder(instanceType).AppendLine();
            if (!parameterTypes?.Any() ?? true)
                builder.AppendLine("No parameter types.");
            else
                builder.AppendLine("Parameter types:").AppendValues(parameterTypes.Select(pt => pt?.FullName), Environment.NewLine).AppendLine();
            if (!parameters?.Any() ?? true)
                builder.Append("No parameters.");
            else
                builder.AppendLine("Parameters:").AppendValuesAndTypes(parameters, Environment.NewLine);
            return builder.ToString();
        }

        private static StringBuilder CreateNewMessageBuilder(Type instanceType)
            => new StringBuilder("Could not create a new instance of ").Append(instanceType.FullName);
    }
}