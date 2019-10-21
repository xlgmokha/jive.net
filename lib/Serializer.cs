using System;

namespace jive
{
  public interface Serializer<T> : IDisposable
  {
    void serialize(T to_serialize);
    T deserialize();
  }
}
