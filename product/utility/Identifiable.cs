namespace gorilla.utility
{
    public interface Identifiable<T>
    {
        Id<T> id { get; }
    }
}