namespace gorilla.utility
{
    public interface Factory<out T>
    {
        T create();
    }
}