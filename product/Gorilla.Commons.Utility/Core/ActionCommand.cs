using System;
using System.Linq.Expressions;

namespace Gorilla.Commons.Utility.Core
{
    public class ActionCommand : ICommand
    {
        readonly Action action;

        public ActionCommand(Expression<Action> action) : this(action.Compile())
        {
        }

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }
    }
}