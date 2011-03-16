namespace gorilla.commons.utility
{
    public interface Parser<out T>
    {
        T parse();
    }
}