namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IContextFactory
    {
        IContext create_for(IScopedStorage storage);
    }

    public class ContextFactory : IContextFactory
    {
        public IContext create_for(IScopedStorage storage)
        {
            return new Context(storage.provide_storage());
        }
    }
}