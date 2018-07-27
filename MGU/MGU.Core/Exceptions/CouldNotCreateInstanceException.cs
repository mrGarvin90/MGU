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
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="CouldNotCreateInstanceException" /> class.
        /// </summary>
        /// <param name="instanceType">The type of the instance.</param>
        /// <param name="parameters">The parameters used to create the instance.</param>
        /// <param name="innerException">The inner exception.</param>
        internal CouldNotCreateInstanceException([NotNull]Type instanceType, IEnumerable<object> parameters, Exception innerException)
            : base(CreateMessage(instanceType, parameters.ToArray()), innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private CouldNotCreateInstanceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            InstanceType = info.GetString(nameof(InstanceType));
        }

        /// <summary>
        /// Gets the type of the instance.
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

        private static string CreateMessage(Type instanceType, object[] parameters)
        {
            var builder = new StringBuilder();
            builder.Append("Could not create a new instance of ").Append(instanceType.FullName).Append(" with ");
            if (parameters is null || parameters.Length == 0)
                return builder.Append("no parameters.").ToString();

            builder.Append(parameters.Length == 1 ? "parameter " : "parameters ");
            Append(0);
            for (var index = 1; index < parameters.Length; index++)
            {
                builder.Append(", ");
                Append(index);
            }

            return builder.ToString();

            void Append(object parameter)
            {
                builder.AppendValue(parameter).Append(" ");
                if (parameter is null)
                    builder.Append("(<undefined>)");
                else
                    builder.Append("(").Append(parameter.GetType().FullName).Append(")");
            }
        }
    }
}