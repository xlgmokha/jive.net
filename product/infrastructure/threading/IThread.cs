namespace gorilla.infrastructure.threading
{
    public interface IThread
    {
        T provide_slot_for<T>() where T : class, new();
    }
}