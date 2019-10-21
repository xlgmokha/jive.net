namespace jive
{
  public interface Visitable<out T>
  {
    void accept(Visitor<T> visitor);
  }
}
