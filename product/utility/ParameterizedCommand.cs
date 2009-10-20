namespace gorilla.commons.utility
{
    public interface ParameterizedCommand<T>
    {
        void run(T item);
    }
}