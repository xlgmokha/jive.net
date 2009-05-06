using System;
using System.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public interface ISynchronizedCommand : IParameterizedCommand<Action>, IParameterizedCommand<ICommand>
    {
    }

    public class SynchronizedCommand : ISynchronizedCommand
    {
        readonly SynchronizationContext context;

        public SynchronizedCommand(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run(Action item)
        {
            context.Post(x => item(), new object());
        }

        public void run(ICommand item)
        {
            run(item.run);
        }
    }
}