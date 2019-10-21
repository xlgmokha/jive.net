using System;

namespace jive.infrastructure.cloning
{
  public interface Serializer<T> : IDisposable
  {
    void serialize(T to_serialize);
    T deserialize();
  }
}
