namespace jive.utility
{
  public interface Visitable<out T>
  {
    void accept(Visitor<T> visitor);
  }
}
