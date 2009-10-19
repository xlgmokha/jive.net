namespace gorilla.commons.utility
{
    public interface Identifiable<T>
    {
        Id<T> id { get; }
    }
}