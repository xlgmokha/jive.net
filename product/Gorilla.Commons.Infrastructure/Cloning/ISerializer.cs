using System;

namespace Gorilla.Commons.Infrastructure.Cloning
{
    public interface ISerializer<T> : IDisposable
    {
        void serialize(T to_serialize);
        T deserialize();
    }
}