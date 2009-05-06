using System.IO;

namespace Gorilla.Commons.Infrastructure.FileSystem
{
    public class ApplicationFile : IFile
    {
        public ApplicationFile(string path)
        {
            this.path = path;
        }

        public virtual string path { get; private set; }

        public virtual bool does_the_file_exist()
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        public void copy_to(string other_path)
        {
            File.Copy(path, other_path, true);
        }

        public void delete()
        {
            File.Delete(path);
        }

        public static implicit operator ApplicationFile(string file_path)
        {
            return new ApplicationFile(file_path);
        }

        public static implicit operator string(ApplicationFile file)
        {
            return file.path;
        }

        public bool Equals(ApplicationFile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.path, path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ApplicationFile)) return false;
            return Equals((ApplicationFile) obj);
        }

        public override int GetHashCode()
        {
            return (path != null ? path.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return path;
        }
    }
}