namespace Gorilla.Commons.Infrastructure.FileSystem
{
    public interface File
    {
        string path { get; }
        bool does_the_file_exist();
        void copy_to(string path);
        void delete();
    }
}