using System;
using System.Linq.Expressions;

namespace gorilla.commons.utility
{
    public class AnonymousCommand : Command
    {
        readonly Action action;

        public AnonymousCommand(Expression<Action> action) : this(action.Compile()) {}

        public AnonymousCommand(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }
    }
}