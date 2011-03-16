namespace gorilla.commons.utility
{
    public interface Callback : Command
    {
    }

    public interface Callback<in T> : ParameterizedCommand<T>
    {
    }
}