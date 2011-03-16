namespace gorilla.commons.utility
{
    public interface Factory<out T>
    {
        T create();
    }
}