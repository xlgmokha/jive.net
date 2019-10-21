namespace jive.utility
{
  public class NotSpecification<T> : Specification<T>
  {
    readonly Specification<T> item_to_match;

    public NotSpecification(Specification<T> item_to_match)
    {
      this.item_to_match = item_to_match;
    }

    public bool is_satisfied_by(T item)
    {
      return !item_to_match.is_satisfied_by(item);
    }
  }
}
