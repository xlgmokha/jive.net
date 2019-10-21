namespace jive
{
  public interface Identifiable<T>
  {
    Id<T> id { get; }
  }
}
