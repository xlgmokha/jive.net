namespace jive
{
  public interface Configuration<in T>
  {
    void configure(T item);
  }
}
