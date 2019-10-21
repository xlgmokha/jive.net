namespace jive
{
  public interface Parser<out T>
  {
    T parse();
  }
}
