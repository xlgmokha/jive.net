using System.IO;
using System.Runtime.Serialization;

namespace jive
{
  public class FileStreamSerializer<T> : Serializer<T>
  {
    public FileStreamSerializer(string file_path, IFormatter formatter)
    {
      this.file_path = file_path;
      this.formatter = formatter;
    }

    public void serialize(T to_serialize)
    {
      using (var stream = new FileStream(file_path, FileMode.Create, FileAccess.Write))
        formatter.Serialize(stream, to_serialize);
    }

    public T deserialize()
    {
      using (var stream = new FileStream(file_path, FileMode.Open, FileAccess.Read))
        return (T) formatter.Deserialize(stream);
    }

    public void Dispose()
    {
      File.Delete(file_path);
    }

    readonly string file_path;
    readonly IFormatter formatter;
  }
}
