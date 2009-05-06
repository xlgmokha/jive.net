using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure
{
    public interface ICommandPump
    {
        ICommandPump run<Command>() where Command : ICommand;
        ICommandPump run<Command>(Command command) where Command : ICommand;
        ICommandPump run<Command, T>(T input) where Command : IParameterizedCommand<T>;
        ICommandPump run<T>(ICallback<T> item, IQuery<T> query);
        ICommandPump run<Output, Query>(ICallback<Output> item) where Query : IQuery<Output>;
    }

    public class CommandPump : ICommandPump
    {
        readonly ICommandProcessor processor;
        readonly IDependencyRegistry registry;
        readonly ICommandFactory factory;

        public CommandPump(ICommandProcessor processor, IDependencyRegistry registry, ICommandFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
            this.registry = registry;
        }

        public ICommandPump run<Command>() where Command : ICommand
        {
            return run(registry.get_a<Command>());
        }

        public ICommandPump run<Command>(Command command) where Command : ICommand
        {
            processor.add(command);
            return this;
        }

        public ICommandPump run<Command, T>(T input) where Command : IParameterizedCommand<T>
        {
            processor.add(() => registry.get_a<Command>().run(input));
            return this;
        }

        public ICommandPump run<T>(ICallback<T> item, IQuery<T> query)
        {
            return run(factory.create_for(item, query));
        }

        public ICommandPump run<Output, Query>(ICallback<Output> item) where Query : IQuery<Output>
        {
            return run(item, registry.get_a<Query>());
        }
    }
}