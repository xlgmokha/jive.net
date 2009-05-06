using System;
using MoMoney.Utility.Core;

namespace Gorilla.Commons.Utility.Core
{
    public class DisposableCommand : IDisposableCommand
    {
        readonly Action action;

        public DisposableCommand(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }

        public void Dispose()
        {
        }
    }
}