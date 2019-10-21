namespace jive.utility
{
  public interface Parser<out T>
  {
    T parse();
  }
}
