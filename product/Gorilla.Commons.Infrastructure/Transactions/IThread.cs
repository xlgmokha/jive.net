namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IThread
    {
        T provide_slot_for<T>() where T : new();
    }
}