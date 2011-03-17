namespace gorilla.utility
{
    public interface CallbackCommand<out T> : Command<Callback<T>>
    {
    }
}