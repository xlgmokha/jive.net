namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IContext
    {
        bool contains<T>(IKey<T> key);
        void add<T>(IKey<T> key, T value);
        T value_for<T>(IKey<T> key);
        void remove<T>(IKey<T> key);
    }
}