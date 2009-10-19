namespace gorilla.commons.utility
{
    public interface ValueReturningVisitor<Value, T> : Visitor<T>
    {
        Value value { get; }
        void reset();
    }
}