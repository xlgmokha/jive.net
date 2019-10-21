namespace jive
{
  public interface Import<in T>
  {
    void import(T item);
  }
}
