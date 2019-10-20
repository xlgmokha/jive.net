namespace gorilla.utility
{
    public interface Builder<out T>
    {
        T build();
    }
}