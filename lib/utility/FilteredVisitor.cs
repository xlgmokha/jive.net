namespace jive.utility
{
  public class FilteredVisitor<T> : Visitor<T>
  {
    readonly Specification<T> condition;
    readonly Visitor<T> visitor;

    public FilteredVisitor(Specification<T> condition, Visitor<T> visitor)
    {
      this.condition = condition;
      this.visitor = visitor;
    }

    public void visit(T item_to_visit)
    {
      if (condition.is_satisfied_by(item_to_visit)) visitor.visit(item_to_visit);
    }
  }
}
