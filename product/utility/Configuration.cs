namespace gorilla.utility
{
    public interface Configuration<in T>
    {
        void configure(T item);
    }
}