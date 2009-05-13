using System;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure
{
    public interface IProcessQueryCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly IQuery<T> query;
        readonly ISynchronizationContextFactory factory;

        public ProcessQueryCommand(IQuery<T> query, ISynchronizationContextFactory factory)
        {
            this.query = query;
            this.factory = factory;
        }

        public void run(ICallback<T> callback)
        {
            var dto = query.fetch();
            factory.create().run(new ActionCommand((Action) (() => callback.run(dto))));
        }
    }
}