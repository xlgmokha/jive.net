namespace gorilla.commons.utility
{
    public interface Visitor<T>
    {
        void visit(T item_to_visit);
    }
}