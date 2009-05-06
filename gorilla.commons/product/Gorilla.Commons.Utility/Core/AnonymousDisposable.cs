using System;

namespace Gorilla.Commons.Utility.Core
{
    public class AnonymousDisposable : IDisposable
    {
        readonly Action action;

        public AnonymousDisposable(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action();
        }
    }
}