using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure
{
    public interface ICommandFactory
    {
        ICommand create_for<T>(ICallback<T> item, IQuery<T> query);
    }

    public class CommandFactory : ICommandFactory
    {
        readonly ISynchronizationContextFactory factory;

        public CommandFactory(ISynchronizationContextFactory factory)
        {
            this.factory = factory;
        }

        public ICommand create_for<T>(ICallback<T> item, IQuery<T> query)
        {
            return new RunQueryCommand<T>(item, new ProcessQueryCommand<T>(query, factory));
        }
    }
}