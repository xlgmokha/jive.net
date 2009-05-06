using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public class CommandProcessor : ICommandProcessor
    {
        readonly Queue<ICommand> queued_commands;

        public CommandProcessor()
        {
            queued_commands = new Queue<ICommand>();
        }

        public void add(Expression<Action> action_to_process)
        {
            add(new ActionCommand(action_to_process));
        }

        public void add(ICommand command_to_process)
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