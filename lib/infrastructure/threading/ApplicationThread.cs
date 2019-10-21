namespace jive.infrastructure.threading
{
  public interface ApplicationThread
  {
    T provide_slot_for<T>() where T : class, new();
  }
}
