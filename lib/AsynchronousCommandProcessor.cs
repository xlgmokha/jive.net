using System;
using System.Collections.Generic;
using System.Threading;
using jive;

namespace jive
{
  public class AsynchronousCommandProcessor : CommandProcessor
  {
    readonly Queue<Command> queued_commands;
    readonly EventWaitHandle manual_reset;
    readonly IList<Thread> worker_threads;
    bool keep_working;

    static public readonly Command Empty = new EmptyCommand();

    public AsynchronousCommandProcessor()
    {
      queued_commands = new Queue<Command>();
      worker_threads = new List<Thread>();
      manual_reset = new ManualResetEvent(false);
    }

    public void add(Action command)
    {
      add(new AnonymousCommand(command));
    }

    public void add(Command command_to_process)
    {
      lock (queued_commands)
      {
        if (queued_commands.Contains(command_to_process)) return;
        queued_commands.Enqueue(command_to_process);
        reset_thread();
      }
    }

    public void run()
    {
      reset_thread();
      keep_working = true;
      var worker_thread = new Thread(run_commands);
      worker_thread.SetApartmentState(ApartmentState.STA);
      worker_threads.Add(worker_thread);
      worker_thread.Start();
    }

    public void stop()
    {
      keep_working = false;
      manual_reset.Set();
      //manual_reset.Close();
    }

    [STAThread]
    void run_commands()
    {
      while (keep_working)
      {
        manual_reset.WaitOne();
        run_next_command();
      }
    }

    void run_next_command()
    {
      var command = Empty;
      within_lock(() =>
          {
          if (queued_commands.Count == 0)
          manual_reset.Reset();
          else
          command = queued_commands.Dequeue();
          });
      safely_invoke(() =>
          {
          command.run();
          });
      reset_thread();
    }

    void safely_invoke(Action action)
    {
      try
      {
        action();
      }
      catch (Exception e)
      {
        this.log().error(e);
      }
    }

    void reset_thread()
    {
      within_lock(() =>
          {
          if (queued_commands.Count > 0) manual_reset.Set();
          else manual_reset.Reset();
          });
    }

    void within_lock(Action action)
    {
      lock (queued_commands)
      {
        action();
      }
    }
  }
}
