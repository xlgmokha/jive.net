namespace gorilla.commons.utility
{
    public interface Visitable<out T>
    {
        void accept(Visitor<T> visitor);
    }
}