namespace jive
{
  public interface CallbackCommand<out T> : Command<Callback<T>>
  {
  }
}
