namespace gorilla.utility
{
    public interface Callback : Command
    {
    }

    public interface Callback<in T> : Command<T>
    {
    }
}