using System;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;
using MoMoney.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public interface IBackgroundThreadFactory
    {
        IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : IDisposableCommand;
        IBackgroundThread create_for(Action action);
    }

    public class BackgroundThreadFactory : IBackgroundThreadFactory
    {
        private readonly IDependencyRegistry registry;

        public BackgroundThreadFactory(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : IDisposableCommand
        {
            return new BackgroundThread(registry.get_a<CommandToExecute>());
        }

        public IBackgroundThread create_for(Action action)
        {
            return new BackgroundThread(new DisposableCommand(action));
        }
    }
}