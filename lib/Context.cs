namespace jive
{
  public interface Context
  {
    bool contains<T>(Key<T> key);
    void add<T>(Key<T> key, T value);
    T value_for<T>(Key<T> key);
    void remove<T>(Key<T> key);
  }
}
