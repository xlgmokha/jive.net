namespace jive.utility
{
  public class ScopedContext : Context
  {
    ScopedStorage storage;

    public ScopedContext(ScopedStorage storage)
    {
      this.storage = storage;
    }

    public bool contains<T>(Key<T> key)
    {
      return key.is_found_in(storage.provide_storage());
    }

    public void add<T>(Key<T> key, T value)
    {
      key.add_value_to(storage.provide_storage(), value);
    }

    public T value_for<T>(Key<T> key)
    {
      return key.parse_from(storage.provide_storage());
    }

    public void remove<T>(Key<T> key)
    {
      key.remove_from(storage.provide_storage());
    }
  }
}
