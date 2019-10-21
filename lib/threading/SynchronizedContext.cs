using System.Threading;
using jive.utility;

namespace jive.threading
{
  public interface ISynchronizationContext : Command<Command> {}

  public class SynchronizedContext : ISynchronizationContext
  {
    readonly SynchronizationContext context;

    public SynchronizedContext(SynchronizationContext context)
    {
      this.context = context;
    }

    public void run(Command item)
    {
      context.Post(x => item.run(), new object());
      //context.Send(x => item.run(), new object());
    }
  }
}
