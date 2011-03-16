namespace gorilla.utility
{
    public interface CallbackCommand<out T> : ParameterizedCommand<Callback<T>>
    {
    }
}