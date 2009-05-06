using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public class AsynchronousCommandProcessor : ICommandProcessor
    {
        readonly Queue<ICommand> queued_commands;
        readonly EventWaitHandle manual_reset;
        readonly IList<Thread> worker_threads;
        bool keep_working;

        public AsynchronousCommandProcessor()
        {
            queued_commands = new Queue<ICommand>();
            worker_threads = new List<Thread>();
            manual_reset = new ManualResetEvent(false);
        }

        public void add(Expression<Action> action_to_process)
        {
            add(new ActionCommand(action_to_process));
        }

        public void add(ICommand command_to_process)
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
            ICommand command;
            lock (queued_commands)
            {
                if (queued_commands.Count == 0)
                {
                    manual_reset.Reset();
                    return;
                }
                command = queued_commands.Dequeue();
            }
            command.run();
            reset_thread();
        }

        void reset_thread()
        {
            lock (queued_commands)
            {
                if (queued_commands.Count > 0) manual_reset.Set();
                else manual_reset.Reset();
            }
        }
    }
}