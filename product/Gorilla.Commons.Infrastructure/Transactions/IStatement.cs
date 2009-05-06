namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IStatement
    {
        void prepare(IDatabaseConnection connection);
    }
}