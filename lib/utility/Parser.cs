namespace gorilla.utility
{
    public interface Parser<out T>
    {
        T parse();
    }
}