using System;
using System.Collections.Generic;
using jive.utility;

namespace jive.threading
{
  public class SynchronousCommandProcessor : CommandProcessor
  {
    readonly Queue<Command> queued_commands;

    public SynchronousCommandProcessor()
    {
      queued_commands = new Queue<Command>();
    }

    public void add(Action command)
    {
      add(new AnonymousCommand(command));
    }

    public void add(Command command_to_process)
    {
      queued_commands.Enqueue(command_to_process);
    }

    public void run()
    {
      while (queued_commands.Count > 0) queued_commands.Dequeue().run();
    }

    public void stop()
    {
      queued_commands.Clear();
    }
  }
}
