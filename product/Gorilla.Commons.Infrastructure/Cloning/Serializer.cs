using System;

namespace Gorilla.Commons.Infrastructure.Cloning
{
    public interface Serializer<T> : IDisposable
    {
        void serialize(T to_serialize);
        T deserialize();
    }
}