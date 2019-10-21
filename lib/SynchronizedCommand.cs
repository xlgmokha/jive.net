using System;
using System.Threading;

namespace jive
{
  public interface ISynchronizedCommand : Command<Action>, Command<Command> {}

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

    public void run(Command item)
    {
      run(item.run);
    }
  }
}
