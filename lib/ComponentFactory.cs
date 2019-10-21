namespace jive
{
  public interface ComponentFactory<T> : Factory<T> where T : new() {}
}
