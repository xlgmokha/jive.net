namespace jive.utility
{
  public interface Factory<out T>
  {
    T create();
  }
}
