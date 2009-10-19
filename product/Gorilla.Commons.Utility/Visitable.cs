namespace gorilla.commons.utility
{
    public interface Visitable<T>
    {
        void accept(Visitor<T> visitor);
    }
}