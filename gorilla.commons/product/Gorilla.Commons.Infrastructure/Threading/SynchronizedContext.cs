using System.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public class SynchronizedContext : ISynchronizationContext
    {
        readonly SynchronizationContext context;

        public SynchronizedContext(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run(ICommand item)
        {
            context.Post(x => item.run(), new object());
            //context.Send(x => item.run(), new object());
        }
    }
}