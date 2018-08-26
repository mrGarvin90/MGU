namespace MGU.Core.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;

    public abstract class ExceptionTestBase<TException>
        where TException : Exception
    {
        private readonly List<Type[]> _types;

        protected ExceptionTestBase(Type[] types, params Type[][] additionalTypes)
        {
            _types = new List<Type[]> { types };
            if (additionalTypes != null)
                _types.AddRange(additionalTypes);
        }

        protected TException SerializeAndDeserialize(TException originalException)
        {
            var buffer = new byte[4096];
            var memoryStream = new MemoryStream(buffer);
            var memoryStream2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, originalException);
            var deserializedException = (TException)formatter.Deserialize(memoryStream2);

            return deserializedException;
        }

        protected TException CreateException(params object[] parameters)
        {
            foreach (var types in _types)
            {
                try
                {
                    var constructor = typeof(TException)
                        .GetConstructor(
                            BindingFlags.NonPublic | BindingFlags.Instance,
                            null,
                            types,
                            null);
                    if (constructor is null)
                        continue;
                    return (TException)constructor.Invoke(parameters);
                }
                catch
                {
                }
            }

            throw new Exception($"Could not create an exception of type {typeof(TException).FullName}");
        }
    }
}