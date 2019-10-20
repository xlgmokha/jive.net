namespace gorilla.utility
{
    public interface Import<in T>
    {
        void import(T item);
    }
}