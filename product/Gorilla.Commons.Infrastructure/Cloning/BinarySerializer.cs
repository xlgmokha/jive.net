using System.Runtime.Serialization.Formatters.Binary;

namespace Gorilla.Commons.Infrastructure.Cloning
{
    public class BinarySerializer<T> : FileStreamSerializer<T>
    {
        public BinarySerializer(string file_path) : base(file_path, new BinaryFormatter())
        {
        }
    }
}