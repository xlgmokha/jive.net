using System.IO;

namespace jive.infrastructure.cloning
{
  public interface IPrototype
  {
    T clone<T>(T item);
  }

  public class Prototype : IPrototype
  {
    public T clone<T>(T item)
    {
      using (var serializer = new BinarySerializer<T>(Path.GetTempFileName()))
      {
        serializer.serialize(item);
        return serializer.deserialize();
      }
    }
  }
}
