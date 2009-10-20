namespace gorilla.commons.utility
{
    public interface Callback : Command
    {
    }

    public interface Callback<T> : ParameterizedCommand<T>
    {
    }
}