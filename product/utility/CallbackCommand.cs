namespace gorilla.commons.utility
{
    public interface CallbackCommand<out T> : ParameterizedCommand<Callback<T>>
    {
    }
}