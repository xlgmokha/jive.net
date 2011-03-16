namespace gorilla.commons.utility
{
    public interface Builder<out T>
    {
        T build();
    }
}