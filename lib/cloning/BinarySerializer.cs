using System.Runtime.Serialization.Formatters.Binary;

namespace jive.cloning
{
  public class BinarySerializer<T> : FileStreamSerializer<T>
  {
    public BinarySerializer(string file_path) : base(file_path, new BinaryFormatter())
    {
    }
  }
}
