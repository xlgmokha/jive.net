namespace jive
{
  public interface Factory<out T>
  {
    T create();
  }
}
