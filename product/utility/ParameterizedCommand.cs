namespace gorilla.commons.utility
{
    public interface ParameterizedCommand<in T>
    {
        void run(T item);
    }
}