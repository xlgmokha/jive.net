namespace gorilla.utility
{
    public interface ParameterizedCommand<in T>
    {
        void run(T item);
    }
}