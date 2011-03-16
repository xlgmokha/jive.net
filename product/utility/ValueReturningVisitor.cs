namespace gorilla.commons.utility
{
    public interface ValueReturningVisitor<out Value, in T> : Visitor<T>
    {
        Value value { get; }
        void reset();
    }
}