namespace jive
{
  public interface Visitor<in T>
  {
    void visit(T item_to_visit);
  }
}
